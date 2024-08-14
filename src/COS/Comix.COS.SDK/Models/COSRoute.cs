using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.SDK.Models
{
   public class COSRoute
    { 
        /// <summary>
        /// 分页获取品牌列表
        /// </summary>
        public static string COSQueryBranchListPath = "/imc/manage/brand/page";
        /// <summary>
        /// 分页获取分类列表
        /// </summary>
        public static string COSQueryCategoryListPath = "/imc/buyer/category/page";
        /// <summary>
        /// 图片搜索
        /// </summary>
        public static string COSImageSearchPath = "/cos-xmt/buyer/imageSearch";
        /// <summary>
        /// 商城接口：查询商品详情
        /// </summary>
        public static string COSProductDetailPath = "/imc/buyer/item/detail";

        /// <summary>
        /// 商城接口：商城商品主搜接口，支持客户合约、官网商品搜索
        /// </summary>
        public static string COSProductSearchPath = "/imc/buyer/item/search";

        /// <summary>
        /// 商城接口：商城商品预搜索接口
        /// </summary>
        public static string COSProductPreSearchPath = "/imc/buyer/item/preSearch";


        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        public static string SelectBrand = "/pcm/v1/cdp/selectBrand";

        /// <summary>
        /// 获取项目品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        public static string SelectCustomerBrand = "/pcm/v1/cdp/selectCustomerBrand";


        /// <summary>
        /// 获取官网品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        public static string SelectCategory = "/pcm/v1/cdp/selectCategory";

        /// <summary>
        /// 获取项目品牌信息
        /// 返回与消息体一样的数据结构
        /// </summary>
        public static string SelectCustomerCategory = "/pcm/v1/cdp/selectCustomerCategory";
        
        /// <summary>
        /// 查询或新增物料
        /// </summary>
        public static string Mdm ="/pcm/v1/o2oApi/o2o/MDM";

        /// <summary>
        /// 商品AI去重搜索
        /// </summary>
        public static string ApiCosMallProductsDupPath = "/pcm/v1/api/cos-mall-products/dup";

        /// <summary>
        /// 查询COS服务化消息数据
        /// </summary>
        public static string ApiCosMessagePacketList = "/pcm/v1/api/cos-customer-products/message-packet-list";

        /// <summary>
        /// 库存扣减接口
        /// </summary>
        public static string StockReduce = "/pcm/v1/0/cos-stock-facade/stock-reduce";

        /// <summary>
        /// 库存实时查询接口
        /// </summary>
        public static string StockQuery = "/pcm/v1/0/cos-stock-facade/stock-query";

        /// <summary>
        /// 查询官网商品价格
        /// </summary>
        public static string COSmallPrice = "/imc/v1/api/cos-mall-products/mall-price";

        /// <summary>
        /// 查询SSC商品信息
        /// </summary>
        public static string SSCProdcutList = "/product-agg/isc-product/ssc-product-list";
    }
}
