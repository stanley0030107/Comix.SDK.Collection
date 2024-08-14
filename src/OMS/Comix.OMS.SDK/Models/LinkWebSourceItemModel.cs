namespace Comix.OMS.SDK.Models
{
    [Serializable]
    public class LinkWebSourceItemModel
    {
        private string _SourceBillNo;
        /// <summary>
        /// 合约订单编号
        /// </summary>
        public string SourceBillNo
        {
            get { return _SourceBillNo; }
            set { _SourceBillNo = value; }
        }
        private string _ItemNo;
        /// <summary>
        /// 商品序号
        /// </summary>
        public string ItemNo
        {
            get { return _ItemNo; }
            set { _ItemNo = value; }
        }
        private string _ProdCode;
        /// <summary>
        /// 物料编码(SKU)
        /// </summary>
        public string ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }
        /*
         * 新增物料名称
         * Add by Hing.Wu
         * Add date:2016-06-08
         */
        private string _ProdName;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string ProdName
        {
            get { return _ProdName; }
            set { _ProdName = value; }
        }

        private decimal _PCSQty;
        /// <summary>
        /// PCS数量
        /// </summary>
        public decimal PCSQty
        {
            get { return _PCSQty; }
            set { _PCSQty = value; }
        }
        private decimal _Price;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        private decimal _PxPrice;
        /// <summary>
        /// 平台结算价
        /// </summary>
        public decimal PxPrice
        {
            get { return _PxPrice; }
            set { _PxPrice = value; }
        }

        private decimal _TaxPrice;
        /// <summary>
        /// 商品税价
        /// </summary>
        public decimal TaxPrice
        {
            get { return _TaxPrice; }
            set { _TaxPrice = value; }
        }

        private decimal _NakedPrice;
        /// <summary>
        /// 商品裸价
        /// </summary>
        public decimal NakedPrice
        {
            get { return _NakedPrice; }
            set { _NakedPrice = value; }
        }

        /// <summary>
        /// 价格类型
        /// </summary>
        /// 1:含税；2:不含税
        private string _priceType = "1";
        public string priceType
        {
            get { return _priceType; }
            set { _priceType = value; }
        }

        /// <summary>
        /// 商品总金额
        /// </summary>
        /// 当“价格类型”为含税("1")时，含税总价=商品销售单价*商品数量；当“价格类型”为不含税("2")时，含税总价=商品裸价*(1+税率)*商品数量。保留2位小数。
        private decimal _totalPrice = 0;
        public decimal totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        /// <summary>
        /// 总税额
        /// </summary>
        /// 总税额=商品裸价*税率*商品数量。保留2位小数。
        private decimal _totalTaxPrice = 0;
        public decimal totalTaxPrice
        {
            get { return _totalTaxPrice; }
            set { _totalTaxPrice = value; }
        }

        /// <summary>
        /// 不含税总价
        /// </summary>
        /// 不含税总价=商品裸价*商品数量。
        private decimal _totalNakedPrice = 0;
        public decimal totalNakedPrice
        {
            get { return _totalNakedPrice; }
            set { _totalNakedPrice = value; }
        }
        /// <summary>
        /// 是否虚拟物料
        /// </summary>
        private bool _IsDummyCode;
        public bool IsDummyCode
        {
            get { return _IsDummyCode; }
            set { _IsDummyCode = value; }
        }

        /// <summary>
        /// 原订单号
        /// </summary>
        private string _FromSourceBillNo;
        public string FromSourceBillNo
        {
            get { return _FromSourceBillNo; }
            set { _FromSourceBillNo = value; }
        }

        /// <summary>
        /// 开票名称
        /// </summary>
        private string _InvoiceName;
        public string InvoiceName
        {
            get { return _InvoiceName; }
            set { _InvoiceName = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public Int64 SNo { get; set; }

        /// <summary>
        /// 定制商品标识
        /// </summary>
        public string specType { get; set; }

        /// <summary>
        /// 定制商品供货周期
        /// </summary>
        public string specTypeDate { get; set; }

        /// <summary>
        /// 定制商品详细描述
        /// </summary>
        public string specTypeDetail { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public string productType { get; set; }

        /// <summary>
        /// 积分金额
        /// </summary>
        public decimal? IntegralPrice { get; set; }

        /// <summary>
        /// 现金单价
        /// </summary>
        public decimal? CashPrice { get; set; }

        /// <summary>
        /// 商城编码
        /// </summary>
        public string SkuCode { get; set; }
        /// <summary>
        /// 合约商品编码
        /// </summary>
        public string CustomerSkuCode { get; set; }

        /// <summary>
        /// 合约商品名称
        /// </summary>
        public string CustomerSkuName { get; set; }
        /// <summary>
        /// 物料采购价
        /// </summary>
        public string WlCgPrice { get; set; }

        /// <summary>
        /// SAP供应商主数据编码
        /// </summary>
        public string SRMDistributor { get; set; }

        /// <summary>
        /// 开票单位，2024-7-3新增 BTC-45088
        /// </summary>
        public string InvoiceUnit { get; set; }
        /// <summary>
        /// 开票规格型号，2024-7-3新增  BTC-45088
        /// </summary>
        public string InvoiceModelNumber { get; set; }
    }
}
