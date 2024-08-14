using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comix.COS.SDK.Services
{
    public class COSImageSearchService : ICOSImageSearchService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<COSImageSearchService> _logger;

        public COSImageSearchService(IHttpClientFactory httpClientFactory, ILogger<COSImageSearchService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        public COSImageSearchResp ImageSearch(COSImageSearchReq req)
        {
            return ImageSearchAsync(req).Result;
        }
        public async Task<COSImageSearchResp> ImageSearchAsync(COSImageSearchReq req)
        {
            var resp = await ExecuteAsync<COSImageSearchResp>(COSRoute.COSImageSearchPath, req);
            return resp;
        }
        #region 基础封装
        /// <summary>
        /// 执行post请求
        /// </summary>
        private async Task<T> ExecuteAsync<T>(string path, COSImageSearchReq req)
        {
            var resultStr = await ExecuteReturnStringAsync(path, req);
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 执行post请求
        /// </summary>
        private async Task<string> ExecuteReturnStringAsync(string path, COSImageSearchReq req)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new ByteArrayContent(req.productImage), "productImage", Guid.NewGuid().ToString("N")); 
            var client = _httpClientFactory.CreateClient();
            if (COSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }
            var url = $"{COSOptions.Url}{path}";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var response = client.PostAsync(url, formData).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                return "";
            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"pms请求：{url}\n请求参数：productImage\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}
