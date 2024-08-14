namespace Comix.OMS.SDK.Models
{
    [Serializable]
    public class LinkWebSourceInvoiceInfoModel
    {
        private string _sourceBillNo = "";
        /// <summary>
        /// 合约订单编号
        /// </summary>
        public string SourceBillNo
        {
            get { return _sourceBillNo; }
            set { _sourceBillNo = value; }
        }
        private string _InvoiceType = "";
        /// <summary>
        /// 发票类型
        /// </summary>
        public string InvoiceType
        {
            get { return _InvoiceType; }
            set { _InvoiceType = value; }
        }
        private string _InvoiceTitle = "";
        /// <summary>
        ///发票抬头
        /// </summary>
        public string InvoiceTitle
        {
            get { return _InvoiceTitle; }
            set { _InvoiceTitle = value; }
        }
        private string _InvoiceContent = "";
        /// <summary>
        ///发票内容
        /// </summary>
        public string InvoiceContent
        {
            get { return _InvoiceContent; }
            set { _InvoiceContent = value; }
        }
        private string _Receiver = "";
        /// <summary>
        ///收票人姓名
        /// </summary>
        public string Receiver
        {
            get { return _Receiver; }
            set { _Receiver = value; }
        }
        private string _RecMobile = "";
        /// <summary>
        ///收票人手机号
        /// </summary>
        public string RecMobile
        {
            get { return _RecMobile; }
            set { _RecMobile = value; }
        }

        private string _RegistPhone = "";
        /// <summary>
        /// 注册号码
        /// </summary>
        public string RegistPhone
        {
            get { return _RegistPhone; }
            set { _RegistPhone = value; }
        }


        private string _invoiceState = "";

        /// <summary>
        /// 发票状态
        /// </summary>
        public string InvoiceState
        {
            get { return _invoiceState; }
            set { _invoiceState = value; }
        }


        private string _invoiceOrgCode;
        /// <summary>
        /// 纳税人识别号
        /// </summary>
        public string InvoiceOrgCode
        {
            get { return _invoiceOrgCode; }
            set { _invoiceOrgCode = value; }
        }

        private string _invoiceBankCode;
        /// <summary>
        /// 开户行帐号
        /// </summary>
        public string InvoiceBankCode
        {
            get { return _invoiceBankCode; }
            set { _invoiceBankCode = value; }
        }

        private string _invoiceBankName;
        /// <summary>
        /// 开户银行
        /// </summary>
        public string InvoiceBankName
        {
            get { return _invoiceBankName; }
            set { _invoiceBankName = value; }
        }


        private string _invoiceAddress;
        /// <summary>
        /// 注册地址
        /// </summary>
        public string InvoiceAddress
        {
            get { return _invoiceAddress; }
            set { _invoiceAddress = value; }
        }

        /// <summary>
        /// 收票地址
        /// </summary>
        public string BillToAddress { get; set; }
    }
}
