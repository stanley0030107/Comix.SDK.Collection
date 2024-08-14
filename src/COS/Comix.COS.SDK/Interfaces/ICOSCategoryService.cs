using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Comix.COS.Model.EventModels.CosCustomerBaseData;
using Comix.COS.Model.EventModels.CosMallBaseData;
using Comix.COS.Model.EventModels.CosMallProduct;

namespace Comix.COS.SDK.Interfaces
{
    public interface ICOSCategoryService
    {
        /// <summary>
        /// 获取COS类目数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        COSResp<COSPageResultResp<COSCategoryResp>> GetCategoryList(
            COSQueryPageListReq<COSQueryCategoryListDataReq> req);

        Task<COSResp<COSPageResultResp<COSCategoryResp>>> GetCategoryListAsync(
            COSQueryPageListReq<COSQueryCategoryListDataReq> req);

        /// <summary>
        /// 获取官网分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="categoryCode">品牌编码</param>
        /// <returns></returns>
        Task<COSResp<CosBaseDataBody>> GetCategoryAsync(string categoryCode);

        /// <summary>
        /// 获取官网分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="categoryCode">品牌编码</param>
        /// <returns></returns>
        COSResp<CosBaseDataBody> GetCategory(string categoryCode);

        /// <summary>
        /// 获取项目分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        Task<COSResp<List<CosCustomerCategoryEventModel>>> GetCustomerCategoryAsync(string customerCode,
            string categoryCode);

        /// <summary>
        /// 获取项目分类信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        COSResp<List<CosCustomerCategoryEventModel>> GetCustomerCategory(string customerCode, string categoryCode);
    }
}