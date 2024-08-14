using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
    public class COSMallProductDetailReq
    {
        /// <summary>
        /// MALL 代表查询官网商品
        /// </summary>
        public string platformType { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public string productCode { get; set; }
    }

}
