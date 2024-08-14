using Comix.RPA.SDK.HttpProxy;
using Xunit.Abstractions;

namespace Comix.RPA.SDK.xUnit
{
    public class UnitTest1
    {
        private readonly IRpaHttpProxy _rpaHttp;
        private readonly ITestOutputHelper _output;
        public UnitTest1(IRpaHttpProxy rpaHttp, ITestOutputHelper output)
        {
            _rpaHttp = rpaHttp;
            _output = output;
        }

        /// <summary>
        /// 测试推送数据到RPA
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test1()
        {
            var input = new Input.RpaBaseInput<List<Input.RpaDataInput>>()
            {
                sys = "order",
                callbackUrl = "http://apigateway-uat.qx.com/order-service/api/RPACallback/CallbackData1043",
                body = new List<Input.RpaDataInput>() {
                    new Input.RpaDataInput()
                    {
                        code="SF2022121911"
                    }
                }
            };
            var resp = await _rpaHttp.PostRpaDataAsync(input);

            Assert.NotNull(resp);
            _output.WriteLine(resp.code + "=" + resp.message);
            Assert.Equal(200, resp.code);
        }
    }
}