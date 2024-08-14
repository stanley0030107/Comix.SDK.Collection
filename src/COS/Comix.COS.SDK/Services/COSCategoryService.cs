using System.Collections.Generic;
using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using Comix.COS.Model.EventModels.CosCustomerBaseData;
using Comix.COS.Model.EventModels.CosMallBaseData;
using Comix.COS.Model.EventModels.CosMallProduct;

namespace Comix.COS.SDK.Services
{
    public class COSCategoryService : ICOSCategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<COSCategoryService> _logger;

        public COSCategoryService(IHttpClientFactory httpClientFactory, ILogger<COSCategoryService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public COSResp<COSPageResultResp<COSCategoryResp>> GetCategoryList(
            COSQueryPageListReq<COSQueryCategoryListDataReq> req)
        {
            return GetCategoryListAsync(req).Result;
        }

        /// <summary>
        /// PMS合同复杂查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<COSResp<COSPageResultResp<COSCategoryResp>>> GetCategoryListAsync(
            COSQueryPageListReq<COSQueryCategoryListDataReq> req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<COSPageResultResp<COSCategoryResp>>>(_logger,
                COSRoute.COSQueryCategoryListPath, req);
            return resp;
        }

        /// <summary>
        /// 获取官网分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="categoryCode">品牌编码</param>
        /// <returns></returns>
        public async Task<COSResp<CosBaseDataBody>> GetCategoryAsync(string categoryCode)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<CosBaseDataBody>>(_logger,
                COSRoute.SelectCategory, new { categoryCode });
            return resp;
        }

        /// <summary>
        /// 获取官网分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="categoryCode">品牌编码</param>
        /// <returns></returns>
        public COSResp<CosBaseDataBody> GetCategory(string categoryCode)
        {
            return GetCategoryAsync(categoryCode).Result;
        }

        /// <summary>
        /// 获取项目分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public async Task<COSResp<List<CosCustomerCategoryEventModel>>> GetCustomerCategoryAsync(string customerCode,
            string categoryCode)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<List<CosCustomerCategoryEventModel>>>(_logger,
                COSRoute.SelectCustomerCategory, new { customerCode, categoryCode });
            return resp;
        }

        /// <summary>
        /// 获取项目分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public COSResp<List<CosCustomerCategoryEventModel>> GetCustomerCategory(string customerCode, string categoryCode)
        {
            return GetCustomerCategoryAsync(customerCode, categoryCode).Result;
        }
    }
}