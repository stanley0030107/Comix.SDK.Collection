using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Comix.COS.SDK.Services
{
    public class COSProductService : ICOSProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<COSProductService> _logger;

        public COSProductService(IHttpClientFactory httpClientFactory, ILogger<COSProductService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public COSResp<COSProductDetailRespData> GetMallProductDetail(COSMallProductDetailReq req)
        {
            return GetMallProductDetailAsync(req).Result;
        }

        public COSResp<COSPageResultResp<COSProductSearchRespData>> SearchMallProduct(COSMallProductSearchReq req)
        {
            return SearchMallProductAsync(req).Result;
        }

        public COSResp<List<COSProductPreSearchRespData>> PreSearchMallProduct(COSMallProductPreSearchReq req)
        {
            return PreSearchMallProductAsync(req).Result;
        }

        private async Task<COSResp<List<COSProductPreSearchRespData>>> PreSearchMallProductAsync(
            COSMallProductPreSearchReq req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<List<COSProductPreSearchRespData>>>(_logger,
                COSRoute.COSProductPreSearchPath, req);
            return resp;
        }

        private async Task<COSResp<COSProductDetailRespData>> GetMallProductDetailAsync(COSMallProductDetailReq req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<COSProductDetailRespData>>(_logger,
                COSRoute.COSProductDetailPath, req);
            return resp;
        }

        private async Task<COSResp<COSPageResultResp<COSProductSearchRespData>>> SearchMallProductAsync(
            COSMallProductSearchReq req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<COSPageResultResp<COSProductSearchRespData>>>(
                _logger, COSRoute.COSProductSearchPath, req);
            return resp;
        }

        /// <summary>
        /// 商品AI去重搜索
        /// </summary>
        /// <param name="req">商品名称集合</param>
        /// <returns></returns>
        public async Task<RespApiCosMallProductsDupPathDto> ApiCosMallProductsDupPathAsync(ReqApiCosMallProductsDupPathDto req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<RespApiCosMallProductsDupPathDto>(
                _logger, COSRoute.ApiCosMallProductsDupPath, req);
            return resp;
        }

        /// <summary>
        /// 库存扣减
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<COSResp<string>> StockReduceAsync(List<CosStockRdduceReq> req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<string>>(
                _logger, COSRoute.StockReduce, req);
            return resp;
        }

        /// <summary>
        /// 库存实时查询接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public COSResp<List<RspCosQueryResult>> StockQueryAsync(List<CosStockQueryReq> req, TimeSpan timeout)
        {
            var resp = _httpClientFactory.Execute<COSResp<List<RspCosQueryResult>>>(
                _logger, COSRoute.StockQuery, req, timeout);
            return resp;
        }
        /// <summary>
        /// 查询COS官网商品价格
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public List<RspCosMallProductsPriceDto> GetCosMallProdeuctsPrice(ReqCosMallProductsPriceDto req, TimeSpan timeout)
        {
            var resp = _httpClientFactory.Execute<List<RspCosMallProductsPriceDto>>(
                _logger, COSRoute.COSmallPrice, req, timeout);
            return resp;
        }

        /// <summary>
        /// 查询SSC商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<COSResp<COSPageResultResp<RspSSCProdcutListDto>>> GetSSCProdcutList(ReqSSCProdcutListDto req)
        {
            var resp = await _httpClientFactory.ExecuteAsync<COSResp<COSPageResultResp<RspSSCProdcutListDto>>>(
                _logger, COSRoute.SSCProdcutList, req);
            return resp;
        }
    }
}