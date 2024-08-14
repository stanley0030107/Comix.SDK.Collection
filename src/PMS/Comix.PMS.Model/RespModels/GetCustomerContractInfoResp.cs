using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.Model.RespModels
{
    /// <summary>
    /// 合同单条查询返回参数
    /// </summary>
    public class GetCustomerContractInfoResp
    {
        public string projectCode { get; set; }
        public int contractProjectCode { get; set; }
        public string contractCode { get; set; }
        public string collectPlatformFees { get; set; }
        public string feeRules { get; set; }
        public string feeBase { get; set; }
        public string platformFeePoints { get; set; }
        public string serviceEmail { get; set; }
    }
}
