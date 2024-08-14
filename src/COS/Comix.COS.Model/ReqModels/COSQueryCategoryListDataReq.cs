using Newtonsoft.Json;
using System.Collections.Generic;

namespace Comix.COS.Model.ReqModels
{
    public class COSQueryCategoryListDataReq
    {
        /// <summary>
        /// 分类平台类型,BASIC: 基础数据，例如基础分类、品牌、属性；MRO：MRO相关数据；CUSTOM：客户商品、分类，品牌，属性；
        /// MALL：官网数据；STANDARD：cos标准数据；SUPPLIER：cos服务商数据,可用值:BASIC,MRO,CUSTOM,MALL,STANDARD,SUPPLIER
        /// </summary>
        [JsonProperty("platformType")]
        public string PlatformType { get; set; }

        ///// <summary>
        ///// 客户Id	
        ///// </summary>
        //[JsonProperty("customerId")]
        //public int CustomerId { get; set; }

        ///// <summary>
        ///// 客户编码	
        ///// </summary>
        //[JsonProperty("customerCode")]
        //public string CustomerCode { get; set; }

        ///// <summary>
        ///// 排序字段	
        ///// </summary>
        //[JsonProperty("sortList")]
        //public List<COSSortReq> SortList { get; set; }

        ///// <summary>
        ///// 分类状态	
        ///// </summary>
        //[JsonProperty("categoryStatus")]
        //public string CategoryStatus { get; set; }

        ///// <summary>
        ///// 分类级别	
        ///// </summary>
        //[JsonProperty("categoryLevel")]
        //public int CategoryLevel { get; set; }

        /// <summary>
        /// 齐心分类Id	
        /// </summary>
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        ///// <summary>
        ///// 齐心分类名称	
        ///// </summary>
        //[JsonProperty("categoryName")]
        //public string CategoryName { get; set; }

        ///// <summary>
        ///// 类别编码	
        ///// </summary>
        //[JsonProperty("categoryCode")]
        //public string CategoryCode { get; set; }

        /// <summary>
        /// 1 办公分类 2 Mro分类	
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
