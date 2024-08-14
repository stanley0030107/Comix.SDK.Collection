using Comix.COM.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Comix.COM.SDK.Models;
using Microsoft.Extensions.Logging;

namespace Comix.COM.SDK.Services
{
    public class COMService :ICOMService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<COMService> _logger;
        public COMService(IHttpClientFactory httpClientFactory, ILogger<COMService> logger) 
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ResponseComModel> UniqueIdNewIdAsync(CodeParam req)
        {
            return await ExecuteAsync<ResponseComModel>(COMRoute.UniqueIdNewId, req);
        }

        public ResponseComModel UniqueIdNewId(CodeParam req)
        {
            return UniqueIdNewIdAsync(req).Result;
        }


        #region 基础封装
        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>ComixBaseResponseDto</returns>
        private async Task<T> ExecuteAsync<T>(string path, object req)
        {
            var resultStr = await ExecuteReturnStringAsync(path, req);
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        ///     执行post请求
        /// </summary>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> ExecuteReturnStringAsync(string path, object req)
        {
            var jsonStr = JsonConvert.SerializeObject(req);
            var jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            if (COMOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{COMOptions.Url}{path}";
            var response = client.PostAsync(url, jsonContent).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"pms请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}
