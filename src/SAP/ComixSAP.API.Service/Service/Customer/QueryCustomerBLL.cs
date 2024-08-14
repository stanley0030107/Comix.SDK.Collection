
using ComixSAP.Common.SAPPO.QueryCustomerMaster;
using System.Collections.Generic;
using System.Linq;
namespace ComixSAP.API.Service.Customer
{
   /// <summary>
   /// 回款
   /// </summary>
    public class QueryCustomerBLL
    {
        /// <summary>
        ///  通过客户名称查询客户编码 关键字 CLIENT1
        /// </summary>
        /// <param name="customerName">名称</param>
        /// <param name="saleOrgCode">销售组织</param>
        /// <param name="strResult">结果</param>
        /// <returns></returns>
        public bool QueryCustomer(string customer, string saleOrgCode, ref string strCode, ref string strName)
        {
            QuerySAPALLRequestDomain requestDomain = new QuerySAPALLRequestDomain();
            requestDomain.KEYNAME = "CLIENT_COMPANY1";
            requestDomain.ID_TABLE = new List<QuerySAPALLRequestBody> {
                    new QuerySAPALLRequestBody {
                         FIELDID=customer
                    }
                };
            var response = SAPPOHelper.Send<List<QueryCustomerMasterResponseBody>>("CDP",
              SAPUrlAddress.QUERY_SAP_VOU_URL,
              nameof(SAPUrlAddress.QUERY_SAP_VOU_URL),
              requestDomain);
            if (response.Success)
            {
                if (response.RESPONSE != null && response.RESPONSE.Count > 0 && !string.IsNullOrEmpty(response.RESPONSE[0].FIELDNAME1))
                {
                    QueryCustomerMasterResponseBody resultCustomer = response.RESPONSE.Where(x =>!string.IsNullOrWhiteSpace(x.FIELDNAME2) && x.FIELDNAME2.Equals(saleOrgCode)).FirstOrDefault();
                    if (resultCustomer==null&& response.RESPONSE.Count >= 1)
                    {
                        resultCustomer = response.RESPONSE.Where(x => !string.IsNullOrWhiteSpace(x.FIELDNAME2) && !x.FIELDNAME2.Equals("8000")).FirstOrDefault();
                    }
                    if (resultCustomer != null)
                    {
                        strCode = resultCustomer.FIELDNAME1.TrimStart('0');
                        strName = resultCustomer.FIELDID;
                        return true;
                    }

                }
            }
            strCode = "编码未找到";
            return false;
        }
    }
}
