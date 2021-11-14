using FS.Monitor.Common;
using FS.Monitor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public static  class PublicModel
    {
        /// <summary>
        /// 监测管理
        /// </summary>
        private static MonitorModel _monitorInfo;
        public static MonitorModel MonitorInfo
        {
            get { return _monitorInfo; }
            set { _monitorInfo = value; }
        }

        public static ModifyItem ModifyItemInfo { get; set; }

        public static XmlHelper _xmlHelper { get; set; }
    }
}
