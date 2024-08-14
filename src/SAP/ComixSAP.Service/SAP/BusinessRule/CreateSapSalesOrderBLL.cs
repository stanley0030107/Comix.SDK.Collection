using System;
using System.Collections.Generic;
using System.Data;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class CreateSapSalesOrderBLL
    {
        public virtual void CreateSapOrder(string quiryDate, string customerCode, DataTable quriyConditon, out string errorMessage)
        {
            errorMessage = "";
            // try
            // {
                SalesOrderHeadModel sOhmByDataRow = new SalesOrderHeadModel
                {
                    OrderType = "",
                    SalesOrg = "",//
                    ChannelCode = "",//
                    ProdGroup = "",//
                    SalesDept = "",//
                    SalesGroup = "",//
                    PurchaseNo = "",//
                    PurchaseBillDate = "",//seorder.POOrderDate.ToString("yyyyMMdd"),
                    SoldCustCode = "",//
                    SendCustCode = "",//
                    PaymentCode = "",
                    BillDate = "",// seorder.BillDate.ToString("yyyyMMdd"),
                    PriceFixDate = "",// seorder.PriceDate.ToString("yyyyMMdd"),
                    DistSchemeCode = "",
                    BillReason = "",
                    OrderOperatorName = "admin",//加创建人,
                    IsPromotion = "",//Y N
                    BillNo = "",
                    RefRemark = "",
                    DiscountAmount = 0,
                    DiscountAmountFlag = "",
                    DiscountPercent = 0,
                    DiscountPercentFlag = "",
                    IsFreeDelivery = "",
                    Freight = 0,
                    FreightFlag = "",//X 或者空
                };

                List<SalesOrderDetailModel> list = new List<SalesOrderDetailModel>();

                List<string> forList = new List<string>();

                foreach (string item1 in forList)
                {
                    SalesOrderDetailModel item = new SalesOrderDetailModel();
                    item.ItemDiscountAmountFlag = "";
                    item.ItemDiscountAmount = 0;
                    item.QxCoinAmount = 0;
                    item.QxCoinFlag = "";
                    item.YhCouponFlag = "";
                    item.YhCouponAmount = 0;
                    item.ItemNo = "";
                    item.PLTYP = "";
                    item.FactoryName = "";
                    item.Location = "";
                    item.ProdCode = "";
                    item.Price = 0;
                    item.PriceFlag = "";
                    item.SpecialPrice = 0;
                    item.SpecialPriceFlag = "";
                    item.Quantity = 0;
                    item.Unit = "";
                    item.ConfirmQuantity = 0M;
                    item.PaymentCode = "";
                    item.ScheduleDeliveryDate = "";//("yyyyMMdd");
                    item.VoucherType = string.Empty;
                    item.IsModify = string.Empty;
                    item.PriceFixDate = "";// ("yyyyMMdd");
                    item.RejectReason = "";
                    item.ProdGroup = "";
                    item.Remark = "";
                    item.ScheduleConfirmDate = string.Empty;
                    item.IsFree = "";
                    item.ParentItemNo = "";
                    item.TaxAmount = 0M;
                    item.NoIncludeTaxAmount = 0M;
                    list.Add(item);
                }
                SalesOrderEntity salesOrderEntity = new SalesOrderEntity
                {
                    SalesHeadImport = sOhmByDataRow,
                    SalesOrderDetailsImport = list
                };

                if (salesOrderEntity.Validate())
                {
                    SapStructureService<SalesOrderEntity>.GetSAPRFCEntity(salesOrderEntity);
                }
                if (salesOrderEntity.MessageType.Trim().ToUpper() == "S")
                {

                }
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!";
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "获取汇款" + ex.Message;
            //     mailEntity.EMAIL_TOUSER = "shengwu.he@qx.com";
            //     mailEntity.EMAIL_CCUSER = "";
            //     mailEntity.EMAIL_CONTENT = "错误:" + errorMessage;
            //     mailEntity.ATTACHMENTS_PATH = "";
            //     mailEntity.EMAIL_DATE = DateTime.Now;
            //     mailEntity.EMAIL_SENDER = "";
            //     mailEntity.SEND_TIMES = 0;
            //     mailEntity.SEND_STATUS = 0;
            //     mailEntity.REMARK = "";
            //     mailEntity.LAST_MODIFIED_BY = "EDI";
            //     mailEntity.LAST_MODIFIED_TIME = DateTime.Now;
            //     DataAccess.Insert(mailEntity);
            //
            // }
        }
    }
}
