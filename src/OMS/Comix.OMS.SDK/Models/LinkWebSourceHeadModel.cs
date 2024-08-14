namespace Comix.OMS.SDK.Models
{
    [Serializable]
    public class LinkWebSourceHeadModel
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
        private string _trade_no = string.Empty;
        /// <summary>
        /// 旺店通仓库TR单号  trade_no
        /// </summary>
        public string trade_no
        {
            get { return this._trade_no; }
            set { this._trade_no = value; }
        }
        private string _WdtWarehouseNo = string.Empty;
        /// <summary>
        /// 旺店通仓库编号  
        /// </summary>
        public string WdtWarehouseNo
        {
            get { return this._WdtWarehouseNo; }
            set { this._WdtWarehouseNo = value; }
        }
        private string _PxOrderId;
        /// <summary>
        /// 采购平台订单号
        /// </summary>
        public string PxOrderId
        {
            get { return _PxOrderId; }
            set { _PxOrderId = value; }
        }
        private string _SoldToCustCode;
        /// <summary>
        /// 售达方编号
        /// </summary>
        public string SoldToCustCode
        {
            get { return _SoldToCustCode; }
            set { _SoldToCustCode = value; }
        }
        private string _ShipToCustCode;
        /// <summary>
        /// 送达方编号
        /// </summary>
        public string ShipToCustCode
        {
            get { return _ShipToCustCode; }
            set { _ShipToCustCode = value; }
        }
        
        public string DistValiDateEnd { get; set; }

        public string ContractNo { get; set; }

        public string BusinessMan { get; set; }

        public string BusinessManCode { get; set; }
        private string _CustomerName;
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        private bool _IsEmergency;
        /// <summary>
        /// 是否紧急订单
        /// </summary>
        public bool IsEmergency
        {
            get { return _IsEmergency; }
            set { _IsEmergency = value; }
        }
        private string _BatchId;
        /// <summary>
        /// 紧急单批次
        /// </summary>
        public string BatchId
        {
            get { return _BatchId; }
            set { _BatchId = value; }
        }
        private string _PayWay;
        /// <summary>
        /// 支付方式
        /// 0	统一支付
        /// 1	在线支付
        /// </summary>
        public string PayWay
        {
            get { return _PayWay; }
            set { _PayWay = value; }
        }

        private string _OrderedTime;
        /// <summary>
        /// 下单时间
        /// </summary>
        public string OrderedTime
        {
            get { return _OrderedTime; }
            set { _OrderedTime = value; }
        }

        /// <summary>
        /// 毛重
        /// </summary>
        public decimal Weight { get; set; }

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

        private int _customerGroupId;
        /// <summary>
        /// 客户集团ID
        /// </summary>
        public int CustomerGroupId
        {
            get { return _customerGroupId; }
            set { _customerGroupId = value; }
        }


        private string _customerGroupCode;
        /// <summary>
        /// 客户集团编码
        /// </summary>
        public string CustomerGroupCode
        {
            get { return _customerGroupCode; }
            set { _customerGroupCode = value; }
        }


        private string _customerGroupName;
        /// <summary>
        /// 客户集团名称
        /// </summary>
        public string CustomerGroupName
        {
            get { return _customerGroupName; }
            set { _customerGroupName = value; }
        }

        /// <summary>
        /// 运费
        /// </summary>
        private decimal _Freight = 0;
        public decimal Freight
        {
            get { return _Freight; }
            set { _Freight = value; }
        }

        public string ShipOrderNumber { get; set; }
        /*
         * 优惠券
         * Add by Hing.Wu
         * Add date:2016-06-08
         */
        private decimal _DiscountAmount = 0;
        /// <summary>
        /// 优惠券
        /// </summary>
        public decimal DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }

        /// <summary>
        /// 库存地点
        /// </summary>
        private string _StockCode;
        public string StockCode
        {
            get { return _StockCode; }
            set { _StockCode = value; }
        }
        private string _FactoryCode;
        /// <summary>
        /// 交货工厂/仓库
        /// </summary>
        public string FactoryCode
        {
            get { return _FactoryCode; }
            set { _FactoryCode = value; }
        }

        private bool _IsPreOrder;
        /// <summary>
        /// 是否为预订单
        /// </summary>
        public bool IsPreOrder
        {
            get { return _IsPreOrder; }
            set { _IsPreOrder = value; }
        }

        private string _OriginalOrderCode;
        /// <summary>
        /// 原订单号
        /// </summary>
        public string OriginalOrderCode
        {
            get { return _OriginalOrderCode; }
            set { _OriginalOrderCode = value; }
        }
        private string _OriginalDeliveryCode;

        /// <summary>
        /// 原发货单号
        /// </summary>
        public string OriginalDeliveryCode
        {
            get { return _OriginalDeliveryCode; }
            set { _OriginalDeliveryCode = value; }
        }

        private string _SalesOrgCode;
        /// <summary>
        /// 销售组织
        /// </summary>
        public string SalesOrgCode
        {
            get { return _SalesOrgCode; }
            set { _SalesOrgCode = value; }
        }

        /*
         * Add by Hing.wu
         * Modified Date:2016-05-27
         * 新增字段 
         */
        private string _SupplierID;
        /// <summary>
        /// SupplierID
        /// </summary>
        public string SupplierID
        {
            get { return _SupplierID; }
            set { _SupplierID = value; }
        }
        private string _SupplierName;

        /// <summary>
        /// SupplierName
        /// </summary>
        public string SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        private string _DistributorCode = string.Empty;
        /// <summary>
        /// 配送商编码
        /// </summary>
        public string DistributorCode
        {
            get { return _DistributorCode; }
            set { _DistributorCode = value; }
        }


        private string _DistributorName = string.Empty;
        /// <summary>
        /// 配送商名称
        /// </summary>
        public string DistributorName
        {
            get { return _DistributorName; }
            set { _DistributorName = value; }
        }


        private string _ContractUrl = string.Empty;
        /// <summary>
        /// 合同下载Url
        /// </summary>
        public string ContractUrl
        {
            get { return _ContractUrl; }
            set { _ContractUrl = value; }
        }


        /*
         * Add by:Terence Tao
         * Add Date:2017/03/28
         */
        /// <summary>
        /// 主订单号
        /// </summary>
        private string _parentOrderCode = string.Empty;
        public string ParentOrderCode
        {
            get { return _parentOrderCode; }
            set { _parentOrderCode = value; }
        }


        /*
        * Add by Hing.wu
        * Modified Date:2016-12-13
        1.       OMS接口增加三个字段
        DistributeType 配送方式
        =1 表示自营配送
        =2 表示第三方人工触发配送
        =3 表示第三方自动配送
        =-1 表示无需配送
                 MainOrderCode 表示主订单号，如果没有拆单，则为空
        BrotherOrderCode 表示关联订单号
        2.       OMS合约订单中只显示DistributeType=1和2的订单(原来其他控制条件仍然保留)
        如果DistributeType=1, 则表示可以往SAP中配货
        如果DistributeType=2, 则表示不能往SAP配货，需要增加一个按钮“通知第三方配货”
                            如果点击，则调用DataPool接口NotifyDistributorSrv
        其他，则不能配货
        3.       页面上最好增加这个配送类型显示
        4.       增加一个地方，显示一下主订单号和关联订单号
        */
        private int _DistributeType = 1;
        /// <summary>
        /// 配送方式
        /// </summary>
        public int DistributeType
        {
            get { return _DistributeType; }
            set { _DistributeType = value; }
        }


        private string _MainOrderCode = string.Empty;
        /// <summary>
        /// 表示主订单号，如果没有拆单，则为空
        /// PR单号
        /// </summary>
        public string MainOrderCode
        {
            get { return this._MainOrderCode; }
            set { this._MainOrderCode = value; }
        }

        private string _BrotherOrderCode = string.Empty;
        /// <summary>
        /// BrotherOrderCode
        /// </summary>
        public string BrotherOrderCode
        {
            get { return this._BrotherOrderCode; }
            set { this._BrotherOrderCode = value; }
        }

        /*
         * Add by hing.wu
         * Modified Date: 2016-12-15
         * SellerMemo卖家备注
         * BuyerMemo买家备注   
         */

        private string _SellerMemo = string.Empty;
        /// <summary>
        /// SellerMemo卖家备注
        /// </summary>
        public string SellerMemo
        {
            get { return this._SellerMemo; }
            set { this._SellerMemo = value; }
        }

        private string _BuyerMemo = string.Empty;
        /// <summary>
        /// BuyerMemo买家备注  
        /// </summary>
        public string BuyerMemo
        {
            get { return this._BuyerMemo; }
            set { this._BuyerMemo = value; }
        }

        private string _erpBillNo = "";
        /// <summary>
        /// ERP订单号
        /// </summary>
        public string ErpBillNo
        {
            get { return _erpBillNo; }
            set { _erpBillNo = value; }
        }

        /// <summary>
        /// 签署主体
        /// </summary>
        public string SignCompanyCode { get; set; }

        /// <summary>
        /// 拿单类型
        /// </summary>
        public string OrderSource { get; set; }

        /// <summary>
        /// 含税算法   2未税  1含税
        /// </summary>
        public int AmountCaculateType { get; set; }

        private string _orderType = "";
        public string OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        private string _orderJson = "";
        public string OrderJson
        {
            get { return _orderJson; }
            set { _orderJson = value; }
        }
        /// <summary>
        /// 客户行业
        /// </summary>
        private string _customerTrade = "";
        public string CustomerTrade
        {
            get { return _customerTrade; }
            set { _customerTrade = value; }
        }

        /// <summary>
        /// 客户行业编码
        /// </summary>
        private string _customerTradeCode = "";
        public string CustomerTradeCode
        {
            get { return _customerTradeCode; }
            set { _customerTradeCode = value; }
        }

        /// <summary>
        /// 合同项目编号
        /// </summary>
        private string _contractID = "";
        public string ContractID
        {
            get { return _contractID; }
            set { _contractID = value; }
        }
        /// <summary>
        /// 资产类订单标识
        /// </summary>
        public bool AssetsFlag
        {
            get; set;
        }
        /// <summary>
        /// 交付方式
        /// </summary>
        public string VoucherType { get; set; }
        /// <summary>
        /// 业绩归属
        /// </summary>
        public string AchievementAttr { get; set; }
        /// <summary>
        /// 折扣点
        /// </summary>
        public decimal? PurchasePoint { get; set; }
        /// <summary>
        /// 结算员
        /// </summary>
        public string SettlerNo { get; set; }
        /// <summary>
        /// 直通单
        /// </summary>
        public bool DirectOrderSign
        {
            get; set;
        }
        /// <summary>
        /// 原单号
        /// </summary>
        public string FromSourceBillNo
        {
            get; set;
        }
        /// <summary>
        /// 拆单状态
        /// </summary>
        public string ComposeStatus
        {
            get; set;
        }

        /// <summary>
        /// 第三方系统经办人电话
        /// </summary>
        public string LinkTel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OrderRemark
        {
            get; set;
        }

        /// <summary>
        /// 数据来源
        /// PC、Offline
        /// </summary>
        public string DataSource
        {
            get; set;
        }


        public string ComposeFlag
        {
            get; set;
        }


        /// <summary>
        /// 订单标识
        /// </summary>
        public string OrderFlag
        {
            get; set;
        }

        /// <summary>
        /// 是否管控
        /// </summary>
        public string IsControl
        {
            get; set;
        }
    }
}
