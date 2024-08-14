using System;
using System.Collections.Generic;
using System.Data;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class GetFBL5NInfoBLL 
    {
        public virtual GetFBL5NEntity GetInvoiceInfo(string quiryDate,string customerCode, DataTable quriyConditon, out string errorMessage)
        {
            errorMessage = "";
            // try
            // {
                GetFBL5NEntity entity = new GetFBL5NEntity();


                List<GetFBL5NInputModel> inputDetails = new List<GetFBL5NInputModel>();

                foreach (DataRow dr in quriyConditon.Rows)
                {
                    GetFBL5NInputModel inputDetail = new GetFBL5NInputModel();
                    inputDetail.companyCode = dr[0].ToString();
                    inputDetail.distChannleCode = dr[1].ToString();
                    inputDetail.HKONT = dr[2].ToString();

                    inputDetails.Add(inputDetail);
                }
                entity.quiryDate = quiryDate;
                entity.customerCode = customerCode;

                entity.QueryCondition = inputDetails;

                List<GetFBL5NReturnModel> returnHead = new List<GetFBL5NReturnModel>();

                entity.ReturnData = returnHead;

                entity.Validate();
                SapStructureService<GetFBL5NEntity>.GetSAPRFCEntity(entity);

                return entity;
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!";
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "获取汇款"+ex.Message;
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
