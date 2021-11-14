using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Model
{
   public class UpdateUrlModel
    {
        /// <summary>
        /// 远程更新地址
        /// </summary>
        public static string RemoteUpdateUrl = "121.196.123.245:22" + "/test/tearing_monitor/soft/win/";
        /// <summary>
        /// 
        /// </summary>
        public static string Update_Url = "121.196.123.245";
        /// <summary>
        /// 远程文件路径
        /// </summary>
        public static string FileDirectory = "/test/tearing_monitor/soft/win/";
        /// <summary>
        /// //更新文件存放的文件夹(本地文件路径)
        /// </summary>
        public static string updateFileDir = System.Environment.CurrentDirectory + "\\upgrade";
        /// <summary>
        /// 文件名
        /// </summary>
        public static string fileName = "upgrade";
        /// <summary>
        /// FTP的IP地址
        /// </summary>
        public static string ftpServerIP = "121.196.123.245";
        /// <summary>
        /// FTP的端口
        /// </summary>
        public static string ftpPort = "22";
        /// <summary>
        /// 用户
        /// </summary>
        public static string ftpUserID = "test";
        /// <summary>
        /// 密码
        /// </summary>
        public static string ftpPassword = "ftp&User2021";
    }
}
