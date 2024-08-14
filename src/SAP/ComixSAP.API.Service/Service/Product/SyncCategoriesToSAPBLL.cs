
using ComixB2B.Common.Entity;
using ComixCDP.Common;
using ComixCDP.Common.Entity;
using ComixCDP.EDI.Common;
using ComixSAP.Common.SAPPO.CCProductCategory;
using ComixSAP.Common.SAPPO.CreateSapVou;
using Suzsoft.Smart.Data;
using System;
using System.Collections.Generic;

namespace ComixSAP.API.Service.Product
{
   /// <summary>
   /// 同步CC分类到SAP
   /// </summary>
    public class SyncCategoriesToSAPBLL
    {
        #region 同步CC分类到SAP
        /// <summary>
        /// 同步CC分类到SAP
        /// </summary>
        public ResponseSyncProductToCCSrvDomain Send(SyncProductToCCSrvDomain callingDomain)
        {
            ResponseSyncProductToCCSrvDomain responseDomain = new ResponseSyncProductToCCSrvDomain()
            {
                MsgHeader = new ResponseHeader()
                {
                    retCode = "N",
                    retErrCode = "0060"
                },
                MsgBody = new ResponseSyncProductToCCSrvBody
                {
                }
            };
            ResponseSyncProductToCCSrvBody ResponseBody = new ResponseSyncProductToCCSrvBody();
            string errorMsg = string.Empty;

            var requestDomain = new PORequestDomain<List<CCProductCategoryResquestBody>>();
            requestDomain.REQUEST = new List<CCProductCategoryResquestBody>() {
                    new CCProductCategoryResquestBody {
                        MSGID=DateTime.Now.ToString("yyyyMMddHH")+callingDomain.MsgBody.model.categoryCode3,
                        MATNR=callingDomain.MsgBody.model.sapSkuCode,
                        PRODH1= callingDomain.MsgBody.model.categoryCode1,
                        VTEXT1= callingDomain.MsgBody.model.categoryName1,
                        PRODH2= callingDomain.MsgBody.model.categoryCode2,
                        VTEXT2= callingDomain.MsgBody.model.categoryName2,
                        PRODH3= callingDomain.MsgBody.model.categoryCode3,
                        VTEXT3= callingDomain.MsgBody.model.categoryName3,
                    }
                };

            var response = SAPPOHelper.Send<List<CCProductCategoryResquestBody>,
               List<CCProductCategoryResponseBody>>("CDP",
               SAPUrlAddress.ZDRP_INSERT_ZTPRODH_URL,
               nameof(SAPUrlAddress.ZDRP_INSERT_ZTPRODH_URL),
               requestDomain);
            if (response != null && response.Success && response.RESPONSE != null && response.RESPONSE.Count > 0 && response.RESPONSE[0].MSGTY.Equals("S"))
            {
                responseDomain.MsgHeader.retCode = "Y";
                responseDomain.MsgHeader.retErrCode = "";
                responseDomain.MsgHeader.retMessage = "";
            }
            else
            {
                responseDomain.MsgHeader.retMessage = response.ResponseJson;
            }
            return responseDomain;
        }
        #endregion
    }
}
