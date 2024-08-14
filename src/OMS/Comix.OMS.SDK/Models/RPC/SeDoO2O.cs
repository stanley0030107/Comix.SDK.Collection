using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OMS.SDK.Models.RPC
{
    /// <summary>
    /// O2O、ISC 查询交货单
    /// </summary>
    public class SeDoO2O
    {
        /// <summary>
        /// sap交货单号
        /// </summary>
        public string DeliveryNo { get; set; }

        /// <summary>
        /// LINK单号
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 采购平台订单号
        /// </summary>
        public string PxOrderId { get; set; }

        /// <summary>
        /// 集采客户编号
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// sap销售订单号
        /// </summary>
        public string SapBillNo { get; set; }

        /// <summary>
        /// 过账状态
        /// </summary>
        public string SAPBillStatus { get; set; }

        /// <summary>
        /// 过账金额
        /// </summary>
        public decimal TotalTaxAmount { get; set; }
        /// <summary>
        /// 销售单号
        /// </summary>
        public string SeOrderBillNo { get; set; }
    }
}
