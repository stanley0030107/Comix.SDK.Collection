


namespace ComixSAP.API.Service
{
    public class RpcService
    {
        /// <summary>
        /// 供应商模糊查询
        /// </summary>
        public readonly static RPC.QueryDistributorBLL QueryDistributorService = new RPC.QueryDistributorBLL();

        /// <summary>
        ///  发票数据查询
        /// </summary>
        public readonly static RPC.QueryOmsInvoiceBLL QueryOmsInvoiceService = new RPC.QueryOmsInvoiceBLL();

    }

}
