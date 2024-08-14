using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models
{
    public class SapVouResquestBody
    {
        /// <summary>
        /// 
        /// </summary>
        public string MSGID { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZKUBUN { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZFLAG_C { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BLART { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BUKRS { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BELNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int GJAHR { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public int MONAT { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string BLDAT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string BUDAT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string WAERS { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public decimal KURSF { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public string BKTXT { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string XBLNR { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string USERNAME { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV01 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV02 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV03 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV04 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string ZRSV05 { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public List<SapVouItem> Items { get; set; }
    }
}
