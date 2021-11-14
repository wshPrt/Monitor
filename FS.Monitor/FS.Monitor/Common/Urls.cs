using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common
{
   public class Urls
    {
        /// <summary>
        /// 请求IP地址
        /// // ConfigurationManager.ConnectionStrings["SERVER_URL"].ConnectionString;
        /// </summary>
        private static readonly string SERVER_URL = "http://api.cqbaoli.net";
        private static readonly string API_URL = "http://ep.cqbaoli.net";
        /// <summary>
        /// 视频流地址
        /// //ConfigurationManager.ConnectionStrings["RTSP_URL"].ConnectionString;
        /// </summary>
        public static readonly string RTSP_URL ="rtsp://121.196.123.245:19351/live/test";//  "rtsp://192.168.100.181/live/test";
        /// <summary>
        /// 音频流地址
        /// </summary>
        public static string AUDIO_RTSP_URL = "rtmp://121.196.123.245:19351/live/test1";
        /// <summary>
        /// 获取最新的软件信息
        /// </summary>
        public static string GET_LATEST_VERSION = API_URL + "/api/soft/getLastSoftVersionInfo";
        /// <summary>
        /// 文件下载
        /// </summary>
        public static string FILE_DOWN = API_URL + "/api/soft/getSoftFile";
        /// <summary>
        /// 系统版本
        /// </summary>
        public static string SYSTEM_VERSION;
        /// <summary>
        /// 总下载时间
        /// </summary>
        public static int realReadLen;       
    }
}
