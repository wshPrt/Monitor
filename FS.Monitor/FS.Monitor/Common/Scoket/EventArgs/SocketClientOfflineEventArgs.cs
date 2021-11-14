using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket.EventArgs
{
    /// <summary>
    /// 客户端离线事件参数
    /// </summary>
    public class SocketClientOfflineEventArgs : System.EventArgs
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

        public SocketClientOfflineEventArgs(string socketClientId)
        {
            _SocketClientId = socketClientId;
        }
    }
}
