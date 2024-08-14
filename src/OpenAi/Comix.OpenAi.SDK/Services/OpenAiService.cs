using Comix.OpenAi.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Comix.OpenAi.SDK.Common;
using Comix.OpenAi.SDK.ReqModels;
using Comix.OpenAi.SDK.RespModels;

namespace Comix.OpenAi.SDK.Services
{
    public class OpenAiService:IOpenAiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OpenAiService> _logger;

        public OpenAiService(IHttpClientFactory httpClientFactory, ILogger<OpenAiService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// 接口方式请求GPT
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<RespApiChatgptChatDto> ApiChatgptChatAsync(ReqApiChatgptChatDto req)
        {
            var resp = await ExecuteAsync<RespApiChatgptChatDto>(OpenAiRoute.ApiChatgptChatUrl, req);
            return resp;
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
        /// 执行post请求
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
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-Token", OpenAiExtension.openAiOptions.Token);

            if (OpenAiExtension.openAiOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{OpenAiExtension.openAiOptions.Url}{path}";
            var response = client.PostAsync(url, jsonContent).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"openai请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"openai请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }

        #endregion
    }
}
