using Comix.RPA.SDK.Input;
using Comix.RPA.SDK.Output;
using Furion.RemoteRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Comix.RPA.SDK.HttpProxy
{
    /// <summary>
    /// RPA请求代理类
    /// </summary>
    [Client(RpaSetup.RpaHttpClientName)]
    public interface IRpaHttpProxy: IHttpDispatchProxy
    {
        /// <summary>
        /// 发送数据给RPA
        /// </summary>
        /// <returns></returns>
        [Post("rpa/data")]
        Task<RpaBaseOutput> PostRpaDataAsync([Body] RpaBaseInput<List<RpaDataInput>> input);
    }
}
