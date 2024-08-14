using Comix.Cics.Model.ReqModels;
using Comix.Cics.Model.RespModels;
using Comix.Cics.SDK.Interfaces;
using Comix.Cics.SDK.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Cics.SDK.Service
{
    public class CicsService : ICicsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CicsService> _logger;

        public CicsService(IHttpClientFactory httpClientFactory, ILogger<CicsService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        #region 消息回调接口

        public async Task<ResponseBase<bool>> NotifyCallBackAsync(NotifyCallBackParam message)
        {
            return await ExecuteAsync<ResponseBase<bool>>(CicsRoute.NotifyCallBackPath, message);
        }

        public ResponseBase<bool> NotifyCallBack(NotifyCallBackParam message)
        {
            return NotifyCallBackAsync(message).Result;
        }

        #endregion


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

            if (CicsOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{CicsOptions.Url}{path}";
            var response = await client.PostAsync(url, jsonContent);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"pms请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}
