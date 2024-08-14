using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.COS.SDK.Interfaces
{
    public interface ICOSProductService
    {
        COSResp<COSProductDetailRespData> GetMallProductDetail(COSMallProductDetailReq req);

        /// <summary>
        /// 官网商品搜素分页
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        COSResp<COSPageResultResp<COSProductSearchRespData>> SearchMallProduct(COSMallProductSearchReq req);

        /// <summary>
        /// 官网商品预搜素
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        COSResp<List<COSProductPreSearchRespData>> PreSearchMallProduct(COSMallProductPreSearchReq req);

        /// <summary>
        /// 商品AI去重搜索
        /// </summary>
        /// <param name="req">商品名称集合</param>
        /// <returns></returns>
        Task<RespApiCosMallProductsDupPathDto> ApiCosMallProductsDupPathAsync(ReqApiCosMallProductsDupPathDto req);

        /// <summary>
        /// 库存扣减
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<COSResp<string>> StockReduceAsync(List<CosStockRdduceReq> req);

        /// <summary>
        /// 库存实时查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        COSResp<List<RspCosQueryResult>> StockQueryAsync(List<CosStockQueryReq> req,TimeSpan timeout);
        /// <summary>
        /// 查询COS官网商品价格
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        List<RspCosMallProductsPriceDto> GetCosMallProdeuctsPrice(ReqCosMallProductsPriceDto req,TimeSpan timenout);

        /// <summary>
        /// 查询SSC商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<COSResp<COSPageResultResp<RspSSCProdcutListDto>>> GetSSCProdcutList(ReqSSCProdcutListDto req);
    }
}

