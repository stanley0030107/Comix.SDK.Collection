using Comix.BMS.SDK.Models.Req;
using Comix.BMS.SDK.Models.Resp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.BMS.SDK.Interfaces
{
    /// <summary>
    /// BMS服务接口
    /// </summary>
    public interface IBMSService
    {

        /// <summary>
        /// 推送发票文件
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<BmsSdkRespBase<ReqPushInvoiceDto>> PushInvoiceAsync(ReqPushInvoiceDto req);
    }
}
