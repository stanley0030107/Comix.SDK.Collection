using System.Collections.Generic;
using Newtonsoft.Json;

namespace Comix.COS.Model.ReqModels
{
    public class ReqCosBranchPageDto
    {
        /// <summary>
        /// 分类平台类型
        /// <example>
        /// BASIC: 基础数据，例如基础分类、品牌、属性；
        /// </example>
        /// <example>
        /// MRO：MRO相关数据；
        /// </example>
        /// <example>
        /// CUSTOM：客户商品、分类，品牌，属性；
        /// </example>
        /// <example>
        /// STANDARD：cos标准数据；
        /// </example>
        /// <example>
        /// SUPPLIER：cos服务商数据
        /// </example>
        /// </summary>
        public string platformType { get; set; }

        /// <summary>
        /// 客户Id
        /// </summary>
        public int? customerId { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string customerCode { get; set; }

        /// <summary>
        /// 齐心品牌编码
        /// </summary>
        public string brandCode { get; set; }

        /// <summary>
        /// 齐心品牌名称
        /// </summary>
        public string brandName { get; set; }

        /// <summary>
        /// 创建起始时间
        /// </summary>
        public string creationDateFrom { get; set; }

        /// <summary>
        /// 创建截止时间
        /// </summary>
        public string creationDateTo { get; set; }

        /// <summary>
        /// 资质文件类型
        /// </summary>
        public string qualificationType { get; set; }

        /// <summary>
        /// 品牌id集合
        /// </summary>
        public List<int> brandIds { get; set; }

        /// <summary>
        /// 品牌编码集合
        /// </summary>
        public List<string> brandCodes { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public int? successStatus { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? brandStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? controlType { get; set; }

        /// <summary>
        /// 排序字段	
        /// </summary>
        [JsonProperty(PropertyName = "sortList", NullValueHandling = NullValueHandling.Ignore)]
        public List<COSMallProductSearchSortData> sortList { get; set; }
    }
}