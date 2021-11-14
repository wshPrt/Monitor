using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
  public class DownReturnModel
    {
        public class Root
        {
            /// <summary>
            /// 未读取到相关数据
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }
    }
}
