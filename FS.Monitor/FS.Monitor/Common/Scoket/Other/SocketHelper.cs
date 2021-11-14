using FS.Monitor.Common.Scoket.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket
{
    /// <summary>
    /// Socket封装
    /// </summary>
    public static class SocketHelper
    {
      static byte header0 = (byte)0x55;
      static byte header1 = (byte)0xAA;
        /// <summary>
        /// 获取发送的数据
        /// </summary>
        /// <param name="data">传入主要参数<p>
        /// 格式：命令,参数1，参数2，参数3...
        /// </param>
        /// <returns></returns>
        public static byte[] getSendData(params byte[] data)
        {
            if (null == data || data.Length==0)
            {
                throw new ArgumentNullException("传入参数不能为空");
            }
            int len = 3 + data.Length;
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

        #region Send
        /// <summary>
        /// Send
        /// </summary>
        public static bool Send(Socket socket, byte[] data)
        {
            try
            {
                if (socket == null || !socket.Connected) return false;

                int sendTotal = 0;
                while (sendTotal < data.Length)
                {
                    int sendLength = data.Length - sendTotal;
                    if (sendLength > 1024) sendLength = 1024;
                    //int sendOnce = socket.Send(data, sendTotal, sendLength, SocketFlags.None);
                    int sendOnce = socket.Send(data);
                    sendTotal += sendOnce;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex);
                return false;
            }
        }
        #endregion

    }

}
