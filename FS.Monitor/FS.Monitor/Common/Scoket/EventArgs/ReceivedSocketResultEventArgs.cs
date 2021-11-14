using FS.Monitor.Common.Scoket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket.EventArgs
{
    /// <summary>
    /// 收到返回值包事件参数
    /// </summary>
    public class ReceivedSocketResultEventArgs : System.EventArgs
    {
        private SocketResult _SocketResult;
        /// <summary>
        /// 数据
        /// </summary>
        public SocketResult SocketResult
        {
            get { return _SocketResult; }
            set { _SocketResult = value; }
        }

        public ReceivedSocketResultEventArgs(SocketResult socketResult)
        {
            _SocketResult = socketResult;
        }

    }
}
