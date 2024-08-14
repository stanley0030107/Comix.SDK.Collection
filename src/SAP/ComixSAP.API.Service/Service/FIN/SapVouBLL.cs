
using ComixB2B.Common.Entity;
using ComixCDP.Common;
using ComixCDP.Common.Entity;
using ComixCDP.EDI.Common;
using ComixSAP.Common.SAPPO.CreateSapVou;
using Suzsoft.Smart.Data;
using System;
using System.Collections.Generic;

namespace ComixSAP.API.Service.FIN
{
   /// <summary>
   /// 回款
   /// </summary>
    public class SapVouBLL
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region  CRM 回款
        /// <summary>
        /// CRM 回款
        /// </summary>
        /// <param name="callingDomain"></param>
        /// <returns></returns>
        public ResponseCreateSapVouSrvDomain CRMCreateVou(CreateSapVouSrvDomain callingDomain, List<SapExchangeRateEntity> sapExchangesList,string  curry, string ToCurry)
        {
            ResponseHeader ResponseHeader = new ResponseHeader();
            ResponseHeader.retCode = "Y";
            ResponseHeader.retErrCode = "";
            ResponseHeader.retMessage = "";

            ResponseCreateSapVouSrvBody ResponseBody = new ResponseCreateSapVouSrvBody();
            PORequestDomain<List<SapVouResquestBody>> requestDomain = new PORequestDomain<List<SapVouResquestBody>>();
            try
            {
                //log.Info("ExchangesList:" +  Newtonsoft.Json.JsonConvert.SerializeObject(sapExchangesList));
                decimal Rate = 0;
                if (curry.ToLower() == ToCurry.ToLower())
                {
                    Rate = 1;
                }
                else
                {
                    Rate =Convert.ToDecimal( sapExchangesList[0]?.ExchangeRate);
                } 
                SapVouResquestBody sapvouBody = new SapVouResquestBody();
                sapvouBody.BELNR = callingDomain.MsgBody.head.voucherNo;
                sapvouBody.BUKRS = callingDomain.MsgBody.head.companyCode;
                sapvouBody.BLART = callingDomain.MsgBody.head.voucherType;
                sapvouBody.WAERS = callingDomain.MsgBody.head.currency;
                sapvouBody.KURSF = Rate;
                sapvouBody.BLDAT = callingDomain.MsgBody.head.voucherDate;
                sapvouBody.BUDAT = callingDomain.MsgBody.head.postDate;
                sapvouBody.GJAHR = Convert.ToInt32(callingDomain.MsgBody.head.gjahr);
                sapvouBody.MONAT = Convert.ToInt32(callingDomain.MsgBody.head.monat);
                sapvouBody.BKTXT = callingDomain.MsgBody.head.voucherHeadTxt;
                sapvouBody.XBLNR = callingDomain.MsgBody.head.reference;
                sapvouBody.USERNAME = callingDomain.MsgBody.head.userName;
                sapvouBody.MSGID = callingDomain.MsgBody.head.messageId;
                sapvouBody.ZKUBUN = "30"; 
                sapvouBody.Items = new List<SapVouItem>();
                var index = 0;
                decimal FirstDMBTR = 0;
                decimal FirstWRBTR = 0;
                decimal SecondDMBTR = 0;
                decimal SecondWRBTR = 0;
                foreach (CreateSapVoucherDetailModel itemEntity in callingDomain.MsgBody.details)
                {
                    index++;
                    if (Convert.ToDecimal(itemEntity.wrbtr) == 0)
                    {
                        continue;
                    }
                    SapVouItem item = new SapVouItem();
                    item.BUZEI = index;
                    item.MSGID = sapvouBody.MSGID; 
                    switch (index)
                    {
                        case 1:
                            item.WRBTR = Convert.ToDecimal(itemEntity.wrbtr);
                            FirstWRBTR = item.WRBTR;
                            item.DMBTR = Math.Round(item.WRBTR * Rate, 2);
                            FirstDMBTR = item.DMBTR;
                            break;
                        case 2:
                            item.WRBTR = Convert.ToDecimal(itemEntity.wrbtr);
                            SecondWRBTR = item.WRBTR;
                            item.DMBTR = Math.Round(item.WRBTR * Rate, 2);
                            SecondDMBTR = item.DMBTR;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            item.WRBTR = FirstWRBTR - SecondWRBTR;
                            item.DMBTR = FirstDMBTR - SecondDMBTR;

                            break;
                        default:
                            break;
                    } 
                    item.BSCHL = itemEntity.bschl;
                    item.HKONT = itemEntity.hkont;
                    item.KURSR = Rate;
                     
                    item.ZLSCH = itemEntity.paymentConditonCode;
                    item.KUNNR = itemEntity.customerCode;
                    item.LIFNR = itemEntity.supplierCode;
                    item.ZTERM = itemEntity.paymentCode;
                    item.AUFNR = itemEntity.orderCode;
                    item.MWSKZ = itemEntity.rateCode;
                    item.SGTXT = itemEntity.Remark;
                    item.ZUONR = itemEntity.zuonr;
                    item.XREF1 = itemEntity.xref1;
                    item.XREF2 = itemEntity.xref2;
                    item.XREF3 = itemEntity.xref3;
                    item.KOSTL = itemEntity.costCenter;
                    item.PRCTR = itemEntity.profitCenter;
                    item.ZFBDT = itemEntity.zfbdt;
                    item.VALUT = itemEntity.valut;
                    item.XNEGP = itemEntity.xnegp;
                    item.RSTGR = itemEntity.reasonCode;
                    item.GSBER = itemEntity.gsber;
                    item.SPART = itemEntity.productGroup;
                    item.VKORG = itemEntity.salesOrgCode;
                    item.VTWEG = itemEntity.distChannelCode;
                    item.KNDNR = itemEntity.customerName;
                    item.WERKS = itemEntity.factoryCode;
                    item.WW003 = itemEntity.productCode;
                    item.ZBANKST = itemEntity.ZBANKST;
                    item.ZZPOSID = "";
                    if (!string.IsNullOrWhiteSpace(item.RSTGR))
                    {
                        switch (item.RSTGR.ToUpper())
                        {
                            case "1A":
                                item.ZZPOSID = "NULL";
                                break;
                            case "7A":
                                item.ZZPOSID = "YH_银行手续费";
                                break;
                        }
                    }
                    item.VBUND = "888888";

                    sapvouBody.Items.Add(item);
                }
                string errorMsg = string.Empty;
                string vouNo = string.Empty;
                requestDomain.REQUEST = new List<SapVouResquestBody>();
                requestDomain.REQUEST.Add(sapvouBody);

                log.Info("SendSapJson:" + Newtonsoft.Json.JsonConvert.SerializeObject(requestDomain));


                var response = SAPPOHelper.Send<List<SapVouResquestBody>,
                  List<SapVouResponseBody>>("CDP",
                  SAPUrlAddress.CREATE_SAP_VOU_URL,
                  nameof(SAPUrlAddress.CREATE_SAP_VOU_URL),
                  requestDomain);

                log.Info("SapResponseJson:" + Newtonsoft.Json.JsonConvert.SerializeObject(response));
                if (response.Success)
                {
                    if (response.RESPONSE != null && response.RESPONSE.Count > 0 && response.RESPONSE[0].MSGTY.ToUpper() == "S")
                    {
                        ResponseBody.vouNo = response.RESPONSE[0].BELNR.ToString();
                    }
                    else
                    {
                        ResponseHeader.retCode = "N";
                        ResponseHeader.retErrCode = "0060";
                        ResponseHeader.retMessage = response.ResponseJson;
                    }
                }
                else
                {
                    ResponseHeader.retCode = "N";
                    ResponseHeader.retErrCode = "0060";
                    ResponseHeader.retMessage = response.ResponseJson;
                }
            }
            catch (Exception ex)
            {
                ResponseHeader.retCode = "N";
                ResponseHeader.retErrCode = "0060";
                ResponseHeader.retMessage = "异常信息:" + ex.StackTrace + ex.Message;
            }

            ResponseCreateSapVouSrvDomain ResponseDomain = new ResponseCreateSapVouSrvDomain();
            ResponseDomain.MsgHeader = ResponseHeader;
            ResponseDomain.MsgBody = ResponseBody;
            return ResponseDomain;
        }
        #endregion
        #region  CDP 回款

        #endregion
    }
}
