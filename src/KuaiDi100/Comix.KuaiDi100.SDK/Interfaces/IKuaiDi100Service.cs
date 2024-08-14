
using Comix.KuaiDi100.SDK.Models.Resp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.KuaiDi100.SDK.Interfaces
{
    /// <summary>
    /// 快递100服务
    /// </summary>
    public interface IKuaiDi100Service
    {
        /// <summary>
        /// 收货地址解析
        /// </summary>
        /// <param name="content">地址信息</param>
        /// <returns></returns>
        Task<RespBase<List<RespAddressParseDto>>> AddressParseAsync(string content);
        /// <summary>
        /// 智能识别接口
        /// </summary>
        /// <param name="num">快递单号</param>
        /// <returns></returns>
        Task<List<ReqAutoNumberDto>> AutoNumberAsync(string num);
    }
}
