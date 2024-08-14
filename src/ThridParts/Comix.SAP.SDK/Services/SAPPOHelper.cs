using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Services
{
    public class SAPPOHelper
    {
        public static string POUrl { get { return Furion.App.Configuration["SAP_PO_URL"]; } }

        public static string POUser { get { return Furion.App.Configuration["SAP_PO_USER"]; } }

        public static string POPwd { get { return Furion.App.Configuration["SAP_PO_PWD"]; } }

        /// <summary>
        /// PO接口是否启用
        /// </summary>
        public static bool POIsEnable { get { return Furion.App.Configuration["SAP_PO_ENABLE"] == "1"; } }



        /// <summary>
        /// PO请求
        /// </summary>
        /// <typeparam name="Rquest">请求泛型主体</typeparam>
        /// <typeparam name="Response">响应泛型主体</typeparam>
        /// <param name="logService">请求日志处理逻辑类</param>
        /// <param name="systemCode">系统编码</param>
        /// <param name="url">请求地址</param>
        /// <param name="urlCategoryName">请求类型</param>
        /// <param name="requestBody">请求主体</param>
        /// <param name="requestTimeout">请求时间</param>
        /// <returns></returns>
        public static POResponseDomain<Res> Send<Rq, Res>(
            string systemCode,
            string url,
            string urlCategoryName,
            PORequestDomain<Rq> requestBody,
            int requestTimeout = 30)
        {
            string exStackTrace = "";
            string errorCode = "";
            string rtnMessage = "";
            string strResult = "";
            POResponseDomain<Res> responseDomain = new POResponseDomain<Res>();
            if (requestBody == null || string.IsNullOrWhiteSpace(systemCode) || requestBody.REQUEST == null)
            {
                responseDomain.Success = false;
                responseDomain.ResponseJson = "请求主体或系统编码为空";
                return responseDomain;
            }
            requestBody.SYSID = systemCode;
            string callingJson = JsonConvert.SerializeObject(requestBody);
            var logEntity = POService.LogService.CreateLog(systemCode, urlCategoryName, callingJson, urlCategoryName);
            try
            {

                using (var client = new MyWebClient(requestTimeout))
                {
                    //client.Timeout = requestTimeout;
                    client.Headers["Authorization"] = "Basic " + GetEncodedCredentials();
                    client.Headers["Content-Type"] = "application/json;charset=UTF-8";
                    client.Encoding = Encoding.UTF8;
                    strResult = client.UploadString(POUrl + url, callingJson);
                    if (!string.IsNullOrWhiteSpace(strResult))
                    {
                        responseDomain = JsonConvert.DeserializeObject<POResponseDomain<Res>>(strResult);
                        responseDomain.Success = true;
                        responseDomain.ResponseJson = strResult;
                    }
                }
            }
            catch (Exception ex)
            {
                exStackTrace = ex.InnerException != null ? ex.InnerException.ToString() : ex.ToString();
                errorCode = "500";
                rtnMessage = "系统异常";
                if (responseDomain == null)
                {
                    responseDomain = new POResponseDomain<Res>();
                }
                responseDomain.ResponseJson = "报文：" + strResult + "。异常信息:" + ex.Message;
                responseDomain.Success = false;
            }
            if (POService.LogService != null)
            {
                POService.LogService.InsertLog(logEntity, responseDomain.Success ? "Y" : "N",
                rtnMessage, errorCode, responseDomain.ResponseJson, exStackTrace, urlCategoryName);
            }

            return responseDomain;
        }


        /// <summary>
        /// PO 查询请求
        /// </summary>
        /// <typeparam name="Rquest">请求 QuerySAPALLRequest 主体</typeparam>
        /// <typeparam name="Response">响应泛型主体</typeparam>
        /// <typeparam name="log">请求日志实体</typeparam>
        /// <param name="logService">请求日志处理逻辑类</param>
        /// <param name="systemCode">系统编码</param>
        /// <param name="url">请求地址</param>
        /// <param name="urlCategoryName">请求类型</param>
        /// <param name="requestBody">请求主体</param>
        /// <param name="requestTimeout">请求时间</param>
        /// <returns></returns>
        public static POResponseDomain<Res> Send<Res>(

            string systemCode,
            string url,
            string urlCategoryName,
            QuerySAPALLRequestDomain requestBody,
            int requestTimeout = 30)
        {
            string exStackTrace = "";
            string errorCode = "";
            string rtnMessage = "";
            string strResult = "";
            POResponseDomain<Res> responseDomain = new POResponseDomain<Res>();
            if (requestBody == null || string.IsNullOrWhiteSpace(requestBody.KEYNAME) || string.IsNullOrWhiteSpace(systemCode) || requestBody.ID_TABLE == null || requestBody.ID_TABLE.Count <= 0)
            {
                responseDomain.Success = false;
                responseDomain.ResponseJson = "请求主体或系统编码为空";
                return responseDomain;
            }
            requestBody.SYSID = systemCode;
            string callingJson = JsonConvert.SerializeObject(requestBody);
            var logEntity = POService.LogService.CreateLog(systemCode, urlCategoryName, callingJson, callingJson);
            try
            {
                using (var client = new MyWebClient(requestTimeout))
                {
                    //client.Timeout = requestTimeout;
                    client.Headers["Authorization"] = "Basic " + GetEncodedCredentials();
                    client.Headers["Content-Type"] = "application/json;charset=UTF-8";
                    client.Encoding = Encoding.UTF8;
                    strResult = client.UploadString(POUrl + url, callingJson);
                    if (!string.IsNullOrWhiteSpace(strResult))
                    {
                        responseDomain = JsonConvert.DeserializeObject<POResponseDomain<Res>>(strResult);
                        responseDomain.Success = true;
                        responseDomain.ResponseJson = strResult;
                    }
                }
            }
            catch (Exception ex)
            {
                exStackTrace = ex.ToString();
                errorCode = "500";
                rtnMessage = "系统异常";
                if (responseDomain == null)
                {
                    responseDomain = new POResponseDomain<Res>();
                }
                responseDomain.ResponseJson = "报文：" + strResult + "。异常信息:" + ex.Message;

                responseDomain.Success = false;
            }
            if (POService.LogService != null)
            {
                POService.LogService.InsertLog(logEntity, responseDomain.Success ? "Y" : "N",
                rtnMessage, errorCode, responseDomain.ResponseJson, exStackTrace, urlCategoryName);
            }

            return responseDomain;
        }


        /// <summary>
        /// 生成 Authorization
        /// </summary>
        /// <returns></returns>
        private static string GetEncodedCredentials()
        {
            string mergedCredentials = string.Format("{0}:{1}", POUser, POPwd);
            byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }
    }
}
