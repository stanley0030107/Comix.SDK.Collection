using Comix.PMS.Model.ReqModels;
using Comix.PMS.Model.RespModels;
using Comix.PMS.Model.RespModels.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.PMS.SDK.Interfaces
{
    public interface IPMSService
    {
        /// <summary>
        /// PMS单个项目查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Comix.PMS.Model.RespModels.Project.Base GetProjectInfoFindOne(string projectCode);

        /// <summary>
        /// PMS项目查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ProjectInfo GetProjectInfo(ProjectParam param);

        /// <summary>
        /// PMS项目查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ProjectInfo> GetProjectInfoAsync(ProjectParam req);

        /// <summary>
        /// PMS合同项目
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PMSContractInfo GetContractInfo(PMSContractInfoParam param);

        /// <summary>
        /// PMS合同复杂查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<PMSContractInfo> GetContractInfoAsync(PMSContractInfoParam req);

        /// <summary>
        /// 合同单条查询
        /// </summary>
        /// <param name="customerCode">项目编码</param>
        /// <returns>匹配的合同信息</returns>
        QueryContractFindOneResp QueryContractFindOne(QueryContractFindOneReq req);

        /// <summary>
        /// 合同单条查询
        /// </summary>
        /// <param name="customerCode">项目编码</param>
        /// <returns>匹配的合同信息</returns>
        Task<QueryContractFindOneResp> QueryContractFindOneAsync(QueryContractFindOneReq req);

        /// <summary>
        /// 根据项目查询合同有效的付款条件
        /// </summary>
        /// <param name="customerCode">项目编码</param>
        /// <returns>付款条件</returns>
        string QueryPayConditionCodeByProjectCode(string projectCode);


        /// <summary>
        /// 根据项目查询合同有效的付款条件
        /// </summary>
        /// <param name="customerCode">项目编码</param>
        /// <returns>付款条件</returns>
        Task<string> QueryPayConditionCodeByProjectCodeAsync(string projectCode);

        GetCustomerContractInfoResp GetCustomerContractInfo(GetCustomerContractParam req);

        Task<GetCustomerContractInfoResp> GetCustomerContractInfoAsync(GetCustomerContractParam req);
    }
}
