using FS.Monitor.Common.Scoket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.Scoket.EventArgs
{
    /// <summary>
    /// Socket事件参数
    /// </summary>
    public class SocketReceivedEventArgs : System.EventArgs
    {
        private MsgContent _Content;
        /// <summary>
        /// 消息数据
        /// </summary>
        public MsgContent Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private CallbackSocket _Callback;
        /// <summary>
        /// 回调类
        /// </summary>
        public CallbackSocket Callback
        {
            get { return _Callback; }
            set { _Callback = value; }
        }

        public SocketReceivedEventArgs(MsgContent data)
        {
            _Content = data;
        }
    }
}
