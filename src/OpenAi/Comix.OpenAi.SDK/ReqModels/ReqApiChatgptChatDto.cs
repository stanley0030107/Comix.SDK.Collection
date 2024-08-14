using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.OpenAi.SDK.ReqModels
{
    public class ReqApiChatgptChatDto
    {
        public int temperature { get; set; } = 1;

        public List<ReqApiChatgptChatMessageDto> messages { get; set; }
    }

    public class ReqApiChatgptChatMessageDto
    {
        /// <summary>
        /// 角色: user、assistant
        /// </summary>
        public string role { get; set; }
        /// <summary>
        /// 输入内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 客户端ID，范围：1-5，用于切换不同的openAI key，公司买了5个，每个key有次数限制. 
        /// </summary>
        public int clientId { get; set; }
    }
}
