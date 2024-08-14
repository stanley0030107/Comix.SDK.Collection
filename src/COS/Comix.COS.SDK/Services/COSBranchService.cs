using System.Net.Http;
using System.Threading.Tasks;
using Comix.COS.Model.EventModels.CosCustomerBaseData;
using Comix.COS.Model.EventModels.CosMallBaseData;
using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Models;
using Microsoft.Extensions.Logging;

namespace Comix.COS.SDK.Services
{
    public class COSBranchService : ICOSBranchService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<COSBranchService> _logger;

        public COSBranchService(IHttpClientFactory httpClientFactory,
            ILogger<COSBranchService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public COSResp<COSPageResultResp<CosBranchPageDto>> GetBranchPage(
            COSQueryPageListReq<ReqCosBranchPageDto> req)
        {
            return GetBranchPageAsync(req).Result;
        }

        /// <summary>
        /// PMS合同复杂查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<COSResp<COSPageResultResp<CosBranchPageDto>>> GetBranchPageAsync(
            COSQueryPageListReq<ReqCosBranchPageDto> req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<COSPageResultResp<CosBranchPageDto>>>(_logger,
                COSRoute.COSQueryCategoryListPath, req);
            return resp;
        }

        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="brandCode">品牌编码</param>
        /// <returns></returns>
        public async Task<COSResp<CosBrandDto>> GetBrandAsync(string brandCode)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<CosBrandDto>>(_logger,
                COSRoute.SelectBrand, new { brandCode });
            return resp;
        }

        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="brand_id">cos品牌id</param>
        /// <returns></returns>
        public async Task<COSResp<CosBrandDto>> GetBrandByIDAsync(int brand_id)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<CosBrandDto>>(_logger,
                COSRoute.SelectBrand, new { brand_id= brand_id });
            return resp;
        }

        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="brandCode">品牌编码</param>
        /// <returns></returns>
        public COSResp<CosBrandDto> GetBrand(string brandCode)
        {
            return GetBrandAsync(brandCode).Result;
        }

        /// <summary>
        /// 获取项目品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="brandCode"></param>
        /// <returns></returns>
        public async Task<COSResp<CosCustomerBrandEventModel>> GetCustomerBrandAsync(string customerCode, string brandCode)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<CosCustomerBrandEventModel>>(_logger,
                COSRoute.SelectCustomerBrand, new { customerCode,brandCode });
            return resp;
        }

        /// <summary>
        /// 获取项目品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="brandCode"></param>
        /// <returns></returns>
        public COSResp<CosCustomerBrandEventModel> GetCustomerBrand(string customerCode, string brandCode)
        {
            return GetCustomerBrandAsync(customerCode, brandCode).Result;
        }
    }
}