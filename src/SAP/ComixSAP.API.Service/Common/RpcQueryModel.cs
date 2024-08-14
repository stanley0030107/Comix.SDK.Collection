using Furion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ComixSAP.API.Service.Common
{
    /// <summary>
    /// 查询参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RpcQueryModel<T>
    {

        /// <summary>
        /// 版本号
        /// </summary>
        public string jsonrpc { get; set; } = "2.0";
        /// <summary>
        /// 方法名
        /// </summary>
        public string method { get; set; } = "OMS.Invoice.GetPageList";
        /// <summary>
        /// 参数
        /// </summary>
        public QueryParameter<T> @params { get; set; } = new QueryParameter<T>();
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        public Tags tags { get; set; } = new Tags();
    }

    /// <summary>
    /// 分页
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 分页行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string SortType { get; set; }
    }

    /// <summary>
    /// 参数列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ParameterData<T>
    {
        /// <summary>
        /// 分页信息
        /// </summary>
        public PageInfo PageInfo { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string QueryName { get; set; } = "";
        /// <summary>
        /// 自定义查询参数
        /// </summary>
        public T Conds { get; set; } 
    }

    /// <summary>
    /// 查询参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryParameter<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public ParameterData<T> conds { get; set; } = new ParameterData<T>();
    }

    public class Tags
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string userid { get {
                return Furion.App.Configuration["RPC_USER_ID"];
            } }
        /// <summary>
        /// 公司
        /// </summary>
        public string companycode { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string auth_client_id { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string auth_token { get; set; } = "";
        /// <summary>
        /// 加密参数
        /// </summary>
        public string UserInfo { get {
                return Furion.App.Configuration["RPC_USER_INFO"];
            } }
    }


    /// <summary>
    /// 列表返回值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RpcQueryResponseModel<T>
    {
        /// <summary>
        /// 分页数据
        /// </summary>
        public List<T> PageData { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int RecordCount { get; set; }


    }

}
