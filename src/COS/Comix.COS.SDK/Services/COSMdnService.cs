using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Models;
using Microsoft.Extensions.Logging;

namespace Comix.COS.SDK.Services
{
    public class COSMdnService : ICOSMdnService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<COSMdnService> _logger;

        public COSMdnService(IHttpClientFactory httpClientFactory, ILogger<COSMdnService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        
        /// <summary>
        /// 查询或新增物料
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CosResponseDto<List<CosResponse2Dto<QuerySapCodeOutput>>> QuerySapCode(QuerySapCodeInput req)
        {
            return QuerySapCodeAsync(req).Result;
        }
        
        /// <summary>
        /// 查询或新增物料
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<CosResponseDto<List<CosResponse2Dto<QuerySapCodeOutput>>>> QuerySapCodeAsync(QuerySapCodeInput req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<CosResponseDto<List<CosResponse2Dto<QuerySapCodeOutput>>>>(_logger,
                COSRoute.Mdm, req);
            return resp;
        }
    }
}