using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
    /// <summary>
    /// COSMallProductSearchReq
    /// </summary>
    public class COSMallProductSearchReq
    {
        /// <summary>
        ///当前页码
        /// </summary>
        public int current { get; set; }

        /// <summary>
        /// 分页数量	
        /// </summary>
        public int size { get; set; }

        public COSMallProductSearchData data { get; set; }

    }

    /// <summary>
    /// COSMallProductSearchData
    /// </summary>
    public class COSMallProductSearchData
    {
        /// <summary>
        /// 分类平台类型,BASIC: 基础数据，例如基础分类、品牌、属性；MRO：MRO相关数据；
        /// CUSTOM：客户商品、分类，品牌，属性；MALL：官网数据；
        /// STANDARD：cos标准数据；SUPPLIER：cos服务商数据,可用值:BASIC,MRO,CUSTOM,MALL,STANDARD,SUPPLIER
        /// </summary>
        public string platformType { get; set; }

        /// <summary>
        /// 搜索关键词，使用场景：全局搜索，内容可包含商品id,code,商品、品牌，分类名称
        /// </summary>
        [JsonProperty(PropertyName = "keyword", NullValueHandling = NullValueHandling.Ignore)]
        public string keyword { get; set; }

        /// <summary>
        ///齐心分类Id
        /// </summary>
        [JsonProperty(PropertyName = "categoryIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> categoryIds { get; set; }

        /// <summary>
        /// 排序字段	
        /// </summary>
        [JsonProperty(PropertyName = "sortList", NullValueHandling = NullValueHandling.Ignore)]
        public List<COSMallProductSearchSortData> sortList { get; set; }

        /// <summary>
        /// 运营标签：BP：标品，HX：惠选，HC：慧采,可用值:BP,HX,HC
        /// </summary>
        [JsonProperty(PropertyName = "operationTag", NullValueHandling = NullValueHandling.Ignore)]
        public string operationTag { get; set; }

        /// <summary>
        /// 运营标签：BP：标品，HX：惠选，HC：慧采,可用值:BP,HX,HC
        /// </summary>
        [JsonProperty(PropertyName = "operationTags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> operationTags { get; set; }

        /// <summary>
        /// 起始价格	
        /// </summary>
        [JsonProperty(PropertyName = "mallPriceFrom", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? mallPriceFrom { get; set; }

        /// <summary>
        /// 结尾价格	
        /// </summary>
        [JsonProperty(PropertyName = "mallPriceTo", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? mallPriceTo { get; set; }
    }

    /// <summary>
    /// COSMallProductSearchSortData
    /// </summary>
    public class COSMallProductSearchSortData
    {
        /// <summary>
        /// 排序字段：createTime，updateTime
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// 排序方式,可用值:DEFAULT,ASC,DESC
        /// </summary>
        public string type { get; set; }
    }
}
