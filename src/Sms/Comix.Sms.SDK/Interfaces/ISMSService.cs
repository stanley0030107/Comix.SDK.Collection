using Comix.Sms.SDK.ReqModels;
using Comix.Sms.SDK.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Sms.SDK.Interfaces
{
    public interface ISMSService
    {
        /// <summary>
        /// 获取token接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RespGetToken> GetTokenAsync(ReqGetToken req);


        /// <summary>
        /// 获取token接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        RespGetToken GetToken(ReqGetToken req);

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RespSendSms> SendSmsAsync(ReqSendSms req);


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        RespSendSms SendSms(ReqSendSms req);
    }
}
