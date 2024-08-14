using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComixSAP.Common.SAPPO.ReturnMoney
{

    public class ReturnMoneyResponseBody
    {
        public string KUNNR { get; set; }
        public int HKONT { get; set; }
        public string DMBTR { get; set; }
        public string MSGTY { get; set; }
        public string MSGTX { get; set; }
    }


}
