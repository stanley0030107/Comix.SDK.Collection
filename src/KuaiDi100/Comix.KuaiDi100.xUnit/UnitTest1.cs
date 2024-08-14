using Comix.KuaiDi100.SDK.Interfaces;
using Comix.KuaiDi100.SDK.Services;
using System.Security.Cryptography;
using Xunit.Abstractions;

namespace Comix.KuaiDi100.xUnit
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        private readonly IKuaiDi100Service _kuaiDi100Service;
        public UnitTest1(IKuaiDi100Service kuaiDi100Service, ITestOutputHelper output)
        {
            _kuaiDi100Service = kuaiDi100Service;
            _output = output;
        }


        [Theory]
        //[InlineData("四川成都市都江堰市青城山镇青城山大道26号")]
        [InlineData("广西柳州市城中区立新路33号中国农业银行")]
        public void Test1(string content)
        {
            var resp = _kuaiDi100Service.AddressParseAsync(content).GetAwaiter().GetResult();
            Assert.NotNull(resp);
            _output.WriteLine($"code={resp.code},msg={resp.message}" );
            Assert.Equal(200, resp.code);
        }
    }
}