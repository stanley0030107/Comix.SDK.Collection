using Comix.OpenAi.SDK.ReqModels;
using Comix.OpenAi.SDK.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.OpenAi.SDK.Interfaces
{
    public interface IOpenAiService
    {

        /// <summary>
        /// 接口方式请求GPT
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RespApiChatgptChatDto> ApiChatgptChatAsync(ReqApiChatgptChatDto req);


    }
}
