using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Comix.Qx.Infrastructure.Interfaces;
using Comix.Qx.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Comix.Qx.Infrastructure.Services
{
    public class QxService : IQxService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<QxService> _logger;

        public QxService(IHttpClientFactory httpClientFactory, ILogger<QxService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        #region 基础方法

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync<T>(string path, object req)
        {
            var resultStr = await ExecuteReturnStringAsync(path, req);
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> ExecuteReturnStringAsync(string path, object req)
        {
            var jsonStr = JsonConvert.SerializeObject(req);

            if (QxOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{QxOptions.Url}{path}";

            var jsonContent = new StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            var response = client.PostAsync(url, jsonContent).Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Qx请求异常-{response.StatusCode}，请求url：{url}, 请求参数：{jsonStr}");
            }

            var resultStr = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Qx请求：{Url}\\n请求参数：{JsonStr}\\n响应参数：{ResultStr}", url, jsonStr, resultStr);

            return resultStr;
        }

        #endregion
        
    }
}