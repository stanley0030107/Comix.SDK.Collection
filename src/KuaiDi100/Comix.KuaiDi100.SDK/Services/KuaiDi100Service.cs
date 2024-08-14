using Comix.KuaiDi100.SDK.Interfaces;
using Comix.KuaiDi100.SDK.Models;
using Comix.KuaiDi100.SDK.Models.Resp;
using Comix.KuaiDi100.SDK.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comix.KuaiDi100.SDK.Services
{
    public class KuaiDi100Service: IKuaiDi100Service
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<KuaiDi100Service> _logger;

        public KuaiDi100Service(IHttpClientFactory httpClientFactory, ILogger<KuaiDi100Service> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// 收货地址解析
        /// </summary>
        /// <param name="content">地址信息</param>
        /// <returns></returns>
        public async Task<RespBase<List<RespAddressParseDto>>> AddressParseAsync(string content)
        {
            if(string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");

            var param = new Dictionary<string, object>()
            {
                { "secret_key", KuaiDi100Extension.kuaiDi100Config.key },
                { "secret_code", "0db4f037e2094f15a811261722e8a6e9" }, //接口编码
                { "secret_sign", KuaiDi100Extension.kuaiDi100Config.secret_sign },
                //{ "secret_sign", SignUtils.GetMD5(KuaiDi100Extension.kuaiDi100Config.key+KuaiDi100Extension.kuaiDi100Config.secret) },
                { "content", content },
            };
            return await ExecuteFromAsync<RespBase<List<RespAddressParseDto>>>(ApiInfoConstant.CLOUDAPI_URL, param);
        }
        /// <summary>
        /// 智能识别接口
        /// </summary>
        /// <param name="num">快递单号</param>
        /// <returns></returns>
        public async Task<List<ReqAutoNumberDto>> AutoNumberAsync(string num)
        {
            if (string.IsNullOrEmpty(num))
                throw new ArgumentNullException("快递智能识别接口num");

            var param = new Dictionary<string, object>()
            {
                { "key", KuaiDi100Extension.kuaiDi100Config.key },
                { "num",num }, //快递单号
            };
            return await ExecuteFromAsync<List<ReqAutoNumberDto>>(ApiInfoConstant.AUTOAPI_URL, param);
        }


        #region 基础封装

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>ComixBaseResponseDto</returns>
        private async Task<T> ExecuteFromAsync<T>(string path, Dictionary<string, object> param)
        {
            var postStr = string.Join("&", param.Select(o => $"{o.Key}={o.Value}"));

            var resultStr = await ExecuteReturnStringAsync(path, postStr, "application/x-www-form-urlencoded");
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns>ComixBaseResponseDto</returns>
        private async Task<T> ExecuteAsync<T>(string url, object req)
        {
            var content = JsonConvert.SerializeObject(req);
            var resultStr = await ExecuteReturnStringAsync(url, content, "application/json");
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> ExecuteReturnStringAsync(string url, string content,string mediaType)
        {
            var jsonContent = new StringContent(content, Encoding.UTF8, mediaType);
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsync(url, jsonContent);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"kuaidi100请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{content}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"kuaidi100请求：{url}\n请求参数：{content}\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}
