using System;
using System.Collections.Generic;
using System.Data;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class GetInvoiceInfoBLL 
    {
        public virtual GetInvoiceEntity GetInvoiceInfo(string startDate, string endDate, DataTable dtDetails, out string errorMessage)
        {
            errorMessage = "";
            // try
            // {
                GetInvoiceEntity entity = new GetInvoiceEntity();

  
                List<GetInvoiceInputModel> inputDetails = new List<GetInvoiceInputModel>();

                foreach (DataRow dr in dtDetails.Rows)
                {
                    GetInvoiceInputModel inputDetail = new GetInvoiceInputModel();
                    inputDetail.SalesOrgCode = dr[0].ToString();
                    inputDetail.DistChannelCode = dr[1].ToString();

                    inputDetails.Add(inputDetail);
                }
                entity.StartDate = startDate;
                entity.EndDate = endDate;
                entity.GetInvoiceInput = inputDetails;

                List<GetInvoiceReturnHeadModel> returnHead = new List<GetInvoiceReturnHeadModel>();
                List<GetInvoiceReturnDetailModel> returnDetail = new  List<GetInvoiceReturnDetailModel>();

                entity.GetInvoiceHead = returnHead;
                entity.GetInvoiceDetail = returnDetail;

                entity.Validate();
                SapStructureService<GetInvoiceEntity>.GetSAPRFCEntity(entity);

                return entity;
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!";
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "获取发票信息错误"+ex.Message;
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
            //     return null;
            // }
        }
    }
}
