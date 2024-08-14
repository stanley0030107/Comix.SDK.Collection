

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
        /// ����PMS��ѯ��������
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
            _output.WriteLine("����������" + rsp.statement.payConditionCode);
        }

        /// <summary>
        /// ����PMS��ѯ��������
        /// </summary>
        //[Fact]
        [Theory]
        [InlineData("16001078")]
        [InlineData("16001087")]
        public void Test2(string projectCode)
        {
            var rsp = _pmsService.QueryPayConditionCodeByProjectCode(projectCode);
            Assert.NotNull(rsp);
            _output.WriteLine("����������" + rsp);
        }

        /// <summary>
        /// ����PMS��Ŀ
        /// </summary>
        //[Fact]
        [Theory]
        [InlineData("16001078")]
        [InlineData("16001087")]
        public void TestProject(string projectCode)
        {
            var rsp = _pmsService.GetProjectInfo(new ProjectParam() { ProjectCode = projectCode });
            Assert.NotNull(rsp);
            _output.WriteLine("��Ŀ��" + rsp?.content[0]._base.projectName);
        }

        /// <summary>
        /// ����PMS��Ŀ
        /// </summary>
        //[Fact]
        [Theory]
        [InlineData("16001078")]
        [InlineData("16001087")]
        public void TestProjectOne(string projectCode)
        {
            var rsp = _pmsService.GetProjectInfoFindOne(projectCode);
            Assert.NotNull(rsp);
            _output.WriteLine("��Ŀ��" + rsp?.projectName);
        }
    }
}