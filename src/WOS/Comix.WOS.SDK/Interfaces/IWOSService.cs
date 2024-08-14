using Comix.WOS.Model.ReqModels;
using Comix.WOS.Model.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.WOS.SDK.Interfaces
{
    /// <summary>
    /// 工单系统接口
    /// </summary>
    public interface IWOSService
    {
        /// <summary>
        /// 手机号登录 wos 获取 token
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        RespLoginRegisterByPhone LoginRegisterByPhone(LoginRegisterByPhoneParam param);

        /// <summary>
        /// 手机号登录 wos 获取 token
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RespLoginRegisterByPhone> LoginRegisterByPhoneAsync(LoginRegisterByPhoneParam req);

        /// <summary>
        /// 员工工号登录 wos 获取 token
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        RespLoginRegisterByPhone LoginRegisterByEmployeeNo(LoginRegisterByEmployeeIdParam param);

        /// <summary>
        /// 员工工号登录 wos 获取 token
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RespLoginRegisterByPhone> LoginRegisterByEmployeeNoAsync(LoginRegisterByEmployeeIdParam req);

        /// <summary>
        /// 员工工号登录 wos 获取 token 带角色权限
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        RespLoginRegisterByPhone ExternalSysLogin(ExternalSysLoginParam param);

        /// <summary>
        /// 员工工号登录 wos 获取 token 带角色权限
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RespLoginRegisterByPhone> ExternalSysLoginAsync(ExternalSysLoginParam req);

        /// <summary>
        /// 请求发起工单
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        RespPreOrder GetPreOrder(PreOrderParam param, string userToken);

        /// <summary>
        /// 请求发起工单
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task<RespPreOrder> GetPreOrderAsync(PreOrderParam param, string userToken);

        /// <summary>
        /// 客诉统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        RespBase<RespComplaintsStatistics> GetComplaintsStatistics(string userToken);

        /// <summary>
        /// 客诉统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task<RespBase<RespComplaintsStatistics>> GetComplaintsStatisticsAsync(string userToken);

        /// <summary>
        /// 改单统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        RespBase<RespComplaintsStatistics> GetChangeOrderStatistics(string userToken);

        /// <summary>
        /// 改单统计待办
        /// </summary>
        /// <param name="param"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task<RespBase<RespComplaintsStatistics>> GetChangeOrderStatisticsAsync(string userToken);

        RespBase<int> GetCommentOrderStatistics(CommentStaticsParam param, string userToken);

        Task<RespBase<int>> GetCommentOrderStatisticsAsync(CommentStaticsParam param, string userToken);

        Task<RespBase<List<string>>> CreateOrderAsync(List<BatchSaveParam> param);

        RespBase<List<string>> CreateOrder(List<BatchSaveParam> param);
    }
}
