using SqlSugar;

namespace Comix.B2B.SDK.Entities
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Shop_Orders")]
    [Tenant(B2bSetup.ConfigId)]
    public partial class ShopOrders
    {
        public ShopOrders()
        {
            this.ParentOrderId = Convert.ToInt64("-1");
            this.ShippingStatus = Convert.ToInt16("0");
            this.PaymentStatus = Convert.ToInt16("0");
            this.RefundStatus = Convert.ToInt16("0");
            this.OrderTotal = Convert.ToDecimal("0");
            this.OrderPoint = Convert.ToInt32("0");
            this.DiscountAmount = Convert.ToDecimal("0");
            this.DiscountValue = Convert.ToDecimal("0");
            this.CouponAmount = Convert.ToDecimal("0");
            this.ActivityStatus = Convert.ToInt16("0");
            this.GroupBuyStatus = Convert.ToInt16("0");
            this.Amount = Convert.ToDecimal("0");
            this.OrderType = Convert.ToInt16("1");
            this.OrderStatus = Convert.ToInt16("0");
            this.SupplierId = Convert.ToInt32("-1");
            this.CommentStatus = Convert.ToInt16("0");
            this.ProductTotal = Convert.ToDecimal("0");
            this.HasChildren = false;
            this.IsReviews = false;
            this.CreateUserId = Convert.ToInt32("-1");
            this.ReferType = Convert.ToInt32("0");
            this.OriginalId = Convert.ToInt64("0");
            this.OrderTypeSub = Convert.ToInt16("0");
            this.OrderPromotionType = Convert.ToInt32("0");
            this.ApproveStatus = true;
            this.OrderSyncStatus = Convert.ToString("F");
            this.CouponHandled = Convert.ToString("F");
            this.CompositeAdvancedAmount = Convert.ToDecimal("0.0");
            this.CompositeOnlineAmount = Convert.ToDecimal("0.0");
            this.IsShowBuyAgainList = true;
            this.OmsOrderType = Convert.ToString("");
            this.OmsOrderReason = Convert.ToString("");
            this.OmsPayConditionCode = Convert.ToString("");
            this.IsOnline = true;
            this.ThirdPartyName = Convert.ToString("");
            this.ThirdOrderCode = Convert.ToString("");
            this.AgrEpiSuperiorCode = Convert.ToString("");
            this.CloseBySystem = true;
        }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, IsNullable = false)]
        public long OrderId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false)]
        public string OrderCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:-1
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public long ParentOrderId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int BuyerID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false)]
        public string BuyerName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false)]
        public string BuyerEmail { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? BuyerCellPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? RegionId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? ShipRegion { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? ShipAddress { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = true)]
        public string? ShipZipCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipTelPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipCellPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? ShipEmail { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? ShippingModeId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? ShippingModeName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? RealShippingModeId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? RealShippingModeName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? ShipperId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? ShipperName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? ShipperAddress { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = true)]
        public string? ShipperCellPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? Freight { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? FreightAdjusted { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? FreightActual { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? Weight { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short ShippingStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipOrderNumber { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true)]
        public string? ExpressCompanyName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true)]
        public string? ExpressCompanyAbb { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false)]
        public string PaymentTypeName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false)]
        public string PaymentGateway { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short PaymentStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short RefundStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = true)]
        public string? PayCurrencyCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = true)]
        public string? PayCurrencyName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? PaymentFee { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? PaymentFeeAdjusted { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? GatewayOrderId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int OrderPoint { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? OrderCostPrice { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? OrderProfit { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? OrderOtherCost { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? OrderOptionPrice { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? DiscountName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? DiscountAdjusted { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? DiscountValue { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public short? DiscountValueType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? CouponCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? CouponName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? CouponAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? CouponValue { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public short? CouponValueType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? ActivityName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? ActivityFreeAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short ActivityStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? GroupBuyId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? GroupBuyPrice { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short GroupBuyStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short OrderType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short OrderStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? SellerID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? SellerName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? SellerEmail { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? SellerCellPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:-1
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? SupplierId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? SupplierName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ReferID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? ReferURL { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OrderIP { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 2000, IsNullable = true)]
        public string? Remark { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short CommentStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public decimal ProductTotal { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public bool HasChildren { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public bool IsReviews { get; set; }

        /// <summary>
        /// Desc:
        /// Default:-1
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int CreateUserId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? ReferType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public long OriginalId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public short OrderTypeSub { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? SubAccountId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? SubAccountUserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? SubAccountName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipAccount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? ToOmsStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? ErrorCount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = true)]
        public string? stockcode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 30, IsNullable = true)]
        public string? DataSource { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? OrderPromotionType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public DateTime? PayEndDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 1, IsNullable = true)]
        public string? ToCdpStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? toStockStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? GroupBuyCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public bool ApproveStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:F
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? OrderSyncStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? SupplierCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:F
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string? CouponHandled { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0.0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? CompositeAdvancedAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0.0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? CompositeOnlineAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OrderSourceType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OrderSourceCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public bool IsShowBuyAgainList { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? CoinAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OmsPaymentGateWay { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OmsOrderType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OmsOrderReason { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OmsPayConditionCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public bool? IsOnline { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? ThirdPartyName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? ThirdOrderCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? OmsLocation { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OmsCreateBy { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? DistributorCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ActionCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? WorkflowInstanceId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? WorkflowApproveStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? WorkflowApproveOrder { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true)]
        public string? WorkflowApproveNote { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? OmsCreateName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false)]
        public string AgrEpiSuperiorCode { get; set; }

        /// <summary>
        /// Desc:履约订单状态
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? AgrEpiOrderStatus { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public bool CloseBySystem { get; set; }

        /// <summary>
        /// Desc:销售组织
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 4, IsNullable = true)]
        public string? SalesOrgCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipProvince { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipCity { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ShipDistrict { get; set; }
    }
}