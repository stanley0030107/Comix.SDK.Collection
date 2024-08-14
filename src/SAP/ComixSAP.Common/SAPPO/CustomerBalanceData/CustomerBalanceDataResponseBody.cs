using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.CustomerBalanceData
{
    public class CustomerBalanceDataResponseBody
    {
        public int BUKRS { get; set; }
        public string KUNNR { get; set; }
        public int KKBER { get; set; }
        public string KLIMK { get; set; }
        public string SAUFT { get; set; }
        public decimal SKFOR { get; set; }
        public string CTLPC { get; set; }
        public string SSOBL { get; set; }
        public decimal OBLIG { get; set; }
        public decimal KLPRZ { get; set; }
        public string AMOUNT_H { get; set; }
        public string ZTERM { get; set; }
        public string VTEXT { get; set; }
        public string DMBTR { get; set; }
        public string DMBTR_7 { get; set; }
        public string DMBTR_15 { get; set; }
        public string DMBTR_NPD { get; set; }
        public string DCL_FYD { get; set; }
        public string CLZ_YD { get; set; }
        public string MSGTY { get; set; }
        public string MSGTX { get; set; }
        /// <summary>
        /// 临时额度
        /// </summary>
        public string ZRSV01 { get; set; }
        /// <summary>
        /// 临时额度有效期
        /// </summary>
        public string ZRSV02 { get; set; }

    }
}
