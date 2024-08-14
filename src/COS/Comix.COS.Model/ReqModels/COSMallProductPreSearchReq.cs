using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
    public class COSMallProductPreSearchReq
    {
        /// <summary>
        /// 分类平台类型,BASIC: 基础数据，例如基础分类、品牌、属性；MRO：MRO相关数据；CUSTOM：客户商品、分类，品牌，属性
        /// ；MALL：官网数据；STANDARD：cos标准数据；SUPPLIER：cos服务商数据,可用值:BASIC,MRO,CUSTOM,MALL,STANDARD,SUPPLIER
        /// </summary>
        public string platformType { get; set; }

        /// <summary>
        /// 关键词	
        /// </summary>
        public string keyword { get; set; }
    }
}
