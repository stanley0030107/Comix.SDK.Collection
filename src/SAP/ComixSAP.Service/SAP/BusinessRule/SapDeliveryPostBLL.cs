using System;
using System.Collections.Generic;
using System.Data;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class SapDeliveryPostBLL 
    {
        public virtual void SapDeliveryPost(string quiryDate, string customerCode, DataTable quriyConditon, out string errorMessage)
        {
            errorMessage = "";
            // try
            // {
                PostDeliveryOrderEntity entity = new PostDeliveryOrderEntity();

                List<ZWMSDeliveryOrderModel> listPostItems = new List<ZWMSDeliveryOrderModel>();

                List<string> forList = new List<string>();

                foreach (string item in forList)
                {
                    ZWMSDeliveryOrderModel deliveryModel = new ZWMSDeliveryOrderModel();

                    deliveryModel.Vbeln = "";
                    deliveryModel.Posnr = "";
                    deliveryModel.Prodcode = "";
                    deliveryModel.Postqty = "";
                    deliveryModel.Baseunit = "";
                    deliveryModel.Vouchertype = "OMS";
                    deliveryModel.Factorycode = "";
                    deliveryModel.Stockcode = "";
                    deliveryModel.Stockflag = "OMS";
                    deliveryModel.Createdate = DateTime.Now.ToString("yyyyMMdd");
                    deliveryModel.Wmskey = "";
                    deliveryModel.Itemno = "";

                    listPostItems.Add(deliveryModel);
                }

                List<ZWMSReturnModel> postReturn = new List<ZWMSReturnModel>();
                entity.DeliveryOrders = listPostItems;
                entity.Result = postReturn;

                if (entity.Validate())
                {
                    SapStructureService<PostDeliveryOrderEntity>.GetSAPRFCEntity(entity);
                }

                if (entity.Result != null && entity.Result.Count > 0)
                {
                    if (entity.Result[0].Status == "S")
                    {
                        //过账成功，更新OMS发货单状态
                    }
                    else
                    {
                        errorMessage = entity.Result[0].Message;
                    }
                }
                else
                {
                    errorMessage = "过账失败";
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
            // }
        }
    }
}
