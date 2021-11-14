using FS.Monitor.Common.Scoket.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket
{
    public class SocketClientHelper
    {
        private string _serverIP;
        private int _serverPort;
        public Socket clientSocket;
        private System.Timers.Timer _heartbeatTimer;
        private object _lockSend = new object();
        public Queue<action> _q = new Queue<action>();//命令列队
        private DateTime _lastHeartbeat; //最后一次心跳时间
        private System.Timers.Timer _checkServerTimer;
        public Action<byte[]> ReciveAction { get; set; }
        public SocketClientHelper(string serverIP, int serverPort)
        {
            _serverIP = serverIP;
            _serverPort = serverPort;
        }

        /// <summary>
        /// 连接
        /// </summary>
        public bool Connect()
        {
            try
            {
                if (clientSocket == null || !clientSocket.Connected)
                {
                    if (clientSocket != null)
                    {
                        clientSocket.Close();
                        clientSocket.Dispose();
                    }
                    IPAddress iPAddress = IPAddress.Parse(_serverIP);
                    EndPoint point = new IPEndPoint(iPAddress, _serverPort);
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.DontFragment = false;
                    clientSocket.ExclusiveAddressUse = true;
                    clientSocket.UseOnlyOverlappedIO = false;
                    clientSocket.SendBufferSize = 1500;
                    clientSocket.ReceiveBufferSize = 1500;
                    try
                    {
                        clientSocket.Connect(point); //链接
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Error(ex);
                        return false;
                    }

                    if (clientSocket == null || !clientSocket.Connected) return false;
                    _lastHeartbeat = DateTime.Now;//最后一次心跳
                    //检测服务端
                    _checkServerTimer = new System.Timers.Timer();
                    _checkServerTimer.AutoReset = false;
                    _checkServerTimer.Interval = 1000;
                    _checkServerTimer.Elapsed += CheckServer;
                    _checkServerTimer.Start();

                    LogUtil.Log("已连接服务器");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "连接服务器失败");
                return false;
            }
        }
        private void CheckServer(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                if (now.Subtract(_lastHeartbeat).TotalSeconds > 15)
                {
                    LogUtil.Log("服务端已失去连接");
                    try
                    {
                        ReleaseServerSocket();
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Error(ex);
                    }

                    Thread.Sleep(3000);
                    int tryCount = 0;
                    while (!Connect() && tryCount++ < 10000) //重连
                    {
                        Thread.Sleep(3000);
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "检测服务端出错");
            }
            finally
            {
                _checkServerTimer.Start();
            }
        }


        /// <summary>
        /// 心跳
        /// </summary>
        public void StartHearbeat()
        {
            _heartbeatTimer = new System.Timers.Timer();
            _heartbeatTimer.AutoReset = false;
            _heartbeatTimer.Interval = 5000;
            _heartbeatTimer.Elapsed += _heartbeatTimer_Elapsed;
            //_heartbeatTimer.Elapsed += StartQueue;
            _heartbeatTimer.Start();
        }

        /// <summary>
        /// AddCmd
        /// </summary>
        public void AddCmd(action act)
        {
            this._q.Enqueue(act);
        }

        public void StartQueue()
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        try
                        {
                            if (this._q.Count > 0)
                            {
                                while (this._q.Count > 0)
                                {
                                    var action = this._q.Dequeue();
                                    try
                                    {
                                        //发送命令
                                        clientSocket.Send(this.GetByteData(action));
                                    }
                                    catch (Exception ex)
                                    {
                                        LogUtil.Error(ex.ToString());
                                        this.AddCmd(action);
                                    }

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogUtil.Error("发送消息列队出错：" + ex.Message);
                        }

                        Thread.Sleep(100);
                    }
                });
            }
            catch (Exception ex)
            {
                LogUtil.Error("向服务器发送心跳包出错：" + ex.Message);
            }
            finally
            {
                _heartbeatTimer.Start();
            }
        }

        private void _heartbeatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                byte hearbeatCmd = 0x08;// 0x06;// 0x04;// 0x02;//0x00; 
                lock (_lockSend)
                {
                    clientSocket.Send(SendData(hearbeatCmd));
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error("向服务器发送心跳包出错：" + ex.Message);
            }
            finally
            {
                _heartbeatTimer.Start();
            }
        }

        /// <summary>
        /// 获取发送的数据
        /// </summary>
        /// <param name="data">传入主要参数<p>
        /// 格式：命令,参数1，参数2，参数3...
        /// </param>
        /// <returns></returns>
        static byte header0 = (byte)0x55;
        static byte header1 = (byte)0xAA;
        public static byte[] SendData(params byte[] data)
        {
            if (null == data || data.Length == 0)
            {
                throw new ArgumentNullException("传入参数不能为空");
            }
            int len = 4 + data.Length;
            byte[] tmp = new byte[len];

            tmp[0] = header0;
            tmp[1] = header1;
            tmp[3] = data[0];

            for (int i = 4; i < data.Length + 3; i++)
            {
                tmp[i] = data[i];
            }
            tmp[2] = (byte)tmp.Length;
            return tmp;
        }

        private byte[] GetByteData(action act)
        {
            var header0 = act.Header0;
            var header1 = act.Header1;

            byte[] result = new byte[4];
            result[0] = header0;
            result[1] = header1;
            result[2] = 4;
            result[3] = act.Cmd;

            return result;
        }

        /// <summary>
        /// 释放Socket服务端
        /// </summary>
        private void ReleaseServerSocket()
        {
            if (clientSocket.Connected) clientSocket.Disconnect(false);
            clientSocket.Close();
            clientSocket.Dispose();
        }

        /// <summary>
        /// 不停的接受服务器发来的消息
        /// </summary>
        public void Recive()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[10];
                    int r = clientSocket.Receive(buffer);
                    //实际接收到的有效字节数
                    if (r == 0)
                    {
                        break;
                    }

                    this.ReciveAction?.Invoke(buffer);
                    _lastHeartbeat = DateTime.Now;
                    // buffer就是接收到的消息。10个长度
                }
                catch (Exception ex)
                {
                    LogUtil.Error(ex.Message);
                }
            }
        }

        public class action
        {
            private byte header0 = (byte)0x55;
            public byte Header0
            {
                get { return header0; }
                set { header0 = value; }
            }

            private byte header1 = (byte)0xAA;
            public byte Header1
            {
                get { return header1; }
                set { header1 = value; }
            }

            public byte Cmd { get; set; }
        }
    }
}
