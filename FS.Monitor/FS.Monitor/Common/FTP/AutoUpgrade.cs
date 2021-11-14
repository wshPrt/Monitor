using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.FTP
{
   public class AutoUpgrade
    {
        /// <summary>
        /// 启动自动升级程序
        /// </summary>
        /// </summary>
        /// <param name="version"></param>
        /// <param name="version_no"></param>
        public static void Start(int version, string version_no) 
        {
            string SERVER_URL = ConfigurationManager.ConnectionStrings["SERVER_URL"].ConnectionString;
            string UPGRADE_URL = ConfigurationManager.ConnectionStrings["UPGRADE_URL"].ConnectionString;

            Process m_Process = new Process();
            m_Process.StartInfo = new ProcessStartInfo("AutoUpgrade.exe", SERVER_URL + " " + UPGRADE_URL + " " + version + " " + version_no);
            m_Process.Start();
        }
    }
}
