using ComixCDP.EDI.Common;
using ComixSAP.API.Service.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ComixSAP.API.Service.RPC
{
    public class QueryOmsInvoiceBLL
    {
        /// <summary>
        /// 查询发票信息
        /// </summary>
        /// <typeparam name="T">返回结果</typeparam>
        /// <param name="requestBody">请求参数</param>
        /// <returns></returns>
        public ResponseInquiryInvoiceInfoSrvDomain Query(InquiryInvoiceInfoSrvBody requestBody)
        {
            ResponseInquiryInvoiceInfoSrvDomain responseDomain = new ResponseInquiryInvoiceInfoSrvDomain() {
                MsgHeader= new ResponseHeader {
                     retCode="Y",
                    
                },
                MsgBody=new ResponseInquiryInvoiceInfoSrvBody {
                }
            };
            RpcResponseDomain<RpcQueryResponseModel<QueryInvoiceResponseModel>> response = new RpcResponseDomain<RpcQueryResponseModel<QueryInvoiceResponseModel >> ();
            RpcQueryModel<Dictionary<string, string>> model = new RpcQueryModel<Dictionary<string, string>>();
            model.@params.conds.Conds = new Dictionary<string, string>();
            model.@params.conds.PageInfo = null;
            // model.@params.conds.Conds.Add("Key", keyWord);
            string fkdat = "";//日期
            if (!string.IsNullOrWhiteSpace(requestBody.startDate))
            {
                fkdat = requestBody.startDate;
                fkdat += "->";
            }
            if (!string.IsNullOrWhiteSpace(requestBody.endDate))
            {
                if (string.IsNullOrWhiteSpace(fkdat))
                {
                    fkdat += "->";
                }
                fkdat += requestBody.endDate;
            }
            string requestItem = "";
            if (requestBody.conditionList!=null&& requestBody.conditionList.Count>0)
            {
                requestItem = JsonConvert.SerializeObject(requestBody.conditionList);
                requestItem = requestItem.Replace("salesOrg", "BUKRS").Replace("disChannelCode", "VTWEG");
            }
            model.@params.conds.Conds.Add("FKDAT", fkdat);
            model.@params.conds.Conds.Add("EW_VBRP", requestItem);
            model.method = "OMS.Invoice.GetPageList";
            response = RpcHelper.RpcSend<Dictionary<string, string>, RpcQueryResponseModel<QueryInvoiceResponseModel>>("CRM", model);
            List<InvoiceHead> invoices = new List<InvoiceHead>();
            if (response != null && response.Success)
            {
                List<string> listInvoiceCode = new List<string>();
                foreach (var item in response.result.PageData)
                {
                    if (listInvoiceCode.Contains(item.VBELN))
                    {
                        continue;
                    }
                    listInvoiceCode.Add(item.VBELN);
                    InvoiceHead head = new InvoiceHead();
                    head.invocieDetail = new List<InvocieDetail>();
                    head.soldToCode = item.KUNNR;
                    head.soldToName = item.KUNNR_NAME;
                    head.paymentCode = item.KUNRG;
                    head.paymentName = item.KUNRG_NAME;
                    head.receivedInvocieCode = item.KUNRE;
                    head.receivedInvoiceName = item.KUNRE_NAME;
                    head.invoiceCode = item.VBELN;
                    head.salesOrgCode = item.VKORG;
                    head.distChannelCode = item.VTWEG;
                    head.companyCode = item.BUKRS;
                    head.invoiceDate = item.FKDAT;
                    if (!string.IsNullOrWhiteSpace(head.invoiceDate) && head.invoiceDate.IndexOf('-')==-1 && head.invoiceDate.Length==8)
                    {
                        head.invoiceDate = DateTime.ParseExact(head.invoiceDate,"yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                    }
                    head.currency = item.WAERK;
                    head.voucherCode = item.SFAKN;
                    decimal totalAmount = 0;

                    if (item.Details != null && item.Details.Count > 0)
                    {
                        foreach (var detailItem in item.Details)
                        {
                            InvocieDetail detail = new InvocieDetail();
                            detail.invoiceCode = detailItem.VBELN;
                            detail.itemNo = detailItem.POSNR;
                            detail.productCode = detailItem.MATNR;
                            detail.productName = detailItem.MAKTX;
                            detail.baseUnit = detailItem.MEINS;
                            detail.salesUnit = detailItem.VRKME;
                            detail.baseUnitQty = detailItem.FKLMG;
                            detail.salesUnitQty = detailItem.FKIMG;
                            detail.amount = detailItem.AMOUNT?.ToString();
                            detail.taxRate = detailItem.KURRF?.ToString();
                            detail.price = detailItem.PRICE?.ToString();
                            detail.costPrice = detailItem.KBETR?.ToString();
                            if (detailItem.NETWR.HasValue && detailItem.MWSBP.HasValue && detailItem.KURRF.HasValue)
                            {
                                detail.amountCny = ((detailItem.NETWR.Value + detailItem.MWSBP.Value) *detailItem.KURRF.Value).ToString();
                            }
                            detail.factoryCode = detailItem.WERKS;
                            head.invocieDetail.Add(detail);
                            totalAmount += detailItem.AMOUNT.Value;
                        }
                    }
                    head.invoiceAmount = totalAmount.ToString();
                    invoices.Add(head);
                }
            }
            else
            {
                responseDomain.MsgHeader.retCode = "N";
                responseDomain.MsgHeader.retMessage = response.ResponseJson;
            }
            responseDomain.MsgBody.invoicesList = invoices;
            return responseDomain;

        }
        
    }
}
