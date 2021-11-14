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
  public class IFilesDownInterface
    {
        /// <summary>
        /// 文件下载 
        /// </summary>
        /// <param name="os_type">系统类型，1:linux，2:win</param>
        /// <returns></returns>
        public async Task<DownReturnModel.Root> FilesDownInterf(int os_type)
        {
            var http = new HttpExtend();
            var result = await http.PostDown<dynamic, DownReturnModel.Root>(Urls.FILE_DOWN + "?os_type=" + os_type, null);

            return result;
        }
    }
}
