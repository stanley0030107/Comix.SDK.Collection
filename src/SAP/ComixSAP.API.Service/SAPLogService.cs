
using ComixCDP.Common.Entity;
using Suzsoft.Smart.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using ComixSAP.API.Service;
using ComixCDP.Common.ExtensionFuncs;
using Furion;

namespace ComixSAP.API.Service
{
    public class SAPLogService:ISAPLog
    {

        public string GetWebClientIp()
        {
            string userIP = "未获取用户IP";
            try
            {
                if (HttpContextHelper.Current == null
                 || HttpContextHelper.Current.Request == null)
                {
                    return userIP;
                }

                string CustomerIP = "";

                //CDN加速后取到的IP simone 090805
                CustomerIP = HttpContextHelper.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = HttpContextHelper.Current.Request.Headers["HTTP_X_FORWARDED_FOR"];

                if (!String.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                if (HttpContextHelper.Current.Request.Headers["HTTP_VIA"].IsNotEmpty())
                {
                    CustomerIP = HttpContextHelper.Current.Request.Headers["HTTP_X_FORWARDED_FOR"];

                    if (string.IsNullOrEmpty(CustomerIP))
                    {
                        CustomerIP = HttpContextHelper.Current.Request.Headers["REMOTE_ADDR"];
                    }
                }
                else
                {
                    CustomerIP = HttpContextHelper.Current.Request.Headers["REMOTE_ADDR"];
                }

                if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
                {
                    return HttpContextHelper.Current.Request.Host.Host;
                }
                return CustomerIP ?? userIP;
            }
            catch { }

            return userIP;

        }

        /// <summary>
        /// 新日志方法
        /// </summary>
        /// <param name="logSystem">系统编码</param>
        /// <param name="method">方法名称</param>
        /// <param name="callingJson">报文</param>
        /// <param name="title">程序入口名称</param>
        /// <returns></returns>
        public SysLogServiceEntity CreateLog(string logSystem, string method, string callingJson, string emailTitle)
        {
            SysLogServiceEntity logEntity = new SysLogServiceEntity
            {
                LOG_ID = Guid.NewGuid().ToString(),
                LOG_SYSTEM_NAME = logSystem,
                LOG_CATEGORY = method,
                LOG_KEYWORD = "",
                SERV_URL = " ",
                SERV_PARAMETER = " ",
                RTN_CODE = " ",
                RTN_MESSAGE = " ",
                ERROR_CODE = " ",
                ERROR_REASON = " ",
                EX_STACK_TRACE = " ",
                CALLER_IP = GetWebClientIp(),
                CREATE_TIME = DateTime.Now,
                LOG_TIME = DateTime.Now,
                LAST_MODIFIED_BY = "SERV",
                LAST_MODIFIED_TIME = DateTime.Now,
                EXEC_START_TIME = DateTime.Now,
                EXEC_END_TIME = DateTime.Now,
                EXEC_SECOND = 0,
                CALLING_JSON = callingJson,
                RESPONSE_JSON = " ",
                BACKFIELD_NAME_1 = "",
                BACKFIELD_NAME_2 = "",
                BACKFIELD_NAME_3 = "",
                BACKFIELD_NAME_4 = "",
                BACKFIELD_NAME_5 = "",
                BACKFIELD_VALUE_1 = "",
                BACKFIELD_VALUE_2 = "",
                BACKFIELD_VALUE_3 = "",
                BACKFIELD_VALUE_4 = "",
                BACKFIELD_VALUE_5 = "",
            };

            return logEntity;
        }

        /// <summary>
        /// 插入日志 
        /// </summary>
        /// <param name="logEntity">日志实体</param>
        /// <param name="rtnCode">Y/N编码</param>
        /// <param name="rtnMessage">错误信息</param>
        /// <param name="errorCode">异常编码</param>
        /// <param name="responseJson">返回报文</param>
        /// <param name="title"></param>
        public bool InsertLog(SysLogServiceEntity logEntity, string retCode, string rtnMessage, string errorCode, string responseJson, string exStackTrace, string emailTitle)
        {
            var touser = Furion.App.Configuration["CDP_MAIL_Maintenance_TOUser"]?? "jianbang.long@qx.com;xiansheng.zeng@qx.com";
            var ccuser = Furion.App.Configuration["CDP_MAIL_Maintenance_CCUser"]?? "song.li@qx.com;chengbo.wang@qx.com";

            try
            {
                logEntity.RTN_CODE = retCode;
                logEntity.RTN_MESSAGE = rtnMessage;
                logEntity.ERROR_CODE = errorCode;
                logEntity.EX_STACK_TRACE = exStackTrace;
                logEntity.LAST_MODIFIED_TIME = DateTime.Now;
                TimeSpan ts = DateTime.Now - logEntity.EXEC_START_TIME;
                logEntity.EXEC_END_TIME = DateTime.Now;
                logEntity.EXEC_SECOND = ts.TotalSeconds;
                logEntity.RESPONSE_JSON = responseJson;
                DataAccess.Insert(logEntity);
                if (!string.IsNullOrWhiteSpace(logEntity.ERROR_CODE) && logEntity.ERROR_CODE.Equals("500"))
                {
                    string emailKeyword = logEntity.LOG_CATEGORY + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    Send(emailKeyword, "SAP 接口访问", touser, ccuser, "" + logEntity.LOG_SYSTEM_NAME + emailTitle + "系统错误", "主键：" + logEntity.LOG_ID + "报文：" + logEntity.CALLING_JSON + "记录异常: " + logEntity.EX_STACK_TRACE + responseJson);
                }
                else if (logEntity.EXEC_SECOND > 10)
                {
                    string emailKeyword = logEntity.LOG_CATEGORY + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    Send(emailKeyword, "SAP 接口访问", touser, ccuser, "" + logEntity.LOG_SYSTEM_NAME + emailTitle + "超时,超时时间：" + logEntity.EXEC_SECOND, "主键：" + logEntity.LOG_ID + "报文：数据库访问超时");
                }

            }
            catch (Exception ex)
            {
                string emailKeyword = logEntity.LOG_CATEGORY + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                Send(emailKeyword, "SAP 接口访问", touser, ccuser, "" + logEntity.LOG_SYSTEM_NAME + emailTitle + "日志发生异常", "主键：" + logEntity.LOG_ID + "报文：" + logEntity.CALLING_JSON + "，记录日志错误异常: " + ex.StackTrace + ex.Message + responseJson);
            }
            return true;
        }
        public virtual bool Send(string keycode, string system, string touser, string ccuser, string title, string content)
        {
            //bool send = true;
            //if (!string.IsNullOrEmpty(keycode))
            //{
            //    SysEmailEntity searchEntity = new SysEmailEntity();
            //    searchEntity.EMAIL_KEYCODE = keycode;
            //    List<SysEmailEntity> emailList = DataAccess.Select(searchEntity);
            //    if (emailList != null && emailList.Count > 0)
            //        send = false;
            //}

            //if (send)
            //{
                SysEmailEntity mailEntity = new SysEmailEntity();
                mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
                mailEntity.EMAIL_KEYCODE = keycode;
                mailEntity.EMAIL_TITLE = system + ": " + title;
                mailEntity.EMAIL_TOUSER = touser;
                mailEntity.EMAIL_CCUSER = ccuser;
                mailEntity.EMAIL_CONTENT = content;
                mailEntity.ATTACHMENTS_PATH = "";
                mailEntity.EMAIL_DATE = DateTime.Now;
                mailEntity.EMAIL_SENDER = "";
                mailEntity.SEND_TIMES = 0;
                mailEntity.SEND_STATUS = 0;
                mailEntity.REMARK = "";
                mailEntity.LAST_MODIFIED_BY = "DDP";
                mailEntity.LAST_MODIFIED_TIME = DateTime.Now;

                return DataAccess.Insert(mailEntity);
            //}

            return false;
        }
    }
}
