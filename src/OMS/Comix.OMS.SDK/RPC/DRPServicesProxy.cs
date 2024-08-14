using Comix.JsonRpc.NetCoreClient;
using Comix.OMS.SDK.Models;

namespace Comix.OMS.SDK.RPC;

/*
 配置示例
  "RpcClient": {
    "OMS": {
      "ServiceAddress": "http://oms-uat.comix.com.cn:9003/json.rpc",
      "UserCode": "1058.hsw",
      "Timeout": 400000,
      "UserInfo": "eyJPcGVyYXRlVGltZSI6IjIwMjAtMDgtMTAgMTc6MzQ6MDQiLCJDb25uZWN0SUQiOiI4NDY0ODJmYy0wMTQ1LTQ1OWMtOGQyMS1iNTY2ZmQwNDRkZDciLCJzeXN0ZW1JZCI6IkMwMDAwMSIsInN5c3RlbU5hbWUiOiLpvZDlv4NPTVPns7vnu58iLCJ0b2tlblN0ciI6IiIsIlVzZXJDb2RlIjoiMTA1OC5oc3ciLCJTdWJTeXNUeXBlIjoxMSwiTG9naW5JUCI6IjE3Mi4xOC4wLjExIiwiTG9naW5Db21wdXRlck5hbWUiOiJIRVNIRU5HV1UvQWRtaW5pc3RyYXRvciJ9"
    },
    "DRP": {
      "ServiceAddress": "http://localhost:8847/json.rpc",
      "UserCode": "1058.hsw",
      "Timeout": 400000,
      "UserInfo": "eyJPcGVyYXRlVGltZSI6IjIwMjAtMDgtMTAgMTc6MzQ6MDQiLCJDb25uZWN0SUQiOiI4NDY0ODJmYy0wMTQ1LTQ1OWMtOGQyMS1iNTY2ZmQwNDRkZDciLCJzeXN0ZW1JZCI6IkMwMDAwMSIsInN5c3RlbU5hbWUiOiLpvZDlv4NPTVPns7vnu58iLCJ0b2tlblN0ciI6IiIsIlVzZXJDb2RlIjoiMTA1OC5oc3ciLCJTdWJTeXNUeXBlIjoxMSwiTG9naW5JUCI6IjE3Mi4xOC4wLjExIiwiTG9naW5Db21wdXRlck5hbWUiOiJIRVNIRU5HV1UvQWRtaW5pc3RyYXRvciJ9"
    }
  }
 */

/// <summary>
/// OMS分销 RPC服务
/// </summary>
[JsonRpcClient(Name = "DRP")]
public class DRPServicesProxy
{
    public decimal GetDeliveryDiscountAmount(string sapBillNo)
    {
        return Rpc.Call<decimal>("DRP.SeDoOrder.GetDeliveryDiscountAmount", sapBillNo);
    }

    /// <summary>
    /// 获取订单剩余
    /// </summary>
    public List<OrderRest1> GetOrderRest1(string enterpriseCode)
    {
        //读取真实RPC配置
        //var ttt = Rpc.GetRpcOption(typeof(DRPServicesProxy));
        return Rpc.Call<List<OrderRest1>>("DRP.SeSalesOrderDetail.GetOrderRest1", enterpriseCode);
    }

    /// <summary>
    /// 获取订单剩余
    /// </summary>
    public List<OrderRest2> GetOrderRest2(string enterpriseCode)
    {
        return Rpc.Call<List<OrderRest2>>("DRP.SeSalesOrderDetail.GetOrderRest2", enterpriseCode);
    }

    public bool IsAllDelivery(string sourceBillNo)
    {
        return Rpc.Call<bool>("DRP.SeSalesOrderDetail.IsAllDelivery", sourceBillNo);
    }

    /// <summary>
    /// 查询分销用户
    /// </summary>
    /// <param name="includeDisabled">包括禁用的账号</param>
    /// <returns></returns>
    public List<OMSUser> GetUserList(bool includeDisabled)
    {
        return Rpc.Call<List<OMSUser>>("DRP.User.GetList", includeDisabled);
    }
}