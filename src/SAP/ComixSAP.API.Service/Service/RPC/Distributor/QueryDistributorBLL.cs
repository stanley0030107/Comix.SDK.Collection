using ComixSAP.API.Service.Common;
using System.Collections.Generic;

namespace ComixSAP.API.Service.RPC
{
    /// <summary>
    /// 配送商查询方法
    /// </summary>
    public class QueryDistributorBLL
    {
        /// <summary>
        /// 查询配送商
        /// </summary>
        /// <typeparam name="T">返回结果</typeparam>
        /// <param name="keyWord">关键字</param>
        ///  <param name="pageSize">索引</param>
        /// <param name="pageSize">显示行数</param>
        /// <returns></returns>
        public List<T> Query<T>(string keyWord,int pageindex,int pageSize=10)
        {
            RpcResponseDomain<RpcQueryResponseModel<T>> response = new RpcResponseDomain<RpcQueryResponseModel<T>>();
            RpcQueryModel<Dictionary<string,string>> model = new RpcQueryModel<Dictionary<string, string>>();
            model.@params.conds.Conds = new Dictionary<string, string>();
            model.@params.conds.PageInfo = new PageInfo { PageIndex= pageindex, PageSize =pageSize};
            model.@params.conds.Conds.Add("Key",keyWord);
            model.method = "OMS.Distributor.GetPageList";
            response= RpcHelper.RpcSend<Dictionary<string, string>, RpcQueryResponseModel<T>>("CON", model);
            return response.Success&& response.result!=null ? response.result.PageData:null;

        }
    }
}
