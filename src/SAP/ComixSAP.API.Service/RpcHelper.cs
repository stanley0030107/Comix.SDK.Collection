using Furion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ComixSAP.API.Service
{
    public  class RpcHelper
    {
        public static string RpcUrl { get { return Furion.App.Configuration["RPC_URL"]; } }

        /// <summary>
        /// Rpc查询方法
        /// </summary>
        /// <typeparam name="R">查询参数</typeparam>
        /// <typeparam name="Res">返回值</typeparam>
        /// <param name="systemCode">入口</param>
        /// <param name="model">请求参数</param>
        /// <param name="requestTimeout"></param>
        /// <returns></returns>
        public static RpcResponseDomain<Res> RpcSend<R, Res>(
    string systemCode,
    Common.RpcQueryModel<R> model,
    int requestTimeout = 5)
        {
            string exStackTrace = "";
            string errorCode = "";
            string rtnMessage = "";
            string strResult = "";
            RpcResponseDomain<Res> responseDomain = new RpcResponseDomain<Res>();
            if (model == null)
            {
                responseDomain.Success = false;
                responseDomain.ResponseJson = "请求主体或系统编码为空";
                return responseDomain;
            }
            string callingJson = JsonConvert.SerializeObject(model);
            var logEntity = POService.LogService.CreateLog(systemCode, model.method, callingJson, callingJson);
            try
            {
                using (var client = new MyWebClient(requestTimeout))
                {
                    //client.Timeout = requestTimeout;
                    //client.Headers["Authorization"] = "Basic " + GetEncodedCredentials();
                    //client.Headers["Content-Type"] = "application/json;charset=UTF-8";
                    client.Encoding = Encoding.UTF8;
                    strResult = client.UploadString(RpcUrl, callingJson);
                    if (!string.IsNullOrWhiteSpace(strResult))
                    {
                        responseDomain = JsonConvert.DeserializeObject<RpcResponseDomain<Res>>(strResult);
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
                    responseDomain = new RpcResponseDomain<Res>();
                }
                responseDomain.ResponseJson = "报文：" + strResult + "。异常信息:" + ex.Message;

                responseDomain.Success = false;
            }
            if (POService.LogService != null)
            {
                POService.LogService.InsertLog(logEntity, responseDomain.Success ? "Y" : "N",
                rtnMessage, errorCode, responseDomain.ResponseJson, exStackTrace, model.method);
            }

            return responseDomain;
        }
    }
}
