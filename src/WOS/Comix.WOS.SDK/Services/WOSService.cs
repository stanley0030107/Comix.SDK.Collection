using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Comix.WOS.Model.ReqModels;
using Comix.WOS.Model.RespModels;
using Comix.WOS.SDK.Interfaces;
using Comix.WOS.SDK.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Comix.WOS.SDK.Services
{
    /// <summary>
    /// 工单系统服务
    /// </summary>
    public class WOSService : IWOSService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WOSService> _logger;

        public WOSService(IHttpClientFactory httpClientFactory, ILogger<WOSService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        #region 登录 wos 获取 token
        /// <summary>
        /// 登录 wos 获取 token
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RespLoginRegisterByPhone LoginRegisterByPhone(LoginRegisterByPhoneParam param)
        {
            return LoginRegisterByPhoneAsync(param).Result;
        }

        /// <summary>
        /// 登录 wos 获取 token
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<RespLoginRegisterByPhone> LoginRegisterByPhoneAsync(LoginRegisterByPhoneParam req)
        {
            if (string.IsNullOrWhiteSpace(req.Credential))
            {
                req.Credential = WOSOptions.Credential;
            }
            var resp = await ExecuteAsync<RespLoginRegisterByPhone>(WOSRoute.LoginRegisterByPhonePath, req);
            return resp;
        }

        /// <summary>
        /// 员工工号登录 wos 获取 token
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public RespLoginRegisterByPhone LoginRegisterByEmployeeNo(LoginRegisterByEmployeeIdParam param)
        {
            return LoginRegisterByEmployeeNoAsync(param).GetAwaiter().GetResult();
        }

        /// <summary>
        /// 员工工号登录 wos 获取 token
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<RespLoginRegisterByPhone> LoginRegisterByEmployeeNoAsync(LoginRegisterByEmployeeIdParam req)
        {
            if (string.IsNullOrWhiteSpace(req.Credential))
            {
                req.Credential = WOSOptions.Credential;
            }
            var resp = await ExecuteAsync<RespLoginRegisterByPhone>(WOSRoute.LoginRegisterByEmployeeNoPath, req);
            return resp;
        }

        /// <summary>
        /// 员工工号登录 wos 获取 token 带角色权限
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public RespLoginRegisterByPhone ExternalSysLogin(ExternalSysLoginParam param)
        {
            return ExternalSysLoginAsync(param).GetAwaiter().GetResult();
        }

        /// <summary>
        /// 员工工号登录 wos 获取 token 带角色权限
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<RespLoginRegisterByPhone> ExternalSysLoginAsync(ExternalSysLoginParam req)
        {
            if (string.IsNullOrWhiteSpace(req.Credential))
            {
                req.Credential = WOSOptions.Credential;
            }
            var resp = await ExecuteAsync<RespLoginRegisterByPhone>(WOSRoute.ExternalSysLoginPath, req);
            return resp;
        }
        #endregion

        #region 请求发起工单
        /// <summary>
        /// 请求发起工单
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public RespPreOrder GetPreOrder(PreOrderParam param, string userToken)
        {
            return GetPreOrderAsync(param, userToken).Result;
        }

        /// <summary>
        /// 请求发起工单
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<RespPreOrder> GetPreOrderAsync(PreOrderParam param, string userToken)
        {
            var resp = await ExecuteAsync<RespPreOrder>(WOSRoute.WorkOrderPreOrderPath, param, new Dictionary<string, string>() { ["Authorization"] = userToken });
            return resp;
        }
        #endregion

        #region 客诉统计待办
        /// <summary>
        /// 客诉统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public RespBase<RespComplaintsStatistics> GetComplaintsStatistics(string userToken)
        {
            return GetComplaintsStatisticsAsync(userToken).Result;
        }

        /// <summary>
        /// 客诉统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<RespBase<RespComplaintsStatistics>> GetComplaintsStatisticsAsync(string userToken)
        {
            var resp = await ExecuteAsync<RespBase<RespComplaintsStatistics>>(WOSRoute.ComplaintsStatistics, null, new Dictionary<string, string>() { ["Authorization"] = userToken });
            return resp;
        }
        #endregion

        #region 改单统计待办
        /// <summary>
        /// 改单统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public RespBase<RespComplaintsStatistics> GetChangeOrderStatistics(string userToken)
        {
            return GetChangeOrderStatisticsAsync(userToken).Result;
        }

        /// <summary>
        /// 改单统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<RespBase<RespComplaintsStatistics>> GetChangeOrderStatisticsAsync(string userToken)
        {
            var resp = await ExecuteAsync<RespBase<RespComplaintsStatistics>>(WOSRoute.ChangeOrderStatistics, null, new Dictionary<string, string>() { ["Authorization"] = userToken });
            return resp;
        }
        #endregion

        #region 工单待评价统计

        public RespBase<int> GetCommentOrderStatistics(CommentStaticsParam param, string userToken)
        {
            return GetCommentOrderStatisticsAsync(param, userToken).Result;
        }

        public async Task<RespBase<int>> GetCommentOrderStatisticsAsync(CommentStaticsParam param, string userToken)
        {
            var resp = await ExecuteAsync<RespBase<int>>(WOSRoute.CommentOrderStatistics, param, new Dictionary<string, string>() { ["Authorization"] = userToken });
            return resp;
        }
        #endregion

        #region 创建工单
        public async Task<RespBase<List<string>>> CreateOrderAsync(List<BatchSaveParam> param)
        {
            var resp = await ExecuteAsync<RespBase<List<string>>>(WOSRoute.WorkOrderBatchSavePath, param);
            return resp;
        }

        public RespBase<List<string>> CreateOrder(List<BatchSaveParam> param)
        {
            return CreateOrderAsync(param).Result;
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
        private async Task<T> ExecuteAsync<T>(string path, object req, Dictionary<string, string> heads = null)
        {
            var resultStr = await ExecuteReturnStringAsync(path, req, heads);
            var resultObj = JsonConvert.DeserializeObject<T>(resultStr);
            return resultObj;
        }

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> ExecuteReturnStringAsync(string path, object req, Dictionary<string, string> heads)
        {
            var jsonStr = JsonConvert.SerializeObject(req);
            var jsonContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();

            if (heads != null && heads.Count > 0)
            {
                foreach (var item in heads)
                {
                    bool b = client.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
                    //jsonContent.Headers.TryAddWithoutValidation(item.Key, item.Value);
                }
            }

            if (WOSOptions.Url.EndsWith("/") && path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            var url = $"{WOSOptions.Url}{path}";
            var response = client.PostAsync(url, jsonContent).Result;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                string logKey = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                _logger.LogError($"wos请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{logKey} - {jsonStr}");
                throw new Exception($"请求异常-{response.StatusCode}，请求地址：{url}，请求参数：{logKey}");
            }
            var resultStr = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"wos请求：{url}\n请求参数：{jsonStr}\n响应参数：{resultStr}");
            return resultStr;
        }
        #endregion
    }
}