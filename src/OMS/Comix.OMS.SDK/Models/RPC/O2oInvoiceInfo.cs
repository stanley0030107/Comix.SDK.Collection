namespace Comix.OMS.SDK.Models.RPC;

    /// <summary>
    /// O2O服务商发票信息
    /// </summary>
    public class O2oInvoiceInfo
    {

        #region 属性
        /// <summary>
        /// 序号
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 集团编码
        /// </summary>
        public string CustomerCode
        {
            get;
            set;
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public virtual string OrderCode
        {
            get;
            set;
        }
        /// <summary>
        /// 发货单号
        /// </summary>
        public string DeliveryNo
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime
        {
            get;
            set;
        }

        /// <summary>
        /// 是否需要上传采购合同
        /// </summary>
        public string IsUploadContract
        {
            get;
            set;
        }

        /// <summary>
        /// 发票类型
        /// </summary>
        public string InvoiceType
        {
            get;
            set;
        }

        /// <summary>
        /// 发票抬头
        /// </summary>
        public string InvoiceTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 纳税人识别号
        /// </summary>
        public string TaxNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 注册电话
        /// </summary>
        public string RegisteredPhone
        {
            get;
            set;
        }

        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisteredAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 开户行名称
        /// </summary>
        public string BankName
        {
            get;
            set;
        }

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 收票人姓名
        /// </summary>
        public string ConsigneeName
        {
            get;
            set;
        }

        /// <summary>
        /// 收票人电话
        /// </summary>
        public string ConsigneePhone
        {
            get;
            set;
        }

        /// <summary>
        /// 收票人地址
        /// </summary>
        public string ConsigneeAddress
        {
            get;
            set;
        }
        #endregion
    }