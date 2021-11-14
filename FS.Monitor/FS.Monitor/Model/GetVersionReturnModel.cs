using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public class GetVersionReturnModel
    {
        public class Data
        {
            /// <summary>
            /// 签名
            /// </summary>
            public string sign { get; set; }
            /// <summary>
            /// 版本值
            /// </summary>
            public int version_number { get; set; }
            /// <summary>
            /// 版本号
            /// </summary>
            public string version { get; set; }
        }
        public class Root
        {
            /// <summary>
            /// 读取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
        }
    }
}
