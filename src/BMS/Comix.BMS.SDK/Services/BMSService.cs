using Comix.BMS.SDK.Interfaces;
using Comix.BMS.SDK.Models;
using Comix.BMS.SDK.Models.Req;
using Comix.BMS.SDK.Models.Resp;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comix.BMS.SDK.Services
{
    public class BMSService: IBMSService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BMSService> _logger;

        public BMSService(IHttpClientFactory httpClientFactory, ILogger<BMSService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        /// <summary>
        /// 推送发票文件
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<BmsSdkRespBase<ReqPushInvoiceDto>> PushInvoiceAsync(ReqPushInvoiceDto req)
        {
            return await ExecuteAsync<BmsSdkRespBase<ReqPushInvoiceDto>>(BmsSdkRoute.api_uploadAndPutRightInvoice, req);
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
            //加上token
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", BmsSdkOptions.Authorization);

            if (BmsSdkOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{BmsSdkOptions.Url}{path}";
            var response = await client.PostAsync(url, jsonContent);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"BMS请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"BMS请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}
