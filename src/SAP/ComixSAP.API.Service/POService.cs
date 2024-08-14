


namespace ComixSAP.API.Service
{
    public class POService
    {
        /// <summary>
        /// 回款业务接口
        /// </summary>
        public readonly static FIN.SapVouBLL SapVouService = new FIN.SapVouBLL();

        /// <summary>
        /// 创建客户调用接口
        /// </summary>
        public readonly static Customer.CreateCustomerBLL CreateCustomerService = new Customer.CreateCustomerBLL();

        /// <summary>
        /// 获取客户余额
        /// </summary>
        public readonly static FIN.CustomerBalanceBLL CustomerBalanceService = new FIN.CustomerBalanceBLL();

        /// <summary>
        /// 查询客户
        /// </summary>
        public readonly static Customer.QueryCustomerBLL QueryCustomerService = new Customer.QueryCustomerBLL();
        /// <summary>
        /// 同步CC分类到SAP
        /// </summary>
        public readonly static Product.SyncCategoriesToSAPBLL SyncCategoriesToSAPService = new Product.SyncCategoriesToSAPBLL();

        /// <summary>
        /// 日志接口
        /// </summary>
        public readonly static SAPLogService LogService = new SAPLogService();
    }

}
