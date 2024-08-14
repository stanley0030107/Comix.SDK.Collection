using Furion.RemoteRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.AiService.HttpProxy
{
    /// <summary>
    /// AI服务
    /// </summary>
    [Client(AiServiceSetup.RpaHttpClientName)]
    public interface IAiServiceHttpProxy : IHttpDispatchProxy
    {
        /// <summary>
        /// 搜素分类
        /// </summary>
        /// <returns></returns>
        [Get("/api/recCategory?category={category}")]
        Task<List<string>> SearchCategoryAsync(string category);


    }
}
