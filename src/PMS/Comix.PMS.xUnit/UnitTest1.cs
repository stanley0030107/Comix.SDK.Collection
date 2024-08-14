

using Furion.RemoteRequest.Extensions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace Comix.PMS.xUnit
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;
        private readonly IPMSService _pmsService;
        public UnitTest1(IPMSService pmsService, ITestOutputHelper output)
        {
            _pmsService = pmsService;
            _output = output;
        }

        /// <summary>
        /// 请求PMS查询付款条件
        /// </summary>
        [Fact]
        public void Test1()
        {
            var req = new QueryContractFindOneReq()
            {
                projectCode = "16001002",
                isExpire = true,
                isFindMaxPayConditionDays = true,
                statementQuery = true,
            };

            var rsp = _pmsService.QueryContractFindOne(req);
            Assert.NotNull(rsp.statement.payConditionCode);
            _output.WriteLine("付款条件：" + rsp.statement.payConditionCode);
        }

        /// <summary>
        /// 请求PMS查询付款条件
        /// </summary>
        //[Fact]
        [Theory]
        [InlineData("16001078")]
        [InlineData("16001087")]
        public void Test2(string projectCode)
        {
            var rsp = _pmsService.QueryPayConditionCodeByProjectCode(projectCode);
            Assert.NotNull(rsp);
            _output.WriteLine("付款条件：" + rsp);
        }

        /// <summary>
        /// 请求PMS项目
        /// </summary>
        //[Fact]
        [Theory]
        [InlineData("16001078")]
        [InlineData("16001087")]
        public void TestProject(string projectCode)
        {
            var rsp = _pmsService.GetProjectInfo(new ProjectParam() { ProjectCode = projectCode });
            Assert.NotNull(rsp);
            _output.WriteLine("项目：" + rsp?.content[0]._base.projectName);
        }

        /// <summary>
        /// 请求PMS项目
        /// </summary>
        //[Fact]
        [Theory]
        [InlineData("16001078")]
        [InlineData("16001087")]
        public void TestProjectOne(string projectCode)
        {
            var rsp = _pmsService.GetProjectInfoFindOne(projectCode);
            Assert.NotNull(rsp);
            _output.WriteLine("项目：" + rsp?.projectName);
        }
    }
}