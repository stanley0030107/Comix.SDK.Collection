using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models.RPC
{
    public class RespTSeOrderPageDto
    {
        /// <summary>
        /// LINK单号
        /// </summary>
        public string SourceBillNo { get; set; }
        /// <summary>
        /// Sap订单号
        /// </summary>
        public string SAPBillNo { get; set; }
        /// <summary>
        /// 采购单号
        /// </summary>
        public string SapPoBillNo { get; set; }
        /// <summary>
        /// 采购单含税金额
        /// </summary>
        public decimal? PoOrderTaxAmount { get; set; }
        /// <summary>
        /// 服务商采购折扣点
        /// </summary>
        public decimal? PurchasePoint { get; set; }
    }
}
