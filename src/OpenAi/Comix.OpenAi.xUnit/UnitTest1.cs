using Comix.OpenAi.SDK.Interfaces;
using Comix.OpenAi.SDK.ReqModels;
using Xunit.Abstractions;

namespace Comix.OpenAi.xUnit
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        private readonly IOpenAiService  _openAiService;
        public UnitTest1(IOpenAiService openAiService, ITestOutputHelper output)
        {
            _openAiService = openAiService;
            _output = output;
        }

        [Theory]
        [InlineData("齐心集团总部在哪")]
        public void Test1(string content)
        {
            var req = new ReqApiChatgptChatDto()
            {
                temperature = 1,
                messages = new List<ReqApiChatgptChatMessageDto>() {
                    new ReqApiChatgptChatMessageDto(){
                        role = "user",
                        content = content,
                        clientId = 2
                    }
                }
            };
            var resp = _openAiService.ApiChatgptChatAsync(req).GetAwaiter().GetResult();
            Assert.NotNull(resp);
            Assert.Null(resp.msg);
        }
    }
}