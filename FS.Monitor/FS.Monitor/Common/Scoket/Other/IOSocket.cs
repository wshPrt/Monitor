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

    public class IOSocket
    {
        private readonly Queue<SocketDataPacket> dataPackets = new Queue<SocketDataPacket>();
        private readonly byte[] buffer = new byte[256];
        private readonly object lockSendData = new object();
        private readonly object lockSendDataPacket = new object();
        private readonly string ipString;
        private readonly int port;

        private Thread beatThread;
        private Thread receiptThread;
        private Thread sendThread;

        private Socket client = null;

        public event EventHandler<SocketDataPacket> Receipt;
        public IOSocket(string _ipString, int _port)
        {
            ipString = _ipString;
            port = _port;
        }

        public void Start()
        {
            if (client != null)
            {
                throw new Exception();
            }

            IPAddress ipAddress = IPAddress.Parse(ipString);
            EndPoint endPoint = new IPEndPoint(ipAddress, port);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                DontFragment = false,
                ExclusiveAddressUse = true,
                UseOnlyOverlappedIO = false,
                SendBufferSize = 1024 * 1024 * 10,
                ReceiveBufferSize = 1500
            };

            client.Connect(endPoint);

            beatThread = new Thread(OnBeat) { IsBackground = true };
            receiptThread = new Thread(OnReceipt) { IsBackground = true };
            sendThread = new Thread(OnSend) { IsBackground = true };

            beatThread.Start();
            receiptThread.Start();
            sendThread.Start();
        }

        public void Stop()
        {
            if (client == null)
            {
                throw new Exception();
            }

            try
            {
                client.Close();
                client.Dispose();
                client = null;
            }
            catch
            {
            }

            try
            {
                beatThread.Abort();
                beatThread = null;
            }
            catch
            {
            }

            try
            {
                receiptThread.Abort();
                receiptThread = null;
            }
            catch
            {
            }

            try
            {
                sendThread.Abort();
                sendThread = null;
            }
            catch
            {
            }
        }

        public async void SendAsync(SocketDataPacket dataPacket)
        {
            await Task.Run(() => Send(dataPacket));
        }

        public void Send(SocketDataPacket dataPacket)
        {
            lock (lockSendDataPacket)
            {
                dataPackets.Enqueue(dataPacket);
            }
        }

        private void OnSend()
        {
            while (true)
            {
                lock (lockSendDataPacket)
                {
                    if (dataPackets.Count > 0)
                    {
                        var dataPacket = dataPackets.Dequeue();

                        try
                        {
                            SendData(dataPacket.Command, dataPacket.Data, dataPacket.Size);
                        }
                        catch
                        {
                            Send(dataPacket);
                        }
                    }
                }

                Thread.Sleep(500);
            }
        }

        private void OnReceipt()
        {
            while (true)
            {
                int size = client.Receive(buffer, 4, SocketFlags.None);
                if (size == 0)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (size != 4 && buffer[0] != 0x55 && buffer[1] != 0xAA)
                {
                    throw new Exception();
                }

                byte total = buffer[2];
                byte command = buffer[3];

                // 有数据
                if (total > 4)
                {
                    size = client.Receive(buffer, total - 4, SocketFlags.None);
                    if (size != total - 4)
                    {
                        throw new Exception();
                    }
                }
                // 无数据
                else
                {
                    size = 0;
                }

                if (Receipt != null)
                {
                    Receipt(this, new SocketDataPacket
                    {
                        Command = command,
                        Data = buffer,
                        Size = size
                    });
                }
            }
        }

        private void OnBeat()
        {
            while (true)
            {
                SendData(0x00, null, 0);
                Thread.Sleep(5000);
            }
        }

        private void SendData(byte command, byte[] data, int size)
        {
            lock (lockSendData)
            {
                _ = client.Send(new byte[] { 0x55, 0xAA, (byte)(size + 4), command });

                if (size > 0)
                {
                    _ = client.Send(data, size, SocketFlags.None);
                }
            }
        }
    }

    public struct SocketDataPacket
    {
        /// <summary>
        /// 命令
        /// </summary>
        public byte Command;

        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// 数据长度
        /// </summary>
        public int Size;
    }
}
