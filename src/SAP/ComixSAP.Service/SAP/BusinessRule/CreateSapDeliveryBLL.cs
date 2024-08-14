using System.Collections.Generic;
using System.Text;
using System.Data;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class CreateSapDeliveryBLL 
    {
        public virtual void CreateSapDelivery(string quiryDate,string customerCode, DataTable quriyConditon, out string errorMessage)
        {
            errorMessage = "";
            // try
            // {
                SAPDeliveryHeadModel dHMByDataRow = new SAPDeliveryHeadModel
                {
                    CDSBillNO = "",
                    DeliveryNo = "",
                    SalesOrg = "",
                    ChannelCode = "",
                    ProdGroup = "",
                    SalesDept = "",
                    SalesGroup = "",
                    DeliveryCity = "",
                    OrderOperatorName = "admin",
                    ScheduleMoveDate = "",//yyyyMMdd
                    PickingDate = "",//yyyyMMdd
                    Remark = "",
                    TotalNetWeight = 0,
                    TotalGlossWeight = 0,
                    WeightUnit = "",
                    Traffic = 0M,
                    TrafficUnit = "",
                    IsModify = "",
                    DiscountAmount = "0",
                    OrderBillNo = string.Empty,
                    DataLine = string.Empty
                };

                List<SAPDeliveryDetailModel> list = new List<SAPDeliveryDetailModel>();

                List<string> forList = new List<string>();

                foreach (string item in forList)
                {
                    SAPDeliveryDetailModel model = new SAPDeliveryDetailModel
                    {
                        SAPBillNo = "",
                        ItemNo = "",
                        DeliveryNo = "",
                        DeliveryItemNo = "",
                        FactoryName = "",
                        Location = "",
                        ProdCode = "",
                        DeliveryQuantity = 0,
                        SalesUnit = "",
                        UnitConvMolecular = 0M,
                        UnitConvDenominator = 0M,
                        PickingQuantity = 0M,
                        NetWeight = 0M,
                        GloassWeight = 0M,
                        WeightUnit = "",
                        Traffic = 0M,
                        TrafficUnit = "",
                        LotRequireFlag = "",
                        LotFlag = "",
                        LotNo = "",
                        RefItemNo = "",
                        IsModify = ""
                    };

                    list.Add(model);
                }

                DeliveryOrderEntity deliveryOrderEntity = new DeliveryOrderEntity
                {
                    DeliveryOrderHeadImport = dHMByDataRow,
                    DeliveryOrderDetailsImport = list
                };
                if (deliveryOrderEntity.Validate())
                {
                    SapStructureService<DeliveryOrderEntity>.GetSAPRFCEntity(deliveryOrderEntity);
                }

                SAPDeliveryHeadModel deliveryReturnOrderEntity = deliveryOrderEntity.DeliveryOrderHeadExport;
                List<SAPDeliveryDetailModel> deliveryOrderDetailsExport = deliveryOrderEntity.DeliveryOrderDetailsExport;

                string messageType = deliveryOrderEntity.MessageType;
                if (!(messageType == "S"))
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (MessageModel message in deliveryOrderEntity.MessageList)
                    {
                        builder.Append(message.Message + " \n");
                    }
                }
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!";
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "获取汇款" + ex.Message;
            //     mailEntity.EMAIL_TOUSER = "jungui.sun@qx.com";
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
            // }
        }
    }
}
