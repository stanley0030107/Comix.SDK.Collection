using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CustomerBalanceData
{
    public class CustomerBalanceDataResquestBody
    {
        /// <summary>
        /// 售达方:客编
        /// </summary>
        public string PARTNER { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string BUKRS { get; set; } = "1100";
        public string CREDIT_SGMNT { get; set; }
        public string ZRSV01 { get; set; }
        public string ZRSV02 { get; set; }
        public string ZRSV03 { get; set; }
        public string ZRSV04 { get; set; }
        public string ZRSV05 { get; set; }
    }
}
