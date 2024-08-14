using Comix.AiService.HttpProxy;
using StackExchange.Profiling.Internal;
using Xunit.Abstractions;

namespace Comix.AiService.xUnit
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        private readonly IAiServiceHttpProxy _aiServiceHttpProxy;
        public UnitTest1(IAiServiceHttpProxy aiServiceHttpProxy, ITestOutputHelper output)
        {
            _aiServiceHttpProxy = aiServiceHttpProxy;
            _output = output;
        }


        [Theory]
        [InlineData("123")]
        [InlineData("±­×Ó")]
        [InlineData("¸´Ó¡Ö½")]
        public void Test1(string category)
        {
            var resp = _aiServiceHttpProxy.SearchCategoryAsync(category).GetAwaiter().GetResult();
            Assert.NotNull(resp);
            _output.WriteLine($"result={resp.ToJson()}");

        }
    }
}