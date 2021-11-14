using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket.EventArgs
{
    /// <summary>
    /// Socket客户端注册事件参数
    /// </summary>
    public class SocketClientRegisterEventArgs : System.EventArgs
    {
        private string _SocketClientId;
        /// <summary>
        /// Socket客户端ID
        /// </summary>
        public string SocketClientId
        {
            get { return _SocketClientId; }
            set { _SocketClientId = value; }
        }

        /// <summary>
        /// Socket客户端注册事件参数
        /// </summary>
        public SocketClientRegisterEventArgs(string socketClientId)
        {
            _SocketClientId = socketClientId;
        }
    }
}
