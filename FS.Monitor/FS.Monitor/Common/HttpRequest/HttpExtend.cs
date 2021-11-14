using FS.Monitor.Common.MessageDialog;
using GalaSoft.MvvmLight.Threading;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FS.Monitor.Common.HttpRequest
{
    public class HttpExtend
    {
        /// <summary>
        /// 实体转成get参数
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public async Task<K> Get<T, K>(string url, T param)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var paramStr = ModelToHttpParam<T>.ToGetParam(param);
            var requstResult = await httpClient.GetAsync(url + paramStr);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }

        /// <summary>
        /// 实体转成Delete参数
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public async Task<K> Delete<T, K>(string url, T param)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var paramStr = ModelToHttpParam<T>.ToGetParam(param);
            var requstResult = await httpClient.DeleteAsync(url + paramStr);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }
        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public async Task<K> Post<T, K>(string url, T param)
        {
            HttpClient httpClient = new HttpClient();
            var paramStr = ModelToHttpParam<T>.ToPostParam(param);
            var strContent = new StringContent(paramStr);
            strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");// ("content-type", "application/json");
            var requstResult = await httpClient.PostAsync(url, paramStr == "{}" ? null : strContent);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }
        /// <summary>
        /// PostDown请求
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回流文件</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public async Task<K> PostDown<T, K>(string url, T param)
        {
            HttpClient httpClient = new HttpClient();
            var paramStr = ModelToHttpParam<T>.ToPostParam(param);
            var strContent = new StringContent(paramStr);
            strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var requstResult = await httpClient.PostAsync(url, paramStr == "{}" ? null : strContent);
            string resultTwo = "";
            Stream result = null;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Upgrade";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var savePath = path + "/Upgrade.zip";
            if (!File.Exists(savePath)) File.Create(savePath).Close();
            using (requstResult)
            { 
                result = await requstResult.Content.ReadAsStreamAsync();
                System.IO.FileStream stream = new System.IO.FileStream(path+ "/Upgrade.zip", System.IO.FileMode.Create);
                byte[] buf = new byte[10240];
                Urls.realReadLen = result.Read(buf, 0, buf.Length);
                int count = 0;
                while ((count = result.Read(buf, 0, 10240)) > 0)
                {
                    stream.Write(buf, 0, count);
                }
                stream.Close(); 
            } 
            return JsonConvert.DeserializeObject<K>(resultTwo);
        }
    }

    /// <summary>
    /// 实体转Http请求参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ModelToHttpParam<T>
    {
        /// <summary>
        /// 当前实体属性列表
        /// </summary>
        public static PropertyInfo[] PropertyInfos { get; set; }

        /// <summary>
        /// 转成get请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToGetParam(T model)
        {
            if (model == null) return "";
            if (PropertyInfos == null || PropertyInfos.Count() == 0)
            {
                PropertyInfos = typeof(T).GetProperties();
            }
            var paramList = PropertyInfos.Select(i =>
            {
                var name = i.Name;
                var value = i.GetValue(model);
                return value == null ? "" : $"{name}={value}";
            }).Where(i => !string.IsNullOrEmpty(i)).ToList();
            return "?" + string.Join("&", paramList);
        }

        /// <summary>
        /// 转成POST请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToPostParam(T model)
        {
            if (model == null) return "{}";
            return JsonConvert.SerializeObject(model);
        }
    }
}
