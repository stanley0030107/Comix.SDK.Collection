using Comix.JsonRpc.NetCoreClient;
using Comix.OMS.SDK.Models;
using Comix.OMS.SDK.Models.RPC;

namespace Comix.OMS.SDK.RPC;

/// <summary>
/// OMS RPC服务
/// </summary>
[JsonRpcClient(Name = "OMS")]
public class OMSServicesProxy
{
    public void UpdateSeSalesInvoiceStatus(int invoiceStatus, string billNo)
    {
        Rpc.Call("OMS.SeSalesOrder.UpdateInvoiceStatus", invoiceStatus, billNo);
    }
    public List<string> GetSAPBillNoList(string orderBillNo)
    {
        return Rpc.Call<List<string>>("OMS.SeDoOrder.GetSAPBillNoList", orderBillNo);
    }
    public List<SeOrderLink> GetSeOrderByPOBillNo(string pOBillNo)
    {
        return Rpc.Call<List<SeOrderLink>>("OMS.SeSalesOrder.GetSeOrderByPOBillNo", pOBillNo);
    }
    public void UpdateInvoiceStatus(int invoiceStatus, string sourceBillNo)
    {
        Rpc.Call("OMS.TPreSeOrderLink.UpdateInvoiceStatus", invoiceStatus, sourceBillNo);
    }
    public List<SeDoLink> GetSeSalesOrderDeliveryInfo(string sapBillNo)
    {
        return Rpc.Call<List<SeDoLink>>("OMS.SeSalesOrder.GetDeliveryInfo", sapBillNo);
    }
    public List<SeDoLink> GetSeDoOrderDeliveryInfo(string sapBillNo)
    {
        return Rpc.Call<List<SeDoLink>>("OMS.SeDoOrder.GetDeliveryInfo", sapBillNo);
    }
    public void SetDistributor(TPreSeOrderLink preSeOrderLink, string distributorCode, string orderEntityDistributorCode)
    {
        Rpc.Call("OMS.TPreSeOrderLink.SetDistributor", preSeOrderLink, distributorCode, orderEntityDistributorCode);
    }
    public void UpdateProdCode(string newCode, string oldCode)
    {
        Rpc.Call("OMS.TPreSeOrderDetailLink.UpdateProdCode", newCode, oldCode);
    }
    /// <summary>
    /// 查询合约OMS用户
    /// </summary>
    /// <param name="includeDisabled">包括禁用的账号</param>
    /// <returns></returns>
    public List<OMSUser> GetUserList(bool includeDisabled)
    {
        return Rpc.Call<List<OMSUser>>("OMS.User.GetList", includeDisabled);
    }
    /// <summary>
    /// 校验订单是否可以修改收货地址
    /// </summary>
    /// <param name="orderCode"></param>
    public bool CheckOrderUpdateAddress(string orderCode)
    {
        return Rpc.Call<bool>("OMS.PreSeSalesOrder.CheckOrderUpdateAddress", orderCode);
    }

    /// <summary>
    /// 更新商城订单签收即将逾期的时间
    /// </summary>
    /// <param name="orderCode"></param>
    /// <param name="SignWarningTime"></param>
    /// <returns></returns>
    public bool UpdateLinkSignWarningTime(string orderCode, DateTime? signWarningTime)
    {
        return Rpc.Call<bool>("OMS.PreSeSalesOrder.UpdateLinkSignWarningTime", orderCode, signWarningTime);
    }

    public void UpdateOrderWlInfo(string orderCode, string type, string wlName, string wlNo, string carPhone, string carName, string carNo)
    {
        Rpc.Call("OMS.PreSeSalesOrder.UpdateOrderWlInfo", orderCode, type, wlName, wlNo, carPhone, carName, carNo);
    }

    public void UpdateOrderDelayReason(string orderCode, int reasonCode, string extReason)
    {
        Rpc.Call("OMS.PreSeSalesOrder.UpdateOrderDelayReason", orderCode, reasonCode, extReason);
    }

    public void UpdateOrderDelayInfo(string sourceBillNo, bool isExchange, string exchangeFiles, string remark, DateTime deliverTime)
    {
        Rpc.Call("OMS.PreSeSalesOrder.UpdateOrderDelayInfo", sourceBillNo, isExchange, exchangeFiles, remark, deliverTime);
    }

    public void UpdateOrderPlanTime(string orderCode, DateTime? planDeliveryTime, string planReason)
    {
        Rpc.Call("OMS.PreSeSalesOrder.UpdateOrderPlanTime", orderCode, planDeliveryTime, planReason);
    }

    public void ConfirmInvoiceInfo(O2oInvoiceInfo data)
    {
        Rpc.Call("OMS.PreSeSalesOrder.ConfirmInvoiceInfo", data);
    }

    public void UpdateCustCode(string invoiceCustCode, List<string> preSourceBillNoList)
    {
        Rpc.Call("OMS.PreSeSalesOrder.UpdateCustCode", invoiceCustCode, preSourceBillNoList);
    }

    public void MsgAdd(CapReceived cap)
    {
        Rpc.Call("OMS.ReceivedMsg.Add", cap);
    }

    /// <summary>
    /// 查询多个商城订单
    /// </summary>
    /// <param name="orderlist"></param>
    /// <returns></returns>
    public List<TPreSeOrderLink> GetPreSeSalesOrderModelList(List<string> orderlist, bool includeDetails = false)
    {
        return Rpc.Call<List<TPreSeOrderLink>>("OMS.PreSeSalesOrder.GetModelList", orderlist, includeDetails);
    }

    /// <summary>
    /// 更新商城订单即将逾期时间
    /// </summary>
    /// <param name="orderCode"></param>
    /// <param name="DeliveryWarningTime"></param>
    /// <returns></returns>
    public bool UpdateLinkDelveryWarningTime(string orderCode, DateTime? deliveryWarningTime)
    {
        return Rpc.Call<bool>("OMS.PreSeSalesOrder.UpdateLinkDelveryWarningTime", orderCode, deliveryWarningTime);
    }

    /// <summary>
    /// 更新商城订单逾期时间
    /// </summary>
    /// <param name="orderCode"></param>
    /// <param name="AcceptLimitTime"></param>
    /// <param name="DeliveryLimitTime"></param>
    /// <param name="SignLimitTime"></param>
    public bool UpdateLinkOrderDelayTime(string orderCode, DateTime? AcceptLimitTime, DateTime? deliveryLimitTime, DateTime? signLimitTime)
    {
        return Rpc.Call<bool>("OMS.PreSeSalesOrder.UpdateLinkOrderDelayTime", orderCode, AcceptLimitTime, deliveryLimitTime, signLimitTime);
    }

    /// <summary>
    /// O2O查询订单提供给工单系统
    /// </summary>
    /// <param name="sourceBillNo"></param>
    /// <returns></returns>
    public OrderInfoForWOS GetLinkOrderInfoForWOS(string sourceBillNo)
    {
        return Rpc.Call<OrderInfoForWOS>("OMS.PreSeSalesOrder.GetLinkOrderInfoForWOS", sourceBillNo);
    }

    /// <summary>
    /// 销售订单分页
    /// </summary>
    /// <param name="conds"></param>
    /// <returns></returns>
    public PagingResults<RespTSeOrderPageDto> GetPageList(PagingConds conds)
    {
        return Rpc.Call<PagingResults<RespTSeOrderPageDto>>("OMS.SeSalesOrder.GetPageList", conds);
    }

    /// <summary>
    /// O2O/ISC 查询OMS销售订单,带交货单
    /// </summary>
    /// <param name="sourceBillNos"></param>
    /// <returns></returns>
    public List<SeOrderLink> GetSeOrderByIsc(List<string> sourceBillNos)
    {
        return Rpc.Call<List<SeOrderLink>>("OMS.SeSalesOrder.GetSeOrderByIsc", sourceBillNos);
    }

    // /// <summary>
    // /// 查询启动工单的用户
    // /// </summary>
    // /// <param name="sourceBillNo">订单号</param>
    // /// <param name="projectCode">集采项目编号</param>
    // /// <exception cref="Exception"></exception>
    // public (RespPreOrder,string) CreateWos(string sourceBillNo, string phone)
    // {
    //     var demoWOSService = DependencyResolver.Current.GetService<IWOSService>();
    //     var pms = DependencyResolver.Current.GetService<IPMSService>();
    //     
    //     //WOS登录
    //     var retloginInfo = demoWOSService.LoginRegisterByPhone(new Comix.WOS.Model.ReqModels.LoginRegisterByPhoneParam() { PhoneNumber = phone });
    //     if (retloginInfo==null)
    //         throw new Exception("WOS登录失败");
    //
    //     if (retloginInfo != null && retloginInfo.code == 200)
    //     {
    //
    //         #region 从OMS获取订单员/结算员/合同项目
    //         var omsOrder = ComixCDP.BusinessService.OMSService.OMSServicesProxyService.GetLinkOrderInfoForWOS(sourceBillNo);
    //
    //         if (omsOrder == null || string.IsNullOrWhiteSpace(omsOrder.DefaultUserNo))
    //         {
    //             throw new Exception("订单不存在或者默认员工编号没有配置");
    //         }
    //         #endregion
    //
    //         #region O2O中订单
    //         var order = CDPService.OdcB2cShopOrdersService.GetSingle(sourceBillNo);
    //         var enterpriseGroup = new MstB2cEnterpriseGroupBLL().GetAll().FirstOrDefault(p => p.CustomerCode == order.CustomerCode);
    //         //合同项目
    //         string contractProjectCode = omsOrder.ContractSysId;//合同项目
    //
    //         //临时测试用
    //         //contractProjectCode = "58212";
    //         //临时测试用
    //         //string projectCode = "16001327";
    //         string projectCode = order.CustomerCode;
    //         #endregion
    //
    //         #region PMS项目管理员
    //         string servicesEmployeeIds = string.Empty;
    //
    //         var ciVal = pms.GetContractInfo(new Comix.PMS.Model.ReqModels.PMSContractInfoParam() { ContractProjectCode = contractProjectCode, ProjectCode = projectCode, DistrictsQuery = true });
    //
    //         if (ciVal != null && ciVal.content != null && ciVal.content.Length > 0 && ciVal.content[0].districts != null && ciVal.content[0].districts.Length > 0)
    //         {
    //             servicesEmployeeIds = string.Join(",", ciVal.content[0].districts.Where(a => !string.IsNullOrWhiteSpace(a.servicesEmployeeId)).Select(a => a.servicesEmployeeId.TrimStart('0')));
    //         }
    //         #endregion
    //
    //         #region 预处理对应人员的默认值
    //         if (string.IsNullOrWhiteSpace(servicesEmployeeIds)) servicesEmployeeIds = omsOrder.DefaultUserNo;
    //         if (string.IsNullOrWhiteSpace(omsOrder.OrderProcessor)) omsOrder.OrderProcessor = servicesEmployeeIds;
    //         if (string.IsNullOrWhiteSpace(omsOrder.SettlerNo)) omsOrder.SettlerNo = servicesEmployeeIds;
    //         if (string.IsNullOrWhiteSpace(omsOrder.OrderProcessor)) omsOrder.OrderProcessor = servicesEmployeeIds;
    //         #endregion
    //
    //         #region 构建工单类型对应的人员 工单类型 2, "订单模块"，3, "结算模块"，4, "商品上下架"，5, "投诉建议"，6, "其他"工单类型
    //         var acceptorList = new List<Comix.WOS.Model.ReqModels.Acceptor>();
    //
    //         //订单模块 -> OMS订单员
    //         acceptorList.Add(new Comix.WOS.Model.ReqModels.Acceptor()
    //         {
    //             modelType = 2,//订单模块
    //             accounts = omsOrder.OrderProcessor
    //         });
    //         //结算模块 -> OMS结算员
    //         acceptorList.Add(new Comix.WOS.Model.ReqModels.Acceptor()
    //         {
    //             modelType = 3,//结算模块
    //             accounts = omsOrder.SettlerNo
    //         });
    //
    //         //acceptorList.Add(new Comix.WOS.Model.ReqModels.Acceptor()
    //         //{
    //         //    modelType = 4,//商品上下架 一期去掉
    //         //    accounts = "800098"
    //         //});
    //
    //         //投诉建议、其他 -> 服务商管理员
    //         acceptorList.Add(new Comix.WOS.Model.ReqModels.Acceptor()
    //         {
    //             modelType = 5,//投诉建议
    //             accounts = servicesEmployeeIds
    //         });
    //         acceptorList.Add(new Comix.WOS.Model.ReqModels.Acceptor()
    //         {
    //             modelType = 6,//其他
    //             accounts = servicesEmployeeIds
    //         });
    //         #endregion
    //
    //         //发起工单
    //         var preOrderRet = demoWOSService.GetPreOrder(
    //             new Comix.WOS.Model.ReqModels.PreOrderParam()
    //             {
    //                 platform = "O2O",
    //                 feature = new Comix.WOS.Model.ReqModels.Feature()
    //                 {
    //                     customCode = order.CustomerCode,
    //                     customName = enterpriseGroup != null ? enterpriseGroup.CustomerName : "",
    //                     linkOrderNo = sourceBillNo,
    //                     purchaseOrderNumber = order.PxOrderId,
    //                     supplierName = order.DistributorName,
    //                     contractItemName = omsOrder.ContractSysName,
    //                     
    //                 },
    //                 acceptor = acceptorList.ToArray()
    //             }, retloginInfo.token);
    //         return (preOrderRet, retloginInfo.token);
    //     }
    //     else
    //     {
    //         throw new Exception(retloginInfo.msg);
    //         //WOS登录失败
    //     }
    // }
}