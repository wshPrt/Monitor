using FS.Monitor.Common;
using FS.Monitor.Common.HttpRequest;
using FS.Monitor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Interface
{
   public  class IGetSoftwareVersion
    {
        /// <summary>
        /// 获取最新的软件信息
        /// </summary>
        /// <param name="os_type">系统类型，1:linux，2:win</param>
        /// <returns></returns>
        public async Task<GetVersionReturnModel.Root> GetSoftwareVersion (int os_type)
        {
            var http = new HttpExtend();
            var result = await http.Post<dynamic, GetVersionReturnModel.Root>(Urls.GET_LATEST_VERSION + "?os_type=" + os_type, null);

            return result;
        }
    }
}
