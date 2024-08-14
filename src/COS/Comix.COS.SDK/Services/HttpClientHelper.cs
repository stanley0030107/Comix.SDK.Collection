using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Comix.COS.SDK.Services
{
    public static class HttpClientHelper
    {
        // 设置 JsonSerializerSettings 来处理 null 值
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Populate,
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="logger"></param>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <param name="httpClientFactory"></param>
        /// <returns>ComixBaseResponseDto</returns>
        public static async Task<T> ExecuteAsync<T>(this IHttpClientFactory httpClientFactory, ILogger logger, string path, object req)
        {
            var resultStr = await ExecuteReturnStringAsync(httpClientFactory, logger,path, req);

            var resultObj = JsonConvert.DeserializeObject<T>(resultStr, JsonSettings);
            
            return resultObj;
        }

        /// <summary>
        ///     执行post请求
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <param name="httpClientFactory"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> ExecuteReturnStringAsync(this IHttpClientFactory httpClientFactory, ILogger logger, string path, object req)
        {
            var jsonStr = JsonConvert.SerializeObject(req);
            var jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var client = httpClientFactory.CreateClient();

            if (COSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{COSOptions.Url}{path}";
            var response = await client.PostAsync(url, jsonContent);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            logger.LogInformation("pms请求：{Url}\\n请求参数：{JsonStr}\\n响应参数：{ResultStr}", url, jsonStr, resultStr);
            return resultStr;
        }


        public static T Execute<T>(this IHttpClientFactory httpClientFactory, ILogger logger, string path, object req)
        {
            var resultStr = ExecuteReturnString(httpClientFactory, logger, path, req);

            var resultObj = JsonConvert.DeserializeObject<T>(resultStr, JsonSettings);

            return resultObj;
        }

        public static string ExecuteReturnString(this IHttpClientFactory httpClientFactory, ILogger logger, string path, object req)
        {
            string jsonStr = JsonConvert.SerializeObject(req);
            StringContent jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            HttpClient client = httpClientFactory.CreateClient();
            if (COSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }
            client.Timeout = TimeSpan.FromSeconds(3);
            string url = COSOptions.Url + path;
            HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");
            }

            string resultStr =  response.Content.ReadAsStringAsync().Result;
            logger.LogInformation("pms请求：{Url}\\n请求参数：{JsonStr}\\n响应参数：{ResultStr}", url, jsonStr, resultStr);
            return resultStr;
        }

        public static T Execute<T>(this IHttpClientFactory httpClientFactory, ILogger logger, string path, object req, TimeSpan timeout)
        {
            var resultStr = ExecuteReturnString(httpClientFactory, logger, path, req ,timeout);
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr, JsonSettings);
            return resultObj;
        }

        public static string ExecuteReturnString(this IHttpClientFactory httpClientFactory, ILogger logger, string path, object req,TimeSpan timeout)
        {
            string jsonStr = JsonConvert.SerializeObject(req);
            if (COSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }
            string url = COSOptions.Url + path;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                StringContent jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                using (HttpClient client = httpClientFactory.CreateClient())
                {
                    client.Timeout = timeout;

                    HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
                    sw.Stop();

                    if (!response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        throw new Exception($"请求异常-{response.StatusCode} 耗时 {sw.ElapsedMilliseconds} ms\n请求地址：{url}，请求参数：{jsonStr}\n响应内容：{responseBody}");
                    } 
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException hre)
            {
                sw.Stop();
                throw new Exception($"请求异常-网络错误 耗时 {sw.ElapsedMilliseconds} ms\n请求地址：{url}，请求参数：{jsonStr}", hre);
            }
            catch (TaskCanceledException tce)
            {
                sw.Stop();
                throw new Exception($"请求异常-请求超时 耗时 {sw.ElapsedMilliseconds} ms\n请求地址：{url}，请求参数：{jsonStr}", tce);
            }
            catch (AggregateException ae)
            {
                sw.Stop();
                var error = string.Empty;
                foreach (var innerEx in ae.InnerExceptions)
                {
                    if (innerEx is TaskCanceledException tce)
                    {
                        error += "  innerEx:" + tce.Message;
                    }
                    else
                    {
                        error += "  NoinnerEx:" + innerEx.Message;
                    }
                }
                throw new Exception($"请求异常-ae-{ae.Message} error:{error} 耗时 {sw.ElapsedMilliseconds} ms\n请求地址：{url}，请求参数：{jsonStr}", ae);
            }
            catch (OperationCanceledException oce)
            {
                sw.Stop();
                throw new Exception($"请求异常-oce-{oce.Message} 耗时 {sw.ElapsedMilliseconds} ms\n请求地址：{url}，请求参数：{jsonStr}", oce); 
            }
            catch (Exception ex)
            {
                sw.Stop();
                throw new Exception($"请求异常-{ex.Message} 耗时 {sw.ElapsedMilliseconds} ms\n请求地址：{url}，请求参数：{jsonStr}", ex);
            }
        }
    }
}
