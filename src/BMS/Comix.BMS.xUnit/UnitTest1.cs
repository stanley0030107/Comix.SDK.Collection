

using Comix.BMS.SDK.Interfaces;
using Comix.BMS.SDK.Models.Req;
using Furion.RemoteRequest.Extensions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace Comix.BMS.xUnit
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        private readonly IBMSService  _bmsService;
        public UnitTest1(IBMSService bmsService, ITestOutputHelper output)
        {
            _bmsService = bmsService;
            _output = output;
        }

        /// <summary>
        /// 请求PMS查询付款条件
        /// </summary>
        [Fact]
        public void Test1()
        {
            var req = new ReqPushInvoiceDto()
            {
                url = "https://qxi.oss-cn-shenzhen.aliyuncs.com/dev/o2o/ElectronicSeal/2024/7/30153513.pdf"
            };

            var resp = _bmsService.PushInvoiceAsync(req).GetAwaiter().GetResult();
            Assert.Equal(200, resp.code);
            if (resp.code!=200)
            {
                _output.WriteLine($"{resp.message}");
            }
            
        }

    }
}