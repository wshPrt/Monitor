using FS.Monitor.Common.Scoket.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket.Models
{
    /// <summary>
    /// Socket数据
    /// </summary>
    [Serializable]
    public class SocketData
    {
        /// <summary>
        /// Socket包头
        /// </summary>
        public static readonly string HeaderString = "0x55";
        public static readonly string HeadTwo = "0xAA";
        public static readonly string Command = "0x00";
        public static readonly byte[] by = new byte[] { 0x55, 0xAA, 0x04, 0x00 };
        /// <summary>
        /// Socket包头
        /// </summary>
        public static readonly byte[] HeaderBytes = Encoding.ASCII.GetBytes(SocketData.HeaderString);

        /// <summary>
        /// 类型 1心跳 2心跳应答 3注册包 4注册反馈 5消息数据 6返回值
        /// </summary>
        public SocketDataType Type { get; set; }

        /// <summary>
        /// 消息数据
        /// </summary>
        public MsgContent Content { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public SocketResult SocketResult { get; set; }

        /// <summary>
        /// 注册包数据
        /// </summary>
        public SocketRegisterData SocketRegisterData { get; set; }
    }
}
