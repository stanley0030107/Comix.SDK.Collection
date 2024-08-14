using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
    /// <summary>
    /// COSProductSearchData
    /// </summary>
    public class COSProductSearchRespData
    {
        /// <summary>
        /// 项目商品Id	
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
        public int? customerId { get; set; }

        /// <summary>
        /// 客户编码	
        /// </summary>
        public string customerCode { get; set; }

        /// <summary>
        /// 商品全称	
        /// </summary>
        public string productName { get; set; }

        /// <summary>
        /// 高亮商品名称	
        /// </summary>
        public string highlightProductName { get; set; }

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
    }
}
