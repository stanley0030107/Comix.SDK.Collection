using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    public class SapVouResponseBody
    {
        /// <summary>
        /// 
        /// </summary>
        public string MSGID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BUKRS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BELNR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GJAHR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MSGTY { get; set; }
        /// <summary>
        /// 过账成功
        /// </summary>
        public string MSGTX { get; set; }

    }
}
