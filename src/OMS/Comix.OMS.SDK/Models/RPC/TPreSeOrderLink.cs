namespace Comix.OMS.SDK.Models.RPC;

public class TPreSeOrderLink
{
    /// <summary>
    /// 构造函数初始化默认值
    /// </summary>
    public TPreSeOrderLink()
    {
        WFCurrNo = string.Empty;
        WFStatus = 0;
    }

    /// <summary>
    ///合约订单编号
    /// </summary>
    //[Display(Name = "合约订单编号")]
    public virtual string SourceBillNo { get; set; }

    /// <summary>
    ///销售订单号（SE单号）
    /// </summary>
    //[Display(Name = "销售订单号（SE单号）")]
    public virtual string BillNo { get; set; }

    /// <summary>
    ///客户平台编号
    /// </summary>
    //[Required(ErrorMessage = "采购平台订单号不能为空")]
    //[Display(Name = "客户平台编号")]
    public virtual string pxOrderId { get; set; }

    /// <summary>
    ///售达方
    /// </summary>
    //[Required(ErrorMessage = "售达方不能为空")]
    //[Display(Name = "售达方")]
    public virtual string SoldToCustCode { get; set; }

    /// <summary>
    ///送达方
    /// </summary>
    //[Display(Name = "送达方")]
    public virtual string ShipToCustCode { get; set; }

    /// <summary>
    /// 第三方系统登录账户
    /// </summary>
    //[Display(Name = "第三方系统登录账户")]
    public virtual string customerName { get; set; }

    /// <summary>
    ///是否紧急订单 .0:普通订单/1:紧急订单
    /// </summary>
    //[Display(Name = "是否紧急订单 .0:普通订单/1:紧急订单")]
    public virtual bool isEmergency { get; set; }

    /// <summary>
    ///紧急单批次
    /// </summary>
    //[Display(Name = "紧急单批次")]
    public virtual string batchId { get; set; }

    /// <summary>
    ///支付方式. 0:统一支付/1:在线支付，默认0
    /// </summary>
    //[Display(Name = "支付方式. 0:统一支付/1:在线支付，默认0")]
    public virtual string payWay { get; set; }

    /// <summary>
    ///含税总额
    /// </summary>
    //[Display(Name = "含税总额")]
    public virtual decimal TotalTaxAmount { get; set; }

    /// <summary>
    ///未税总额
    /// </summary>
    //[Display(Name = "未税总额")]
    public virtual decimal TotalNotIncTaxAmount { get; set; }

    /// <summary>
    ///Status
    /// </summary>
    //[Display(Name = "Status")]
    public virtual string Status { get; set; }

    /// <summary>
    ///下单时间
    /// </summary>
    //[Display(Name = "下单时间")]
    public virtual string OrderedTime { get; set; }

    /// <summary>
    ///创建时间
    /// </summary>
    //[Display(Name = "创建时间")]
    public virtual DateTime CreatedTime { get; set; }

    /// <summary>
    ///DataSource
    /// </summary>
    //[Display(Name = "DataSource")]
    public virtual string DataSource { get; set; }

    /// <summary>
    ///FromSystem
    /// </summary>
    //[Display(Name = "FromSystem")]
    public virtual string FromSystem { get; set; }

    /// <summary>
    ///修改时间
    /// </summary>
    //[Display(Name = "修改时间")]
    public virtual DateTime? ModifiedDate { get; set; }

    /// <summary>
    ///PriceType
    /// </summary>
    //[Display(Name = "PriceType")]
    public virtual string PriceType { get; set; }

    /// <summary>
    ///总金额
    /// </summary>
    //[Display(Name = "总金额")]
    public virtual decimal? TotalPrice { get; set; }

    /// <summary>
    ///TotalNakedPrice
    /// </summary>
    //[Display(Name = "TotalNakedPrice")]
    public virtual decimal? TotalNakedPrice { get; set; }

    /// <summary>
    ///TotalTaxPrice
    /// </summary>
    //[Display(Name = "TotalTaxPrice")]
    public virtual decimal? TotalTaxPrice { get; set; }

    /// <summary>
    /// 销售组织
    /// </summary>
    //[Required(ErrorMessage = "销售组织不能为空")]
    //[Display(Name = "销售组织")]
    public virtual string SalesOrgCode { get; set; }

    /// <summary>
    ///CustomerGroupId
    /// </summary>
    //[Display(Name = "CustomerGroupId")]
    public virtual int? CustomerGroupId { get; set; }

    /// <summary>
    ///合约集团编号
    /// </summary>
    //[Required(ErrorMessage = "合约集采项目不能为空")]
    //[Display(Name = "合约集团编号")]
    public virtual string CustomerGroupCode { get; set; }

    /// <summary>
    ///CustomerGroupName
    /// </summary>
    //[Display(Name = "CustomerGroupName")]
    public virtual string CustomerGroupName { get; set; }

    /// <summary>
    ///Freight
    /// </summary>
    //[Display(Name = "Freight")]
    public virtual decimal? Freight { get; set; }

    /// <summary>
    ///工厂代码
    /// </summary>
    //[Required(ErrorMessage = "工厂不能为空")]
    //[Display(Name = "工厂代码")]
    public virtual string FactoryCode { get; set; }

    /// <summary>
    ///StockCode
    /// </summary>
    //[Required(ErrorMessage = "库存地点不能为空")]
    //[Display(Name = "StockCode")]
    public virtual string StockCode { get; set; }

    /// <summary>
    /// 是否预订单
    /// </summary>
    //[Display(Name = "是否预订单")]
    public virtual bool IsPreOrder { get; set; }

    /// <summary>
    /// IsToSap
    /// </summary>
    //[Display(Name = "IsToSap")]
    public virtual bool IsToSap { get; set; }

    /// <summary>
    ///OriginalOrderCode
    /// </summary>
    //[Display(Name = "OriginalOrderCode")]
    public virtual string OriginalOrderCode { get; set; }

    /// <summary>
    ///OriginalDeliveryCode
    /// </summary>
    //[Display(Name = "OriginalDeliveryCode")]
    public virtual string OriginalDeliveryCode { get; set; }

    /// <summary>
    ///AutoOrderDesc
    /// </summary>
    //[Display(Name = "AutoOrderDesc")]
    public virtual string AutoOrderDesc { get; set; }

    /// <summary>
    ///供应商id
    /// </summary>
    //[Display(Name = "供应商id")]
    public virtual string SupplierID { get; set; }

    /// <summary>
    ///SupplierName
    /// </summary>
    //[Display(Name = "SupplierName")]
    public virtual string SupplierName { get; set; }

    /// <summary>
    ///DiscountAmount
    /// </summary>
    //[Display(Name = "DiscountAmount")]
    public virtual decimal? DiscountAmount { get; set; }

    /// <summary>
    ///配送商编码
    /// </summary>
    //[Display(Name = "配送商编码")]
    //[Required(ErrorMessage = "配送商不能为空")]
    public virtual string DistributorCode { get; set; }

    /// <summary>
    ///配送商名称
    /// </summary>
    //[Display(Name = "配送商名称")]
    public virtual string DistributorName { get; set; }

    /// <summary>
    ///ContractUrl
    /// </summary>
    //[Display(Name = "ContractUrl")]
    public virtual string ContractUrl { get; set; }

    /// <summary>
    ///经营模式
    /// </summary>
    //[Display(Name = "经营模式")]
    //[Required(ErrorMessage = "经营模式不能为空")]
    public virtual int? DistributeType { get; set; }

    /// <summary>
    ///MainOrderCode
    /// </summary>
    //[Display(Name = "MainOrderCode")]
    public virtual string MainOrderCode { get; set; }

    /// <summary>
    ///BrotherOrderCode
    /// </summary>
    //[Display(Name = "BrotherOrderCode")]
    public virtual string BrotherOrderCode { get; set; }

    /// <summary>
    ///SellerMemo
    /// </summary>
    //[Display(Name = "SellerMemo")]
    public virtual string SellerMemo { get; set; }

    /// <summary>
    ///BuyerMemo
    /// </summary>
    //[Display(Name = "BuyerMemo")]
    public virtual string BuyerMemo { get; set; }

    /// <summary>
    ///ParentOrderCode
    /// </summary>
    //[Display(Name = "ParentOrderCode")]
    public virtual string ParentOrderCode { get; set; }

    /// <summary>
    /// 客户ERP订单号
    /// </summary>
    //[Display(Name = "客户ERP订单号")]
    public virtual string ErpBillNo { get; set; }

    /// <summary>
    ///合同项目
    /// </summary>
    //[Required(ErrorMessage = "合同项目不能为空")]
    //[Display(Name = "合同项目")]
    public virtual string ContractSysId { get; set; }

    /// <summary>
    /// 订单类型
    /// </summary>
    //[Required(ErrorMessage = "订单类型不能为空")]
    //[Display(Name = "订单类型")]
    public virtual string OrderType { get; set; }

    /// <summary>
    ///采购折扣点数
    /// </summary>
    //[Display(Name = "采购折扣点数")]
    public virtual decimal? PurchasePoint { get; set; }

    /// <summary>
    ///交付方式
    /// </summary>
    //[Display(Name = "交付方式")]
    //[Required(ErrorMessage = "交付方式不能为空")]
    public virtual string VoucherType { get; set; }

    /// <summary>
    ///OrderJson
    /// </summary>
    //[Display(Name = "OrderJson")]
    public virtual string OrderJson { get; set; }

    /// <summary>
    ///DeliveryPostStatus
    /// </summary>
    //[Display(Name = "DeliveryPostStatus")]
    public virtual string DeliveryPostStatus { get; set; }

    /// <summary>
    ///TotalGrossProfitAmount
    /// </summary>
    //[Display(Name = "TotalGrossProfitAmount")]
    public virtual decimal? TotalGrossProfitAmount { get; set; }

    /// <summary>
    ///TotalGrossProfitRate
    /// </summary>
    //[Display(Name = "TotalGrossProfitRate")]
    public virtual decimal? TotalGrossProfitRate { get; set; }

    /// <summary>
    ///SettlementStatus
    /// </summary>
    //[Display(Name = "SettlementStatus")]
    public virtual int? SettlementStatus { get; set; }

    /// <summary>
    ///DeliveryUser
    /// </summary>
    //[Display(Name = "DeliveryUser")]
    public virtual string DeliveryUser { get; set; }

    /// <summary>
    ///发货时间
    /// </summary>
    //[Display(Name = "DeliveryTime")]
    public virtual DateTime? DeliveryTime { get; set; }

    /// <summary>
    ///SignUser
    /// </summary>
    //[Display(Name = "SignUser")]
    public virtual string SignUser { get; set; }

    /// <summary>
    ///签收时间
    /// </summary>
    //[Display(Name = "SignTime")]
    public virtual DateTime? SignTime { get; set; }

    /// <summary>
    ///CustomerTrade
    /// </summary>
    //[Display(Name = "CustomerTrade")]
    public virtual string CustomerTrade { get; set; }

    /// <summary>
    ///Implementer
    /// </summary>
    //[Display(Name = "Implementer")]
    public virtual string Implementer { get; set; }

    /// <summary>
    ///业绩归属
    /// </summary>
    //[Display(Name = "业绩归属")]
    //[Required(ErrorMessage = "业绩归属不能为空")]
    public virtual string AchievementAttr { get; set; }

    /// <summary>
    ///CustomerTradeCode
    /// </summary>
    //[Display(Name = "CustomerTradeCode")]
    public virtual string CustomerTradeCode { get; set; }

    /// <summary>
    ///EstDeliveryDays
    /// </summary>
    //[Display(Name = "EstDeliveryDays")]
    public virtual int? EstDeliveryDays { get; set; }

    /// <summary>
    ///确认时间
    /// </summary>
    //[Display(Name = "DistributorConfirmTime")]
    public virtual DateTime? DistributorConfirmTime { get; set; }

    /// <summary>
    ///DistributorConfirmUser
    /// </summary>
    //[Display(Name = "DistributorConfirmUser")]
    public virtual string DistributorConfirmUser { get; set; }

    /// <summary>
    ///AutoOrderStep
    /// </summary>
    //[Display(Name = "AutoOrderStep")]
    public virtual int? AutoOrderStep { get; set; }

    /// <summary>
    ///InvoiceStatus
    /// </summary>
    //[Display(Name = "InvoiceStatus")]
    public virtual string InvoiceStatus { get; set; }

    /// <summary>
    ///ChangeDistributorUserName
    /// </summary>
    //[Display(Name = "ChangeDistributorUserName")]
    public virtual string ChangeDistributorUserName { get; set; }

    /// <summary>
    ///RetreatOrderReason
    /// </summary>
    //[Display(Name = "RetreatOrderReason")]
    public virtual string RetreatOrderReason { get; set; }

    /// <summary>
    ///RetreatOrderStatus
    /// </summary>
    //[Display(Name = "RetreatOrderStatus")]
    public virtual string RetreatOrderStatus { get; set; }

    /// <summary>
    ///ApproveResult
    /// </summary>
    //[Display(Name = "ApproveResult")]
    public virtual string ApproveResult { get; set; }

    /// <summary>
    ///SignedStatus
    /// </summary>
    //[Display(Name = "SignedStatus")]
    public virtual string SignedStatus { get; set; }

    /// <summary>
    ///Status2
    /// </summary>
    //[Display(Name = "Status2")]
    public virtual string Status2 { get; set; }

    /// <summary>
    ///AmountStatus
    /// </summary>
    //[Display(Name = "AmountStatus")]
    public virtual string AmountStatus { get; set; }

    /// <summary>
    ///ReceivedPaymentsAmount
    /// </summary>
    //[Display(Name = "ReceivedPaymentsAmount")]
    public virtual decimal? ReceivedPaymentsAmount { get; set; }

    /// <summary>
    ///应回款金额
    /// </summary>
    //[Display(Name = "AccountsReceivable")]
    public virtual decimal? AccountsReceivable { get; set; }

    /// <summary>
    ///结算员
    /// </summary>
    //[Display(Name = "结算员")]
    // //[Required(ErrorMessage = "结算员不能为空")]
    public virtual string SettlerNo { get; set; }

    /// <summary>
    ///发货方  O2O SAP OMS
    /// </summary>
    //[Display(Name = "发货方")]
    public virtual string DeliveryFrom { get; set; }

    /// <summary>
    ///导入时间标记
    /// </summary>
    //[Display(Name = "导入时间标记")]
    public virtual string ImportTime { get; set; }

    /// <summary>
    /// 资产类订单标识
    /// </summary>
    //[Display(Name = "资产类订单标识")]
    public virtual bool AssetsFlag { get; set; }

    /// <summary>
    /// 直通单标记
    /// </summary>
    //[Display(Name = "直通单标记")]
    public bool DirectOrderSign { get; set; }

    /// <summary>
    /// 签署主体
    /// </summary>
    //[Display(Name = "签署主体")]
    public virtual string SignCompanyCode { get; set; }

    /// <summary>
    /// 合同结束日期
    /// </summary>
    public virtual string DistValiDateEnd { get; set; }

    /// <summary>
    /// 合同编码
    /// </summary>
    public virtual string ContractNo { get; set; }

    /// <summary>
    /// 未出库原因
    /// 1.货未到仓（在途、暂时断货）
    /// 2.直发客户，等回签入库
    /// 3.等客户通知发货（客户暂时没地方存放或其它）
    /// 4.客户取消订单（后台发起退货，没及时跟进到，销售单未及时在系统作废）
    /// 5.供应链集采未及时入库
    /// 6.子公司仓库未及时入库
    /// 7.订单员未及时处理订单
    /// 8.停产
    /// </summary>
    //[Display(Name = "未出库原因")]
    public virtual int? DelayDeliveryReason { get; set; }

    /// <summary>
    /// 拿单类型，1、自主拿单；2、SP单；3或者空为盲单
    /// </summary>
    //[Display(Name = "拿单类型")]
    public virtual string OrderSource { get; set; }

    /// <summary>
    /// 预计发货时间
    /// </summary>
    //[Display(Name = "预计发货时间")]
    public virtual DateTime? PlanDeliveryTime { get; set; }

    /// <summary>
    /// 第三方系统经办人电话
    /// </summary>
    //[Display(Name = "第三方系统经办人电话")]
    public string LinkTel { get; set; }

    /// <summary>
    /// 发货逾期时间
    /// </summary>
    //[Display(Name = "发货逾期时间")]
    public virtual DateTime? DeliveryLimitTime { get; set; }

    /// <summary>
    /// 收单逾期时间
    /// </summary>
    //[Display(Name = "收单逾期时间")]
    public virtual DateTime? AcceptLimitTime { get; set; }

    /// <summary>
    /// 签收逾期时间
    /// </summary>
    //[Display(Name = "签收逾期时间")]
    public virtual DateTime? SignLimitTime { get; set; }

    /// <summary>
    /// 原因确认
    /// </summary>
    //[Display(Name = "原因确认")]
    public virtual bool? IsConfirm { get; set; }

    /// <summary>
    /// 首次分单时间
    /// </summary>
    //[Display(Name = "首次分单时间")]
    public virtual DateTime? CreateDistributorTime { get; set; }

    /// <summary>
    /// 预计发货原因
    /// </summary>
    //[Display(Name = "预计发货原因")]
    public virtual string PlanDeliveryReason { get; set; }

    /// <summary>
    /// 拆单状态  1被拆主单  2子单  0普通未拆分
    /// </summary>
    //[Display(Name = "拆单状态")]
    public virtual string ComposeStatus { get; set; }

    /// <summary>
    /// 拆单状态
    /// </summary>
    //[Display(Name = "拆单标识")]
    public virtual string ComposeFlag { get; set; }

    /// <summary>
    /// 预分单标识 1预分单  2受控待分 
    /// </summary>
    //[Display(Name = "预分单标识")]
    public virtual string PreAssign { get; set; }

    /// <summary>
    /// 自动分单标识 1自动分单  2受控待分 
    /// </summary>
    //[Display(Name = "自动分单标识")]
    public virtual string AutoAssign { get; set; }

    /// <summary>
    /// 订单员
    /// </summary>
    //[Display(Name = "订单员")]
    public virtual string OrderProcessor { get; set; }

    /// <summary>
    /// 流程编号
    /// </summary>
    //[Display(Name = "流程编号")]
    public string WFCurrNo { get; set; }

    /// <summary>
    /// 流程状态
    /// </summary>
    //[Display(Name = "流程状态")]
    public int WFStatus { get; set; }

    /// <summary>
    /// 流程异常信息
    /// </summary>
    //[Display(Name = "流程异常信息")]
    public string WFErrorMsg { get; set; }

    /// <summary>
    /// 订单标识
    /// </summary>
    //[Display(Name = "订单标识")]
    public virtual string OrderFlag { get; set; }

    /// <summary>
    /// 线下创建订单标识
    /// </summary>
    //[Display(Name = "线下创建订单标识")]
    public virtual bool IsOfflineSeOrder { get; set; }

    /// <summary>
    /// 是否推送CDP消息
    /// </summary>
    //[Display(Name = "是否推送")]
    public virtual bool? IsSyncAssign { get; set; }

    /// <summary>
    /// 发货预警时间
    /// </summary>
    //[Display(Name = "发货预警时间")]
    public virtual DateTime? DeliveryWarningTime { get; set; }

    /// <summary>
    /// 签收预警时间
    /// </summary>
    //[Display(Name = "签收预警时间")]
    public virtual DateTime? SignWarningTime { get; set; }

    /// <summary>
    /// 创建销售时间
    /// </summary>
    //[Display(Name = "创建销售时间")]
    public virtual DateTime? CreateSalesTime { get; set; }

    /// <summary>
    /// 仓库名称
    /// </summary>
    //[Display(Name = "仓库名称")]
    public virtual string StoreName { get; set; }

    /// <summary>
    /// 业务员
    /// </summary>
    //[Display(Name = "业务员")]
    public virtual string BusinessMan { get; set; }

    /// <summary>
    /// 业务员编码
    /// </summary>
    //[Display(Name = "业务员编码")]
    public virtual string BusinessManCode { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    //[Display(Name = "备注")]
    public virtual string OrderRemark { get; set; }

    /// <summary>
    /// 子公司分单服务商时间
    /// </summary>
    public virtual DateTime? SubFirstDistributorTime { get; set; }

    /// <summary>
    /// 首次分单服务商时间
    /// </summary>
    public virtual DateTime? FirstDistributorTime { get; set; }


    #region 自定义内容 --------------------------------------------------------------------------------------------------

    private string _productCodeLists = string.Empty;

    /// <summary>
    /// 相关物料
    /// </summary>
    public string ProductCodeList
    {
        get { return _productCodeLists == string.Empty ? @"''" : _productCodeLists; }
        set { _productCodeLists = value; }
    }

    public string Idx { get; set; }


    /// <summary>
    /// 售达方名称
    /// </summary>
    //[Display(Name = "售达方名称")]
    public virtual string SoldToCustName { get; set; }

    /// <summary>
    /// 合同项目名称
    /// </summary>
    //[Display(Name = "合同项目")]
    public virtual string ContractSysName { get; set; }

    /// <summary>
    /// 业绩归属名称
    /// </summary>
    //[Display(Name = "业绩归属")]
    public virtual string AchievementAttrName { get; set; }

    /// <summary>
    /// 结算员名称
    /// </summary>
    //[Display(Name = "结算员")]
    public virtual string SettlerName { get; set; }

    /// <summary>
    /// 经营模式
    /// </summary>
    //[Display(Name = "经营模式")]
    public virtual string BussinessModel { get; set; }

    /// <summary>
    /// 交付方式
    /// </summary>
    //[Display(Name = "交付方式")]
    public virtual string VoucherTypeName { get; set; }

    /// <summary>
    /// 对应的SAP销售订单号
    /// </summary>
    //[Display(Name = "对应的SAP销售订单号")]
    public virtual string SapBillNo { get; set; }

    /// <summary>
    /// 重组订单类型
    /// </summary>
    public virtual string ComposeFlagName { get; set; }

    /// <summary>
    /// 线下创建订单标识名称
    /// </summary>
    public virtual string IsOfflineSeOrderName { get; set; }

    /// <summary>
    /// 是否允许修改配送商(CBM)
    /// </summary>
    public virtual bool ChangeDistributorEnable { get; set; }

    #endregion
}