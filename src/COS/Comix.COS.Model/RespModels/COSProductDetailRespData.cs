using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
    public class COSProductDetailRespData
    {
        /// <summary>
        /// 	项目商品Id
        /// </summary>
        public int? customProductId { get; set; }

        /// <summary>
        /// 项目商品编码	
        /// </summary>
        public string customProductCode { get; set; }

        /// <summary>
        /// mro商品Id
        /// </summary>
        public int? mroProductId { get; set; }

        /// <summary>
        /// mro商品编码	
        /// </summary>
        public string mroProductCode { get; set; }

        /// <summary>
        /// 官网商品Id	
        /// </summary>
        public int? mallProductId { get; set; }

        /// <summary>
        /// 官网商品编码	
        /// </summary>
        public string mallProductCode { get; set; }

        /// <summary>
        /// 物料编码	
        /// </summary>
        public string materialCode { get; set; }

        /// <summary>
        /// 客户Id	
        /// </summary>
        public string customerId { get; set; }

        /// <summary>
        /// 客户编码	
        /// </summary>
        public string customerCode { get; set; }

        /// <summary>
        /// 商品全称	
        /// </summary>
        public string productName { get; set; }

        /// <summary>
        /// 通用名称	
        /// </summary>
        public string shortName { get; set; }

        /// <summary>
        /// 齐心品牌ID	
        /// </summary>
        public int? brandId { get; set; }

        /// <summary>
        /// 齐心品牌名称	
        /// </summary>
        public string brandName { get; set; }

        /// <summary>
        /// 齐心分类Id,叶子类目Id
        /// </summary>
        public int? categoryId { get; set; }

        /// <summary>
        /// 齐心分类名称
        /// </summary>
        public string categoryName { get; set; }

        /// <summary>
        /// 售价	
        /// </summary>
        public decimal salePrice { get; set; }

        /// <summary>
        /// 列表缩略图	
        /// </summary>
        public string imageUrl { get; set; }

        /// <summary>
        /// 运营标签：10：标品，30：惠选，40：慧采,可用值:BP,HX,HC
        /// </summary>
        public string operationTag { get; set; }

        /// <summary>
        /// 商品状态,可用值:PENDING,ON,OFF,OFFING,ONING,WAITING,NO_SHELF,DELETE
        /// </summary>
        public string shelfStatus { get; set; }

        /// <summary>
        /// 商品状态含义
        /// </summary>
        public string shelfStatusMean { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int stock { get; set; }

        /// <summary>
        /// 结算价	
        /// </summary>
        public decimal settlePrice { get; set; }


        /// <summary>
        /// 最小起订量	
        /// </summary>
        public int? minOrderQuantity { get; set; }

        /// <summary>
        /// 商品型号	
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// 最小包装量
        /// </summary>
        public int sau { get; set; } 

        /// <summary>
        /// 是否可以单独购买
        /// </summary>
        public bool isSingleBuy { get; set; }

        /// <summary>
        /// 分类信息	
        /// </summary>
        public List<COSProductCategory> categoryList { get; set; }

        /// <summary>
        /// 属性详情	
        /// </summary>
        public List<COSProductAttr> attrList { get; set; }

        /// <summary>
        /// 主图列表	
        /// </summary>
        public List<string> mainPicList { get; set; }

        /// <summary>
        /// 图文详情列表	
        /// </summary>
        public List<string> detailPicList { get; set; }

    }

    public class COSProductCategory
    {
        /// <summary>
        /// 客户分类Id	
        /// </summary>
        public int? customerCategoryId { get; set; }

        /// <summary>
        /// 齐心分类Id或Id集合	
        /// </summary>
        public int? categoryId { get; set; }

        /// <summary>
        /// 齐心分类名称	
        /// </summary>
        public string categoryName { get; set; }

        /// <summary>
        /// 类别编码	
        /// </summary>
        public string categoryCode { get; set; }

        /// <summary>
        /// 分类图片地址	
        /// </summary>
        public string imageUrl { get; set; }

        /// <summary>
        /// 分类级别	
        /// </summary>
        public int? categoryLevel { get; set; }
    }

    public class COSProductAttr
    {
        /// <summary>
        /// 属性id	
        /// </summary>
        public int? attributeId { get; set; }

        /// <summary>
        /// 属性编码	
        /// </summary>
        public string attributeCode { get; set; }

        /// <summary>
        /// 属性名称	
        /// </summary>
        public string attributeName { get; set; }

        /// <summary>
        /// 属性值id	
        /// </summary>
        public int? attributeValueId { get; set; }

        /// <summary>
        /// 属性值编码	
        /// </summary>
        public string attributeValueCode { get; set; }

        /// <summary>
        /// 属性值	
        /// </summary>
        public string attributeValue { get; set; }
    }
}
