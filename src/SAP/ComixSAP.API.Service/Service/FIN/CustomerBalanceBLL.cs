using ComixCDP.EDI.Common;
using ComixSAP.Common.SAPPO.QueryCustomerBalance;
using ComixSAP.Common.SAPPO.CustomerBalanceData;
using ComixSAP.Common.SAPPO.ReturnMoney;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ComixSAP.API.Service.FIN
{
    /// <summary>
    /// 获取余额
    /// </summary>
    public class CustomerBalanceBLL
    {
        #region QueryCustomerBalance
        /// <summary>
        /// 客户未清项查询接口
        /// </summary>
        /// <param name="callingDomain"></param>
        /// <returns></returns>
        public ResponseGetCustomerBalanceSrvDomain QueryBalance(GetCustomerBalanceSrvDomain callingDomain)
        {
            ResponseHeader ResponseHeader = new ResponseHeader();
            ResponseHeader.retCode = "Y";
            ResponseHeader.retErrCode = "";
            ResponseHeader.retMessage = "";

            ResponseGetCustomerBalanceSrvBody ResponseBody = new ResponseGetCustomerBalanceSrvBody();

            try
            {
                string errorMessage = string.Empty;
                var requestDomain = new PORequestDomain<QueryCustomerBalanceResquestBody>();
                requestDomain.REQUEST = new QueryCustomerBalanceResquestBody();
                requestDomain.REQUEST.MSGID = DateTime.Now.ToString("yyyyMMddHHmmss");
                requestDomain.REQUEST.KUNNR = callingDomain.MsgBody.customerCode;
                requestDomain.REQUEST.ALLGSTID = callingDomain.MsgBody.InquiryDate;
                requestDomain.REQUEST.IT_BSID = new List<QueryCustomerBalanceResquestItem>();
                foreach (var item in callingDomain.MsgBody.conditionList)
                {
                    QueryCustomerBalanceResquestItem requestItem = new QueryCustomerBalanceResquestItem();
                    requestItem.HKONT = item.HKONT;
                    requestItem.BUKRS = item.companyCode;
                    requestItem.VTWEG = item.disChannelCode;
                    requestDomain.REQUEST.IT_BSID.Add(requestItem);
                }
                var response = SAPPOHelper.Send<QueryCustomerBalanceResquestBody,
             QueryCustomerBalanceResponseBody>("CDP",
             SAPUrlAddress.ZCRM_READ_FBL5N_URL,
             nameof(SAPUrlAddress.ZCRM_READ_FBL5N_URL),
             requestDomain);
                List<CustomerBalanceModel> balances = new List<CustomerBalanceModel>();
                if (response != null && response.Success && response.RESPONSE.MSGTY.Equals("S"))
                {
                    foreach (var item in response.RESPONSE.ET_FBL5N)
                    {
                        CustomerBalanceModel returnModel = new CustomerBalanceModel();
                        returnModel.companyCode = item.COMP_CODE;//COMP_CODE
                        returnModel.customerCode = item.CUSTOMER;
                        returnModel.spGlInd = item.SP_GL_IND;
                        returnModel.clearDate = item.CLEAR_DATE;
                        returnModel.clearDocNo = item.CLR_DOC_NO;
                        returnModel.allocNumber = item.ALLOC_NMBR;
                        returnModel.fiscYear = item.FISC_YEAR.ToString();
                        returnModel.docNo = item.DOC_NO;
                        returnModel.itemNum = item.ITEM_NUM.ToString();
                        returnModel.pstngDate = item.PSTNG_DATE;
                        returnModel.docDate = item.DOC_DATE;
                        returnModel.entryDate = item.ENTRY_DATE;
                        returnModel.currency = item.CURRENCY;
                        returnModel.locCurrency = item.LOC_CURRCY;
                        returnModel.refDocNo = item.REF_DOC_NO;
                        returnModel.docType = item.DOC_TYPE;
                        returnModel.fisType = item.FIS_PERIOD.ToString();
                        returnModel.postKey = item.POST_KEY;
                        returnModel.dbCrInd = item.DB_CR_IND;
                        returnModel.busArea = item.BUS_AREA;
                        returnModel.taxCode = item.TAX_CODE;
                        returnModel.lcAmount = item.LC_AMOUNT.ToString();
                        returnModel.amountDoccur = item.AMT_DOCCUR.ToString();
                        returnModel.lcTax = item.LC_TAX.ToString();
                        returnModel.txDocCur = item.TX_DOC_CUR.ToString();
                        returnModel.itemText = item.ITEM_TEXT;
                        returnModel.branch = item.BRANCH;
                        returnModel.blineDate = item.BLINE_DATE;
                        returnModel.paymentCode = item.PAYEE_CODE;
                        returnModel.discountDays1 = item.DSCT_DAYS1.ToString();
                        returnModel.discountDays2 = item.DSCT_DAYS2.ToString();
                        returnModel.netterms = item.NETTERMS.ToString();
                        returnModel.dsctPct1 = item.DSCT_PCT1.ToString();
                        returnModel.dsctPct2 = item.DSCT_PCT2.ToString();
                        returnModel.discBase = item.DISC_BASE.ToString();
                        returnModel.discountAmountLc = item.DSC_AMT_LC.ToString();
                        returnModel.discountAmountDc = item.DSC_AMT_DC.ToString();
                        returnModel.paymentType = item.PMNTTRMS;
                        returnModel.paymentBlock = item.PMNT_BLOCK;
                        returnModel.fixedterms = item.FIXEDTERMS;
                        returnModel.invoiceRef = item.INV_REF;
                        returnModel.invoiceYear = item.INV_YEAR.ToString();
                        returnModel.invoiceItem = item.INV_ITEM.ToString();
                        returnModel.dunnBlock = item.DUNN_BLOCK;
                        returnModel.dunnKey = item.DUNN_KEY;
                        returnModel.lastDunn = item.LAST_DUNN;
                        returnModel.dunnLevel = item.DUNN_LEVEL.ToString();
                        returnModel.dunnArea = item.DUNN_AREA;
                        returnModel.docStatus = item.DOC_STATUS;
                        returnModel.netDocType = item.NXT_DOCTYP;
                        returnModel.vatRegNo = item.VAT_REG_NO;
                        returnModel.reasonCode = item.REASON_CDE;
                        returnModel.paymentSupl = item.PMTMTHSUPL;
                        returnModel.refKey1 = item.REF_KEY_1;
                        returnModel.refKey2 = item.REF_KEY_2;
                        returnModel.tCurrency = item.T_CURRENCY;
                        returnModel.amount = item.AMOUNT.ToString();
                        returnModel.netAmount = item.NET_AMOUNT.ToString();
                        returnModel.name = item.NAME;
                        returnModel.name2 = item.NAME_2;
                        returnModel.name3 = item.NAME_3;
                        returnModel.name4 = item.NAME_4;
                        returnModel.postCode = item.POSTL_CODE;
                        returnModel.cityCode = item.CITY;
                        returnModel.country = item.COUNTRY;
                        returnModel.street = item.STREET;
                        returnModel.poBox = item.PO_BOX;
                        returnModel.pobxPCD = item.POBX_PCD;
                        returnModel.pobkCurac = item.POBK_CURAC;
                        returnModel.bankAccount = item.BANK_ACCT;
                        returnModel.bankKey = item.BANK_KEY;
                        returnModel.bankCountryCode = item.BANK_CTRY;
                        returnModel.taxNO1 = item.TAX_NO_1;
                        returnModel.taxNo2 = item.TAX_NO_2;
                        returnModel.tax = item.TAX;
                        returnModel.equalTax = item.EQUAL_TAX;
                        returnModel.region = item.REGION;
                        returnModel.ctrlKey = item.CTRL_KEY;
                        returnModel.instrKey = item.INSTR_KEY;
                        returnModel.paymentCode = item.PMNTTRMS;
                        returnModel.lanuage = item.LANGU;
                        returnModel.billValidDate = item.BILL_LIFE.ToString();
                        returnModel.beTaxCode = item.BE_TAXCODE;
                        returnModel.billTaxLC = item.BILLTAX_LC.ToString();
                        returnModel.billTaxFC = item.BILLTAX_FC.ToString();
                        returnModel.lcColChg = item.LC_COL_CHG.ToString();
                        returnModel.collCharg = item.COLL_CHARG.ToString();
                        returnModel.chgsTxCd = item.CHGS_TX_CD;
                        returnModel.issueDate = item.ISSUE_DATE;
                        returnModel.usageDate = item.USAGEDATE;
                        returnModel.billUsage = item.BILL_USAGE;
                        returnModel.domicile = item.DOMICILE;
                        returnModel.drawer = item.DRAWER;
                        returnModel.ctrbankLoc = item.CTRBNK_LOC;
                        returnModel.drawCity1 = item.DRAW_CITY1;
                        returnModel.drawee = item.DRAWEE;
                        returnModel.drawCity2 = item.DRAW_CITY2;
                        returnModel.disctDays = item.DISCT_DAYS.ToString();
                        returnModel.disctRate = item.DISCT_RATE.ToString();
                        returnModel.accepted = item.ACCEPTED;
                        returnModel.billStatus = item.BILLSTATUS;
                        returnModel.prtestInd = item.PRTEST_IND;
                        returnModel.beDemand = item.BE_DEMAND;
                        returnModel.objType = item.OBJ_TYPE;
                        returnModel.refLoc = item.REF_DOC_NO;
                        returnModel.refOrgUn = item.REF_ORG_UN;
                        returnModel.reversalLoc = item.REVERSAL_DOC;
                        returnModel.spGlType = item.SP_GL_TYPE;
                        returnModel.negPosting = item.NEG_POSTNG;
                        returnModel.faedt = item.FAEDT;
                        returnModel.verzn = item.VERZN;
                        balances.Add(returnModel);
                    }
                    ResponseBody.returnData = balances;
                }
                else
                {
                    ResponseHeader.retCode = "N";
                    ResponseHeader.retErrCode = "0060";
                    ResponseHeader.retMessage = "异常信息:" + response.ResponseJson;
                }

            }
            catch (Exception ex)
            {
                ResponseHeader.retCode = "N";
                ResponseHeader.retErrCode = "0060";
                ResponseHeader.retMessage = "异常信息:" + ex.StackTrace + ex.Message;
            }

            ResponseGetCustomerBalanceSrvDomain ResponseDomain = new ResponseGetCustomerBalanceSrvDomain();
            ResponseDomain.MsgHeader = ResponseHeader;
            ResponseDomain.MsgBody = ResponseBody;
            return ResponseDomain;
        }
        #endregion
        /// <summary>
        /// 分销获取客户信贷信息(SD-088)
        /// </summary>
        /// <param name="enterpriseCode">客编</param>
        /// <param name="BUKRS">公司编码</param>
        /// <returns></returns>
        public DataTable CustomerBalanceData(string enterpriseCode, string BUKRS)
        {
            #region PO请求

            #region 请求参数处理

            PORequestDomain<CustomerBalanceDataResquestBody> reqDomain = new PORequestDomain<CustomerBalanceDataResquestBody>();
            CustomerBalanceDataResquestBody req = new CustomerBalanceDataResquestBody();
            reqDomain.REQUEST = req;
            req.PARTNER = enterpriseCode;
            req.BUKRS = BUKRS;//默认值为1100;
            #endregion

            List<POResponseDomain<List<CustomerBalanceDataResponseBody>>> resList = new List<POResponseDomain<List<CustomerBalanceDataResponseBody>>>();

            #region 发出请求
            req.CREDIT_SGMNT = "2000";
            var res = SAPPOHelper.Send<CustomerBalanceDataResquestBody, List<CustomerBalanceDataResponseBody>>("CDP", SAPUrlAddress.ZDRPBALANCE_URL, "GetRealDataFromSAPNew", reqDomain);
            resList.Add(res);
            req.CREDIT_SGMNT = "2500";
            res = SAPPOHelper.Send<CustomerBalanceDataResquestBody, List<CustomerBalanceDataResponseBody>>("CDP", SAPUrlAddress.ZDRPBALANCE_URL, "GetRealDataFromSAPNew", reqDomain);
            resList.Add(res);
            #endregion

            #region 处理请求结果，适配原来的数据格式
            DataTable dt = new DataTable();
            //dt.Columns.Add("LV_SKFOR");
            dt.Columns.Add("BUKRS");
            dt.Columns.Add("KUNNR");
            dt.Columns.Add("KKBER");
            dt.Columns.Add("KLIMK");
            dt.Columns.Add("SAUFT");
            dt.Columns.Add("SKFOR");
            dt.Columns.Add("CTLPC");
            dt.Columns.Add("SSOBL");
            dt.Columns.Add("OBLIG");
            dt.Columns.Add("KLPRZ");
            dt.Columns.Add("AMOUNT_H");
            dt.Columns.Add("ZTERM");
            dt.Columns.Add("VTEXT");
            dt.Columns.Add("DMBTR");
            dt.Columns.Add("DMBTR_7");
            dt.Columns.Add("DMBTR_15");
            dt.Columns.Add("DMBTR_NPD");
            dt.Columns.Add("DCL_FYD");
            dt.Columns.Add("CLZ_YD");
            dt.Columns.Add("ZRSV01");
            dt.Columns.Add("ZRSV02");
            foreach (var item in resList)
            {
                if (item.RESPONSE != null)
                {
                    DataRow dr = dt.NewRow();
                    //dr["LV_SKFOR"] = item.RESPONSE[0].LV_SKFOR;
                    dr["BUKRS"] = item.RESPONSE[0].BUKRS;
                    dr["KUNNR"] = item.RESPONSE[0].KUNNR;
                    dr["KKBER"] = item.RESPONSE[0].KKBER;
                    dr["KLIMK"] = item.RESPONSE[0].KLIMK;
                    dr["SAUFT"] = item.RESPONSE[0].SAUFT;
                    dr["SKFOR"] = item.RESPONSE[0].SKFOR;
                    dr["CTLPC"] = item.RESPONSE[0].CTLPC;
                    dr["SSOBL"] = item.RESPONSE[0].SSOBL;
                    dr["OBLIG"] = item.RESPONSE[0].OBLIG;
                    dr["KLPRZ"] = item.RESPONSE[0].KLPRZ;
                    dr["AMOUNT_H"] = item.RESPONSE[0].AMOUNT_H;
                    dr["ZTERM"] = item.RESPONSE[0].ZTERM;
                    dr["VTEXT"] = item.RESPONSE[0].VTEXT;
                    dr["DMBTR"] = item.RESPONSE[0].DMBTR;
                    dr["DMBTR_7"] = item.RESPONSE[0].DMBTR_7;
                    dr["DMBTR_15"] = item.RESPONSE[0].DMBTR_15;
                    dr["DMBTR_NPD"] = item.RESPONSE[0].DMBTR_NPD;
                    dr["DCL_FYD"] = item.RESPONSE[0].DCL_FYD;
                    dr["CLZ_YD"] = item.RESPONSE[0].CLZ_YD;
                    dr["ZRSV01"] = item.RESPONSE[0].ZRSV01 == null ? "0" : item.RESPONSE[0].ZRSV01.Trim();
                    dr["ZRSV02"] = item.RESPONSE[0].ZRSV02;
                    dt.Rows.Add(dr);
                }
            }
            #endregion

            return dt;
            #endregion

        }
        /// <summary>
        /// 获取客户其他余额(FICO-099)
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="HKONT"></param>
        /// <returns></returns>
        public decimal? ReturnMoney(string enterpriseCode, string HKONT)
        {
            PORequestDomain<List<ReturnMoneyResquestBody>> reqDomain = new PORequestDomain<List<ReturnMoneyResquestBody>>();
            var reqBody = new ReturnMoneyResquestBody();
            reqBody.KUNNR = enterpriseCode;
            reqBody.HKONT = HKONT;
            reqDomain.REQUEST = new List<ReturnMoneyResquestBody>();
            reqDomain.REQUEST.Add(reqBody);
            var res = SAPPOHelper.Send<List<ReturnMoneyResquestBody>, ReturnMoneyResponseBody[]>("CDP", SAPUrlAddress.FICO099_RETURN_MONEY_URL, "fico099_ReturnMoney", reqDomain);
            if (res.RESPONSE.Length > 0 && res.RESPONSE[0].DMBTR != null)
            {
                return decimal.Parse(res.RESPONSE[0].DMBTR);
            }
            else
            {
                return null;
            }

        }
    }
}
