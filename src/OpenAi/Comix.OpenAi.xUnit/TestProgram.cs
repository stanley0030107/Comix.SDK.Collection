using Furion.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

// 配置启动类类型，第一个参数是 TestProgram 类完整限定名，第二个参数是当前项目程序集名称
[assembly: TestFramework("Comix.OpenAi.xUnit.TestProgram", "Comix.OpenAi.xUnit")]
namespace Comix.OpenAi.xUnit
{
    /// <summary>
    /// 单元测试启动类
    /// </summary>
    public class TestProgram : TestStartup
    {
        public TestProgram(IMessageSink messageSink) : base(messageSink)
        {
            // 初始化 Furion
            Serve.RunNative();
        }

    }
}
