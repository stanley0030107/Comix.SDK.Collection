using Comix.Sms.SDK.Interfaces;
using Comix.Sms.SDK.Models;
using Comix.Sms.SDK.ReqModels;
using Comix.Sms.SDK.RespModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Sms.SDK.Services
{
    public class SMSService : ISMSService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SMSService> _logger;

        public SMSService(IHttpClientFactory httpClientFactory, ILogger<SMSService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// 获取token接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<RespGetToken> GetTokenAsync(ReqGetToken req)
        {
            var param = new Dictionary<string, object>()
            {
                { "AppKey", req.AppKey },
                { "AppSercet", req.AppSercet },
            };
            return await ExecuteFromAsync<RespGetToken>(SMSRoute.getTokenUrl, param);
        }

        /// <summary>
        /// 获取token接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public RespGetToken GetToken(ReqGetToken req)
        {
            var resp = GetTokenAsync(req).GetAwaiter().GetResult();
            return resp;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<RespSendSms> SendSmsAsync(ReqSendSms req)
        {
            var param = new Dictionary<string, object>()
            {
                { "Token", req.Token },
                { "Phone", req.Phone },
                { "Content", req.Content },
            };
            return await ExecuteFromAsync<RespSendSms>(SMSRoute.sendSmsUrl, param);
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public RespSendSms SendSms(ReqSendSms req)
        {
            var resp = SendSmsAsync(req).GetAwaiter().GetResult();
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
        private async Task<T> ExecuteFromAsync<T>(string path, Dictionary<string, object> param)
        {
            var resultStr = await ExecuteFromReturnStringAsync(path, param);
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
        private async Task<string> ExecuteFromReturnStringAsync(string path, Dictionary<string, object> param)
        {
            var postStr = string.Join("&", param.Select(o => $"{o.Key}={o.Value}"));
            // var postStr = JsonConvert.SerializeObject(param);
            var jsonContent = new StringContent(postStr, Encoding.UTF8, "application/x-www-form-urlencoded");

            // var client = _httpClientFactory.CreateClient();
            using (var client = new HttpClient())
            {
                if (SMSOptions.Url.EndsWith("/") && path.StartsWith("/"))
                {
                    path = path.TrimStart('/');
                }

                var url = $"{SMSOptions.Url}{path}";
                var response = await client.PostAsync(url, jsonContent);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{postStr}");

                var resultStr = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"sms请求：{url}\n请求参数：{postStr}\n响应参数：{resultStr}");
                return resultStr;
            }
        }


        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>ComixBaseResponseDto</returns>
        private async Task<T> ExecuteAsync<T>(string path, object req, Dictionary<string, string> heads = null)
        {
            var resultStr = await ExecuteReturnStringAsync(path, req, heads);
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
        private async Task<string> ExecuteReturnStringAsync(string path, object req, Dictionary<string, string> heads)
        {
            var jsonStr = JsonConvert.SerializeObject(req);
            var jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            if (heads != null && heads.Count > 0)
            {
                foreach (var item in heads)
                {
                    bool b = client.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
                    //jsonContent.Headers.TryAddWithoutValidation(item.Key, item.Value);
                }
            }

            if (SMSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{SMSOptions.Url}{path}";
            var response = client.PostAsync(url, jsonContent).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"wos请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }

        #endregion
    }
}