using System.Threading.Tasks;
using Comix.COS.Model.EventModels.CosCustomerBaseData;
using Comix.COS.Model.EventModels.CosMallBaseData;
using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;

namespace Comix.COS.SDK.Interfaces
{
    public interface ICOSBranchService
    {
        COSResp<COSPageResultResp<CosBranchPageDto>> GetBranchPage(COSQueryPageListReq<ReqCosBranchPageDto> req);

        /// <summary>
        /// PMS合同复杂查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<COSResp<COSPageResultResp<CosBranchPageDto>>> GetBranchPageAsync(COSQueryPageListReq<ReqCosBranchPageDto> req);
        
        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="brandCode">品牌编码</param>
        /// <returns></returns>
        Task<COSResp<CosBrandDto>> GetBrandAsync(string brandCode);
        Task<COSResp<CosBrandDto>> GetBrandByIDAsync(int brand_id);
        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="brandCode">品牌编码</param>
        /// <returns></returns>
        COSResp<CosBrandDto> GetBrand(string brandCode);


        /// <summary>
        /// 获取项目品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="brandCode"></param>
        /// <returns></returns>
        Task<COSResp<CosCustomerBrandEventModel>> GetCustomerBrandAsync(string customerCode, string brandCode);

        /// <summary>
        /// 获取项目品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="brandCode"></param>
        /// <returns></returns>
        COSResp<CosCustomerBrandEventModel> GetCustomerBrand(string customerCode, string brandCode);
    }
}