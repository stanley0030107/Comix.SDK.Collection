using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.RPA.SDK.Input
{
    public class RpaBaseInput<T>
    {
        /// <summary>
        /// / 系统标识，同一个子系统，不同项目，可用ISC-1， ISC-2 . 标识
        /// </summary>
        public string sys { get; set; }

        /// <summary>
        /// 业务数据
        /// </summary>
        public T body { get; set; }

        /// <summary>
        /// 回调地址（子系统提供，统一用POST方式,参数类型统一用Map<String, Object>，统一返回成功状态码：code = 200）
        /// </summary>
        public string callbackUrl { get; set; }
    }
}
