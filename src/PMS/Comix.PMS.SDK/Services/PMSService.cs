using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Comix.PMS.Model.ReqModels;
using Comix.PMS.Model.RespModels;
using Comix.PMS.Model.RespModels.Project;
using Comix.PMS.SDK.Interfaces;
using Comix.PMS.SDK.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Comix.PMS.SDK.Services
{
    public class PMSService : IPMSService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PMSService> _logger;

        public PMSService(IHttpClientFactory httpClientFactory, ILogger<PMSService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// PMS单个项目查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Comix.PMS.Model.RespModels.Project.Base GetProjectInfoFindOne(string projectCode)
        {
            var ret = GetProjectInfoAsync(new ProjectParam() { ProjectCode = projectCode }).Result;
            if (ret != null && ret.content != null && ret.content.Length > 0)
            {
                return ret.content[0]._base;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// PMS项目查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ProjectInfo GetProjectInfo(ProjectParam param)
        {
            return GetProjectInfoAsync(param).Result;
        }

        /// <summary>
        /// PMS项目查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ProjectInfo> GetProjectInfoAsync(ProjectParam req)
        {
            var resp = await ExecuteAsync<ProjectInfo>(PMSRoute.ProjectPath, req);
            return resp;
        }

        #region  合同
        /// <summary>
        /// PMS合同复杂查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public PMSContractInfo GetContractInfo(PMSContractInfoParam param)
        {
            return GetContractInfoAsync(param).Result;
        }

        /// <summary>
        /// PMS合同复杂查询
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<PMSContractInfo> GetContractInfoAsync(PMSContractInfoParam req)
        {
            var resp = await ExecuteAsync<PMSContractInfo>(PMSRoute.ContractInfoPath, req);
            return resp;
        }
        #endregion

        #region 合同有效的付款条件
        /// <summary>
        /// 根据项目查询合同有效的付款条件
        /// </summary>
        /// <param name="customerCode">项目编码</param>
        /// <returns>匹配的合同信息</returns>
        public QueryContractFindOneResp QueryContractFindOne(QueryContractFindOneReq req)
        {
            return QueryContractFindOneAsync(req).Result;
        }
        /// <summary>
        /// 根据项目查询合同有效的付款条件
        /// </summary>
        /// <param name="customerCode">项目编码</param>
        /// <returns>匹配的合同信息</returns>
        public async Task<QueryContractFindOneResp> QueryContractFindOneAsync(QueryContractFindOneReq req)
        {
            return await ExecuteAsync<QueryContractFindOneResp>(PMSRoute.ContractFindOnePath, req);
        }

        /// <summary>
        /// 根据项目查询合同有效的付款条件
        /// </summary>
        /// <param name="projectCode">项目编码</param>
        /// <returns>付款条件</returns>
        public string QueryPayConditionCodeByProjectCode(string projectCode)
        {
            return QueryPayConditionCodeByProjectCodeAsync(projectCode).GetAwaiter().GetResult();
        }
        /// <summary>
        /// 根据项目查询合同有效的付款条件
        /// </summary>
        /// <param name="projectCode">项目编码</param>
        /// <returns>付款条件</returns>
        public async Task<string> QueryPayConditionCodeByProjectCodeAsync(string projectCode)
        {
            var req = new QueryContractFindOneReq()
            {
                projectCode = projectCode,
                //isExpire = true,
                isFindMaxPayConditionDays = true,
                statementQuery = true,
            };

            var res = await ExecuteAsync<QueryContractFindOneResp>(PMSRoute.ContractFindOnePath, req);
            if (res == null || res.statement == null || string.IsNullOrEmpty(res.statement.payConditionCode))
            {
                return null;
            }

            return res.statement.payConditionCode;
        }

        public GetCustomerContractInfoResp GetCustomerContractInfo(GetCustomerContractParam req)
        {
            return GetCustomerContractInfoAsync(req).Result;
        }

        public async Task<GetCustomerContractInfoResp> GetCustomerContractInfoAsync(GetCustomerContractParam req)
        {
            return await ExecuteAsync<GetCustomerContractInfoResp>(PMSRoute.ContractGetCustomerInfoPath, req);
        }

        #endregion

        #region 基础封装
        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>ComixBaseResponseDto</returns>
        private async Task<T> ExecuteAsync<T>(string path, object req)
        {
            var resultStr = await ExecuteReturnStringAsync(path, req);
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        ///     执行post请求
        /// </summary>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> ExecuteReturnStringAsync(string path, object req)
        {
            var jsonStr = JsonConvert.SerializeObject(req);
            var jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            if (PMSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{PMSOptions.Url}{path}";
            var response = await client.PostAsync(url, jsonContent);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{jsonStr}");

            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"pms请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}