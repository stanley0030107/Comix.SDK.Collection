using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.OpenAi.SDK.RespModels
{
    public class RespApiChatgptChatDto
    {
        #region 请求失败返回
        /// <summary>
        /// 失败的CODE
        /// </summary>
        public int? code { get; set; }
        /// <summary>
        /// 错误描述，成功返回null
        /// </summary>
        public string msg { get; set; }
        #endregion

        #region 请求成功返回

        /// <summary>
        /// 会话ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 返回内容
        /// </summary>
        public RespApiChatgptChatChoiceDto[] choices { get; set; }
        public int created { get; set; }
        /// <summary>
        /// 模型
        /// </summary>
        public string model { get; set; }
        public string _object { get; set; }
        public string system_fingerprint { get; set; }
        public RespApiChatgptChatUsageDto usage { get; set; }

        #endregion
    }

    public class RespApiChatgptChatUsageDto
    {
        public int completion_tokens { get; set; }
        public int prompt_tokens { get; set; }
        public int total_tokens { get; set; }
    }

    public class RespApiChatgptChatChoiceDto
    {
        public string finish_reason { get; set; }
        public int index { get; set; }
        public object logprobs { get; set; }
        public RespApiChatgptChatMessageDto message { get; set; }
    }

    public class RespApiChatgptChatMessageDto
    {
        /// <summary>
        /// 输出内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string role { get; set; }
        public object function_call { get; set; }
        public object tool_calls { get; set; }
    }

}
