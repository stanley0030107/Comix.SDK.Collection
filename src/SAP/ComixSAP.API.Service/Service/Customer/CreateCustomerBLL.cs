using System.Collections.Generic;
using ComixSAP.Common.SAPPO.CustomerMaster;

namespace ComixSAP.API.Service.Customer
{
   /// <summary>
   /// 回款
   /// </summary>
    public class CreateCustomerBLL
    {
        #region B2C 创建客户
        /// <summary>
        /// B2C 创建客户信息
        /// </summary>
        /// <param name="b2cEnterpriseEntity">B2C 实体</param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public virtual string B2CCreateCustomer(ComixB2C.Common.Entity.MsEnterpriseEntity b2cEnterpriseEntity, ComixB2C.Common.Entity.MsEnterprisegroupEntity b2cgroup, SysSapCustomerParameterEntity customerParameter, out string errorMessage)
        {
             PORequestDomain<List<CustomerResquestBody>> requestDomain = new PORequestDomain<List<CustomerResquestBody>>();
            errorMessage = "";

            string customerName = b2cEnterpriseEntity.Name;
            CustomerResquestBody model = new CustomerResquestBody();
            model.BASIC_DATA = new BasicData();
 
            model.BUKRS_DATA = new List<BukrsDataItem>();
            model.SALES_DATA = new List<SalesDataItem>();
            model.KUNNR = "";//new Random().Next(2000000, 2999999).ToString()

            #region 赋值
            
            model.BASIC_DATA.KTOKD = customerParameter.Ktokd;  //客户帐户组   
            model.BASIC_DATA.NAME1 =  customerName;  //名称**********
            model.BASIC_DATA.LOCATION = b2cEnterpriseEntity.Address; //街道 5
            model.BASIC_DATA.LANGU = "1";

            model.BASIC_DATA.REGION = b2cEnterpriseEntity.SAPProvince;
            model.BASIC_DATA.CITYC = b2cEnterpriseEntity.SAPCity;
             
            var saleModel = new SalesDataItem()
            {
                VKORG = customerParameter.Vkorg,
                VTWEG = customerParameter.Vtweg,
                BZIRK = customerParameter.Bzirk,  //销售地区 
                VKBUR = customerParameter.Vkbur,  //销售部门 
                VKGRP = customerParameter.Vkgrp,  //销售组
                VWERK = customerParameter.Vwerk,  //交货工厂 (自有或外部)
                SPART = customerParameter.Spart,  //产品组 
                KLABC = customerParameter.Klabc,
                WAERS = customerParameter.Waers,
                BEGRU = "",  //权限组 
                KALKS = "1",  //定价过程分配到该客户
                LPRIO = "0",  //交货优先权 
                KTGRD = "01",
                TAXKD = "1",
                VSBED = "01",
                PLTYP = "",  //价格清单类型
                INCO1 = "",
                INCO2 = "",
                KDGRP = "10",
                //  PLTYP = "H4",  //价格清单类型
                ZTERM = customerParameter.Zterm
            };
            if (string.IsNullOrEmpty(saleModel.VKORG))
            {
                saleModel.VKORG = "1100";
            }
            var bukrsModel = new BukrsDataItem()
            {
                BUKRS = customerParameter.Bukrs,
                INTAD = customerParameter.Intad,
                AKONT = customerParameter.Akont,
                //ZTERM = callingDomain.MsgBody.paymentCode
            };
            model.CONTACT_BP = new List<ContactBPItem>()
            {
                //new ContactBPItem()
                //{

                //  ABTNR = "", //部门编号
                //  NAME1 = customerName,  //名称
                //  TELF1 = telphone,
                //  NAMEV = order.ShipName,

                //}
            };
           
            model.BUKRS_DATA.Add(bukrsModel);
            model.SALES_DATA.Add(saleModel);
            model.BASIC_DATA.KUKLA = customerParameter.Kukla; //客户分类

            model.BASIC_DATA.STKZA = customerParameter.Stkza; //平衡税（普票）
            model.BASIC_DATA.STCEG =  "";//增值税登记号 
            model.BASIC_DATA.STREET = b2cEnterpriseEntity.Address; //街道
            model.BASIC_DATA.POST_CODE1 = ""; //城市邮政编码
          

            saleModel.ZTERM = bukrsModel.ZTERM = !string.IsNullOrWhiteSpace(b2cgroup.PaymentCode)? b2cgroup.PaymentCode : customerParameter.Zterm;
            model.BASIC_DATA.COUNTRY = "CN";

            model.BASIC_DATA.TEL_NUMBER = b2cEnterpriseEntity.TelPhone;
            model.BASIC_DATA.TELF2 = b2cEnterpriseEntity.CellPhone;
            model.BASIC_DATA.FAX_NUMBER = b2cEnterpriseEntity.TelPhone;
            //model.BASIC_DATA.SORT1 = groupEntity.ContractItem; //搜索项1
            model.BASIC_DATA.SORT1 = b2cEnterpriseEntity.Name; //搜索项1
            model.BASIC_DATA.SORT2 = b2cgroup.CustomerName; //搜索项2
                                                               //传客户行业到sap
            if (string.IsNullOrEmpty(b2cgroup.IndustryCode))
            {
                model.BASIC_DATA.BRSCH = customerParameter.Brsch; //行业代码
            }
            else
            {
                model.BASIC_DATA.BRSCH = b2cgroup.IndustryCode; //行业代码
            }

            model.BASIC_DATA.BRAN1 = customerParameter.Bran1; //行业代码1
            model.BASIC_DATA.RPMKR = customerParameter.Rpmkr;//地区市场
            model.BASIC_DATA.NIELS = customerParameter.Niels;
            model.BASIC_DATA.PO_BOX = !string.IsNullOrWhiteSpace(b2cEnterpriseEntity.ContactMail) ? b2cEnterpriseEntity.ContactMail : "";
            #endregion
            requestDomain.REQUEST = new List<CustomerResquestBody>();
            requestDomain.REQUEST.Add(model);
            var response = SAPPOHelper.Send<List<CustomerResquestBody>,
                List<CustomerResponseBody>>("CDP",
                SAPUrlAddress.CUSTOMER_MASTER_DATA_URL,
                nameof(SAPUrlAddress.CUSTOMER_MASTER_DATA_URL),
                requestDomain);
            if (response.Success && response.RESPONSE != null && response.RESPONSE.Count > 0 && response.RESPONSE[0].MSGTY.Equals("S") && !string.IsNullOrWhiteSpace(response.RESPONSE[0].KUNNR))
            {
                return response.RESPONSE[0].KUNNR.TrimStart('0');
            }
            else
            {
                errorMessage = response.ResponseJson;
                return "";
            }
        }

        #endregion

        // #region COP 创建客户
        // /// <summary>
        // /// COP 创建客户
        // /// </summary>
        // /// <param name="callingDomain"></param>
        // /// <returns></returns>
        // public ResponseCreateLinkCustomerToSapSrvDomain COPCreateCustomer(CreateLinkCustomerToSapSrvDomain callingDomain)
        // {
        //     ResponseHeader ResponseHeader = new ResponseHeader();
        //     ResponseHeader.retCode = "Y";
        //     ResponseHeader.retErrCode = "";
        //     ResponseHeader.retMessage = "";
        //
        //     //ResponseCreateLinkCustomerToSapSrvBody ResponseBody = new ResponseCreateLinkCustomerToSapSrvBody();
        //     //PORequestDomain<List<CustomerResquestBody>> requestDomain = new PORequestDomain<List<CustomerResquestBody>>();
        //     //CustomerResquestBody model = new CustomerResquestBody();
        //     //model.BASIC_DATA = new BasicData();
        //     //string errorMessage = "";
        //     //string enterpriseCode = "";
        //     //model.BUKRS_DATA = new List<BukrsDataItem>();
        //     //model.SALES_DATA = new List<SalesDataItem>();
        //
        //     //model.KUNNR = new Random().Next(2000001, 2500009).ToString();
        //     //model.MSGID = model.KUNNR;
        //
        //     //SrcOdcB2cShopOrdersEntity order = null;
        //     //SrcOdcB2cShopOrderInvoiceEntity invoiceEntity = null;
        //     //if (!string.IsNullOrWhiteSpace(callingDomain.MsgBody.OrderCode))
        //     //{
        //     //    order = CDPService.OdcB2cShopOrdersService.GetSrcOdcB2cShopOrdersEntityByOrderCode(callingDomain.MsgBody.OrderCode);
        //     //    invoiceEntity = CDPService.OdcB2cShopOrderInvoicesService.GetInvoiceByOrderCode(callingDomain.MsgBody.OrderCode);
        //     //}
        //     //else if (callingDomain.MsgBody.OrderInfo != null && callingDomain.MsgBody.OrderInfo.Count > 0)
        //     //{
        //     //    order = new SrcOdcB2cShopOrdersEntity();
        //     //    foreach (var item in callingDomain.MsgBody.OrderInfo)
        //     //    {
        //     //        if (item.Value != null)
        //     //        {
        //     //            order.SetData(item.Key, item.Value);
        //     //        }
        //     //    }
        //
        //     //}
        //     //else
        //     //{
        //     //    ResponseHeader.retCode = "N";
        //     //    ResponseHeader.retErrCode = "0060";
        //     //    ResponseHeader.retMessage = "客户参数异常，无法创建";
        //     //    var result = new ResponseCreateLinkCustomerToSapSrvDomain();
        //     //    result.MsgHeader = ResponseHeader;
        //     //    result.MsgBody = ResponseBody;
        //     //    return result;
        //     //}
        //     //MstB2cEnterpriseGroupEntity groupEntity = CDPService.B2cEnterpriseGroupService.GetMstB2cEnterpriseGroupEntityByCode(order.CustomerCode);
        //
        //     //if (groupEntity.EnterpriseCreateType.Equals("1"))
        //     //{
        //     //    string customerCode = order.CustomerCode;
        //     //    string provinceName = "";
        //     //    string cityName = "";
        //     //    string countyName = "";
        //
        //     //    string customerName = ConvertCustomerName(order.EnterpriseName.Trim(), customerCode);
        //     //    if (string.IsNullOrEmpty(customerName))
        //     //    {
        //     //        ResponseHeader.retCode = "N";
        //     //        ResponseHeader.retErrCode = "";
        //     //        ResponseHeader.retMessage = "客户名称不能为空";
        //
        //     //        var result = new ResponseCreateLinkCustomerToSapSrvDomain();
        //     //        result.MsgHeader = ResponseHeader;
        //     //        result.MsgBody = ResponseBody;
        //     //        return result;
        //     //    }
        //
        //     //    if (customerCode.Equals("16001024"))
        //     //    {
        //     //        provinceName = SystemService.ParameterService.GetParameterValueByParameterName("16001024", "HNDM", order.ShipProvinceCode);
        //     //        cityName = SystemService.ParameterService.GetParameterValueByParameterName("16001024", "HNDM", order.ShipCityCode);
        //     //        countyName = SystemService.ParameterService.GetParameterValueByParameterName("16001024", "HNDM", order.ShipCountyCode);
        //     //    }
        //     //    else
        //     //    {
        //     //        customerCode = CDPService.B2cEnterpriseGroupService.GetCustomerGroupArea(groupEntity.CustomerCode);
        //     //        MstB2cAreaEntity b2cProvinceEntity = CDPService.B2cAreaService.GetMstB2cAreaEntityByCode(customerCode, order.ShipProvinceCode);
        //     //        MstB2cAreaEntity b2cCityEntity = CDPService.B2cAreaService.GetMstB2cAreaEntityByCode(customerCode, order.ShipCityCode);
        //     //        MstB2cAreaEntity b2cCountyEntity = CDPService.B2cAreaService.GetMstB2cAreaEntityByCode(customerCode, order.ShipCountyCode);
        //     //        if (b2cProvinceEntity != null)
        //     //            provinceName = b2cProvinceEntity.AreaName;
        //     //        if (b2cCityEntity != null)
        //     //            cityName = b2cCityEntity.AreaName;
        //     //        if (b2cCountyEntity != null)
        //     //            countyName = b2cCountyEntity.AreaName;
        //     //        if (string.IsNullOrWhiteSpace(provinceName) && !string.IsNullOrWhiteSpace(order.ShipProvinceCode) && !order.ShipProvinceCode.Equals("-1"))
        //     //        {
        //     //            provinceName = order.ShipProvinceCode;
        //     //        }
        //     //        if (string.IsNullOrWhiteSpace(cityName) && !string.IsNullOrWhiteSpace(order.ShipCityCode) && !order.ShipCityCode.Equals("-1"))
        //     //        {
        //     //            cityName = order.ShipCityCode;
        //     //        }
        //     //        if (string.IsNullOrWhiteSpace(countyName) && !string.IsNullOrWhiteSpace(order.ShipCountyCode) && !order.ShipCountyCode.Equals("-1"))
        //     //        {
        //     //            countyName = order.ShipCountyCode;
        //     //        }
        //     //    }
        //
        //     //    string salesOrg = string.IsNullOrEmpty(groupEntity.SalesgroupCode) ? "1100" : groupEntity.SalesgroupCode;
        //
        //     //    SysSapCustomerParameterEntity customerParameter = CDPService.SapCustomerParameterService.GetCustomerParameter(salesOrg);
        //     //    MstSapRegionEntity regionEntity = new MstSapRegionEntity();
        //     //    MstSapCityEntity cityEntity = new MstSapCityEntity();
        //     //    MstSapCountyEntity countyEntity = new MstSapCountyEntity();
        //     //    if (!string.IsNullOrEmpty(provinceName))
        //     //        regionEntity = CDPService.SapRegionService.GetMstSapRegionEntityByName(provinceName);
        //     //    else
        //     //        regionEntity = null;
        //     //    if (!string.IsNullOrEmpty(cityName) && regionEntity != null)
        //     //        cityEntity = CDPService.SapCityService.GetMstSapCityEntityByName(regionEntity.RegionCode, cityName);
        //     //    else
        //     //        cityEntity = null;
        //     //    if (!string.IsNullOrEmpty(countyName) && regionEntity != null)
        //     //        countyEntity = CDPService.SapCountyService.GetMstSapCountyEntityByName(regionEntity.RegionCode, countyName);
        //     //    else
        //     //        countyEntity = null;
        //
        //     //    string ktokd = customerParameter.Ktokd;
        //     //    if (groupEntity.CustomerCode == "16001023")
        //     //    {
        //     //        ktokd = "Z010";
        //     //    }
        //
        //     //    #region 赋值
        //     //    string telphone = order.ShipTelphone;
        //     //    if (string.IsNullOrEmpty(telphone))
        //     //        telphone = order.BuyerCellphone;
        //     //    if (string.IsNullOrEmpty(telphone))
        //     //        telphone = order.ShipCellphone;
        //     //    model.BASIC_DATA.KTOKD = ktokd; //客户帐户组   
        //     //    model.BASIC_DATA.NAME1 = customerName;  //名称**********
        //     //    model.BASIC_DATA.LOCATION = order.ShipAddress; //街道 5
        //     //    model.BASIC_DATA.LANGU = "1";
        //
        //     //    if (countyEntity != null)
        //     //        model.BASIC_DATA.COUNC = countyEntity.CountyCode;
        //     //    else
        //     //        model.BASIC_DATA.COUNC = ""; //县代码
        //     //    if (regionEntity != null)
        //     //        model.BASIC_DATA.REGION = regionEntity.RegionCode;
        //     //    else
        //     //        model.BASIC_DATA.REGION = ""; //地区 (州、省、县)
        //     //    if (cityEntity != null)
        //     //    {
        //     //        model.BASIC_DATA.CITY1 = cityEntity.CityName;
        //     //        model.BASIC_DATA.CITYC = cityEntity.CityCode;
        //     //    }
        //     //    else
        //     //    {
        //     //        model.BASIC_DATA.CITY1 = ""; //城市
        //     //        model.BASIC_DATA.CITYC = "";
        //     //    }
        //
        //     //    var saleModel = new SalesDataItem()
        //     //    {
        //     //        VKORG = customerParameter.Vkorg,
        //     //        VTWEG = customerParameter.Vtweg,
        //     //        BZIRK = customerParameter.Bzirk,  //销售地区 
        //     //        VKBUR = customerParameter.Vkbur,  //销售部门 
        //     //        VKGRP = customerParameter.Vkgrp,  //销售组
        //     //        VWERK = customerParameter.Vwerk,  //交货工厂 (自有或外部)
        //     //        SPART = customerParameter.Spart,  //产品组 
        //     //        KLABC = customerParameter.Klabc,
        //     //        WAERS = customerParameter.Waers,
        //     //        BEGRU = customerParameter.Vkbur,  //销售部门 
        //     //        KALKS = "",  //定价过程分配到该客户
        //     //        LPRIO = "0",  //交货优先权 
        //     //        KTGRD = "01",
        //     //        TAXKD = "1",
        //     //        VSBED = "",
        //     //        PLTYP = "",  //价格清单类型
        //     //        INCO1 = "",
        //     //        INCO2 = "",
        //     //        KDGRP = "10",
        //     //        //  PLTYP = "H4",  //价格清单类型
        //     //        ZTERM = customerParameter.Zterm
        //     //    };
        //     //    if (string.IsNullOrEmpty(saleModel.VKORG))
        //     //    {
        //     //        saleModel.VKORG = "1100";
        //     //    }
        //     //    var bukrsModel = new BukrsDataItem()
        //     //    {
        //     //        BUKRS = customerParameter.Bukrs,
        //     //        INTAD = customerParameter.Intad,
        //     //        AKONT = customerParameter.Akont,
        //     //        //ZTERM = callingDomain.MsgBody.paymentCode
        //     //    };
        //     //    model.CONTACT_BP = new List<ContactBPItem>() {
        //     //        new ContactBPItem()
        //     //        {
        //
        //     //          ABTNR = "", //部门编号
        //     //          NAME1 = customerName,  //名称
        //     //          TELF1 = telphone,
        //     //          NAMEV = order.ShipName,
        //
        //     //        }
        //     //    };
        //     //    model.BUKRS_DATA.Add(bukrsModel);
        //     //    model.SALES_DATA.Add(saleModel);
        //     //    model.BASIC_DATA.KUKLA = customerParameter.Kukla; //客户分类
        //
        //     //    model.BASIC_DATA.STKZA = customerParameter.Stkza; //平衡税（普票）
        //     //    model.BASIC_DATA.STCEG = invoiceEntity != null ? invoiceEntity.InvoiceOrgCode : "";//增值税登记号 
        //     //    model.BASIC_DATA.STREET = order.ShipAddress; //街道
        //     //    model.BASIC_DATA.POST_CODE1 = ""; //城市邮政编码
        //
        //     //    if (!string.IsNullOrEmpty(groupEntity.PaymentCode))
        //     //    {
        //     //        saleModel.ZTERM = bukrsModel.ZTERM = groupEntity.PaymentCode; //付款条件代码
        //     //    }
        //     //    else
        //     //    {
        //     //        saleModel.ZTERM = bukrsModel.ZTERM = customerParameter.Zterm; //付款条件代码
        //     //    }
        //
        //     //    model.BASIC_DATA.COUNTRY = "CN";
        //
        //     //    model.BASIC_DATA.TEL_NUMBER = telphone;
        //     //    model.BASIC_DATA.TELF2 = order.BuyerCellphone;
        //     //    model.BASIC_DATA.FAX_NUMBER = telphone;
        //     //    model.BASIC_DATA.SORT1 = groupEntity.ContractItem; //搜索项1
        //     //    model.BASIC_DATA.SORT2 = groupEntity.CustomerName; //搜索项2
        //     //                                                       //传客户行业到sap
        //     //    if (string.IsNullOrEmpty(groupEntity.IndustryCode))
        //     //    {
        //     //        model.BASIC_DATA.BRSCH = customerParameter.Brsch; //行业代码
        //     //    }
        //     //    else
        //     //    {
        //     //        model.BASIC_DATA.BRSCH = groupEntity.IndustryCode; //行业代码
        //     //    }
        //
        //     //    model.BASIC_DATA.BRAN1 = customerParameter.Bran1; //行业代码1
        //     //    model.BASIC_DATA.RPMKR = customerParameter.Rpmkr;//地区市场
        //     //    model.BASIC_DATA.NIELS = customerParameter.Niels;
        //     //    model.BASIC_DATA.PO_BOX = order.BuyerEmail;
        //     //    #endregion
        //     //    requestDomain.REQUEST = new List<CustomerResquestBody>();
        //     //    requestDomain.REQUEST.Add(model);
        //     //    var response = SAPPOHelper.Send<List<CustomerResquestBody>,
        //     //        List<CustomerResponseBody>>("CDP",
        //     //        SAPUrlAddress.CUSTOMER_MASTER_DATA_URL,
        //     //        nameof(SAPUrlAddress.CUSTOMER_MASTER_DATA_URL),
        //     //        requestDomain, 5);
        //     //    if (response.Success && response.RESPONSE != null && response.RESPONSE.Count > 0 && response.RESPONSE[0].MSGTY.Equals("S") && !string.IsNullOrWhiteSpace(response.RESPONSE[0].KUNNR))
        //     //    {
        //     //        enterpriseCode = response.RESPONSE[0].KUNNR.TrimStart('0');
        //     //    }
        //     //    else
        //     //    {
        //     //        errorMessage = response.ResponseJson;
        //     //    }
        //     //    ResponseBody.EnterpriseCode = enterpriseCode;
        //     //    ResponseBody.SapMessage = errorMessage;
        //     //    if (string.IsNullOrEmpty(enterpriseCode))
        //     //    {
        //     //        ResponseHeader.retCode = "N";
        //     //        ResponseHeader.retErrCode = "";
        //     //        ResponseHeader.retMessage = errorMessage;
        //     //    }
        //     //    else
        //     //    {
        //     //        DataTable dt = new DataTable();
        //     //        dt.Columns.Add(new DataColumn("SAP编码", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("销售组织", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("客户名称", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("售达方", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("售达方描述", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("送达方代码", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("送达方描述", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("客户公司电话", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("送货电话", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("街道", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("联系人", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("客户经理", typeof(string)));
        //     //        dt.Columns.Add(new DataColumn("收件邮箱", typeof(string)));
        //     //        DataRow drNew = dt.NewRow();
        //     //        drNew["SAP编码"] = enterpriseCode;
        //     //        if (!string.IsNullOrEmpty(groupEntity.SalesgroupCode))
        //     //            drNew["销售组织"] = groupEntity.SalesgroupCode;
        //     //        else
        //     //            drNew["销售组织"] = "1100";
        //     //        drNew["客户名称"] = order.EnterpriseName;
        //     //        drNew["售达方"] = enterpriseCode;
        //     //        drNew["售达方描述"] = order.EnterpriseName;
        //     //        drNew["送达方代码"] = enterpriseCode;
        //     //        drNew["送达方描述"] = order.EnterpriseName;
        //     //        drNew["客户公司电话"] = order.BuyerCellphone;
        //     //        drNew["送货电话"] = order.BuyerCellphone;
        //     //        drNew["街道"] = order.ShipAddress;
        //     //        drNew["联系人"] = order.ShipName;
        //     //        drNew["客户经理"] = "";
        //     //        drNew["收件邮箱"] = "";
        //     //        dt.Rows.Add(drNew);
        //     //        bool rtn = CDPService.SrcB2cMsEnterpriseService.AutoCreateCustomer("sap", enterpriseCode, order.EnterpriseName, groupEntity.CustomerCode.ToString(), dt, out errorMessage);
        //     //        if (!rtn)
        //     //        {
        //     //            ResponseHeader.retCode = "N";
        //     //            ResponseHeader.retErrCode = "";
        //     //            ResponseHeader.retMessage = errorMessage;
        //     //        }
        //
        //     //        //    #region 扩充销售组织
        //     //        //    //SysSapCustomerParameterEntity kcustomerParameter = CDPService.SapCustomerParameterService.GetCustomerParameter(groupEntity.SupplierCode);
        //     //        //    //SysSapCustomerParameterEntity ref_customerParameter = CDPService.SapCustomerParameterService.GetCustomerParameter(groupEntity.SalesgroupCode);
        //     //        //    //SapCustomerSalesOrgModel model1 = new SapCustomerSalesOrgModel();
        //     //        //    //if (rtn && customerParameter != null && ref_customerParameter != null & groupEntity.SupplierCode != groupEntity.SalesgroupCode)
        //     //        //    //{
        //     //        //    //    model1.MessageID = enterpriseCode + "_" + groupEntity.SupplierCode + "_" + kcustomerParameter.Vtweg;
        //     //        //    //    model1.CustCode = enterpriseCode;
        //     //        //    //    model1.CompanyCode = kcustomerParameter.Bukrs;
        //     //        //    //    model1.SalesOrgCode = groupEntity.SupplierCode;
        //     //        //    //    model1.DistChannelCode = kcustomerParameter.Vtweg;
        //     //        //    //    model1.CustGroupAccount = kcustomerParameter.Ktokd;
        //     //        //    //    model1.ProdGroup = kcustomerParameter.Spart;
        //     //        //    //    model1.Ref_CustCode = enterpriseCode;
        //     //        //    //    model1.Ref_CompanyCode = ref_customerParameter.Bukrs;
        //     //        //    //    model1.Ref_SalesOrgCode = groupEntity.SalesgroupCode;
        //     //        //    //    model1.Ref_DistChannelCode = ref_customerParameter.Vtweg;
        //     //        //    //    model1.Ref_ProdGroup = ref_customerParameter.Spart;
        //     //        //    //    model1.PaymentCode = kcustomerParameter.Zterm;
        //     //        //    //    model1.SalesAreaID = kcustomerParameter.Bzirk;
        //     //        //    //    model1.SalesDeptID = kcustomerParameter.Vkbur;
        //     //        //    //    model1.SalesGroup = kcustomerParameter.Vkgrp;
        //     //        //    //    model1.CustGroup = "";
        //     //        //    //    model1.Currency = kcustomerParameter.Waers;
        //     //        //    //    model1.FactoryCode = kcustomerParameter.Vwerk;
        //     //        //    //    if (!SAPService.CreateSapSalesOrgService.CreateSapCustomerSalesOrg(model1, out errorMessage))
        //     //        //    //    {
        //
        //     //        //    //        if (!(errorMessage.Contains("已针对公司代码") && errorMessage.Contains("建立客户1110011003099")))
        //     //        //    //        {
        //     //        //    //            CDPService.EmailService.Send("LINKKC" + model1.CustCode, "CDP", "hailong.wang@qx.com", "xiaoming.zhu@qx.com;si.ai@qx.com", "自动扩充LINK客户", "自动扩充合约客户错误:" + errorMessage);
        //
        //     //        //    //            ResponseHeader.retCode = "N";
        //     //        //    //            ResponseHeader.retErrCode = "";
        //     //        //    //            ResponseHeader.retMessage = "扩充销售组织错误:" + errorMessage;
        //     //        //    //        }
        //     //        //    //    }
        //     //        //    //}
        //
        //     //        //    #endregion
        //     //    }
        //     //}
        //     //else
        //     //{
        //     //    ResponseHeader.retCode = "N";
        //     //    ResponseHeader.retErrCode = "";
        //     //    ResponseHeader.retMessage = "该客户需要手工创建";
        //     //}
        //
        //
        //     ResponseCreateLinkCustomerToSapSrvDomain ResponseDomain = new ResponseCreateLinkCustomerToSapSrvDomain();
        //     ResponseDomain.MsgHeader = ResponseHeader;
        //     //ResponseDomain.MsgBody = ResponseBody;
        //     return ResponseDomain;
        // }
        //
        // #endregion
        //
        // #region CRM 创建客户
        //
        // /// <summary>
        // /// CRM 创建客户
        // /// </summary>
        // /// <param name="callingDomain"></param>
        // /// <returns></returns>
        // public ResponseCreateSapCustomerSrvDomain CRMCreateCustomer(CreateSapCustomerSrvDomain callingDomain)
        // {
        //     ResponseCreateSapCustomerSrvDomain ResponseDomain = new ResponseCreateSapCustomerSrvDomain();
        //
        //     ResponseHeader ResponseHeader = new ResponseHeader();
        //     ResponseHeader.retCode = "Y";
        //     ResponseHeader.retErrCode = "";
        //     ResponseHeader.retMessage = "";
        //
        //     ResponseCreateSapCustomerSrvBody ResponseBody = new ResponseCreateSapCustomerSrvBody();
        //
        //     #region check逻辑
        //     string errorMsg = string.Empty;
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.localCustomerCode))
        //     {
        //         errorMsg += "客户编码不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.customerName))
        //     {
        //         errorMsg += "客户名称不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.custAccGroupID))
        //     {
        //         errorMsg += "科目组不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.companyCode))
        //     {
        //         errorMsg += "公司代码不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.salesOrgCode))
        //     {
        //         errorMsg += "销售组织不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.channleCode))
        //     {
        //         errorMsg += "销售渠道不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.productGroupID))
        //     {
        //         errorMsg += "产品组不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.searchItem))
        //     {
        //         errorMsg += "搜索项不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.street))
        //     {
        //         errorMsg += "街道不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.country))
        //     {
        //         errorMsg += "国家不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.zipCode))
        //     {
        //         errorMsg += "邮政编码不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.telphone))
        //     {
        //         errorMsg += "客户公司电话不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.fax))
        //     {
        //         errorMsg += "传真不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.customerCategory))
        //     {
        //         errorMsg += "客户分类不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.akont))
        //     {
        //         errorMsg += "统驭科目不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.salesArea))
        //     {
        //         errorMsg += "销售区域不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.salesDept))
        //     {
        //         errorMsg += "销售办公室不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.salesGroup))
        //     {
        //         errorMsg += "销售组不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.currency))
        //     {
        //         errorMsg += "货币码不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.kalks))
        //     {
        //         errorMsg += "定价过程不能为空;";
        //     }
        //     if (string.IsNullOrEmpty(callingDomain.MsgBody.contractTphone))
        //     {
        //         errorMsg += "联系电话不能为空;";
        //     }
        //
        //     if (!string.IsNullOrEmpty(errorMsg))
        //     {
        //         ResponseHeader.retCode = "N";
        //         ResponseHeader.retErrCode = "0060";
        //         ResponseHeader.retMessage = "创建客户失败:" + errorMsg;
        //         ResponseDomain.MsgHeader = ResponseHeader;
        //         ResponseDomain.MsgBody = ResponseBody;
        //         return ResponseDomain;
        //     }
        //     #endregion
        //
        //     PORequestDomain<List<CustomerResquestBody>> requestDomain = new PORequestDomain<List<CustomerResquestBody>>();
        //     CustomerResquestBody model = new CustomerResquestBody();
        //     model.BASIC_DATA = new BasicData();
        //     model.KUNNR ="";
        //     model.MSGID ="";
        //     model.BUKRS_DATA = new List<BukrsDataItem>();
        //     model.SALES_DATA = new List<SalesDataItem>();
        //     var saleModel = new SalesDataItem()
        //     {
        //         VKORG = callingDomain.MsgBody.salesOrgCode,
        //         VTWEG = callingDomain.MsgBody.channleCode,
        //         BZIRK = callingDomain.MsgBody.salesArea,  //销售地区 
        //         VKBUR = callingDomain.MsgBody.salesDept,  //销售部门 
        //         VKGRP = callingDomain.MsgBody.salesGroup,  //销售组
        //         VWERK = callingDomain.MsgBody.factoryCode,  //交货工厂 (自有或外部)
        //         SPART = callingDomain.MsgBody.productGroupID,  //产品组                                         // AWAHR="100",
        //         BEGRU = callingDomain.MsgBody.salesDept,
        //         WAERS = callingDomain.MsgBody.currency,
        //         KALKS = string.IsNullOrWhiteSpace(callingDomain.MsgBody.kalks) ?"1":callingDomain.MsgBody.kalks,  //定价过程分配到该客户
        //         LPRIO = callingDomain.MsgBody.lprio.ToString(),  //交货优先权 
        //         KTGRD = string.IsNullOrWhiteSpace(callingDomain.MsgBody.accountGroup)?"01": callingDomain.MsgBody.accountGroup,
        //         TAXKD = callingDomain.MsgBody.taxCategory,
        //         VSBED = string.IsNullOrWhiteSpace(callingDomain.MsgBody.vsbed)?"01": callingDomain.MsgBody.vsbed,
        //         INCO1 = callingDomain.MsgBody.inco1,
        //         INCO2 = callingDomain.MsgBody.inco2 = "shenzhen",
        //         KDGRP = callingDomain.MsgBody.customerGroup,
        //         ZTERM = callingDomain.MsgBody.paymentCode
        //     };
        //
        //     var BukrsModel = new BukrsDataItem()
        //     {
        //         BUKRS = callingDomain.MsgBody.companyCode,
        //         AKONT = callingDomain.MsgBody.akont,
        //         ZTERM = callingDomain.MsgBody.paymentCode
        //     };
        //     if (!string.IsNullOrWhiteSpace(callingDomain.MsgBody.bankAccount))
        //     {
        //         model.BANK_DATA = new List<BankDataItem>() {
        //             new BankDataItem()
        //             {
        //                 BANKN = callingDomain.MsgBody.bankAccount,  //增票银行帐户号码
        //                 KOINH = callingDomain.MsgBody.bankUser,  //增票帐户持有人姓名 
        //                 BANKS = callingDomain.MsgBody.banksCountry, //银行国家代码
        //                 BANKL="5018000000" //银行代码
        //
        //             }
        //         };
        //     }
        //     model.CONTACT_BP = new List<ContactBPItem>() {
        //             new ContactBPItem()
        //             {
        //
        //               ABTNR = "", //部门编号
        //               NAME1 = callingDomain.MsgBody.customerName,  //名称
        //               TELF1=callingDomain.MsgBody.contractTphone,
        //               NAMEV=callingDomain.MsgBody.contractPerson,
        //
        //             }
        //         };
        //
        //     model.BUKRS_DATA.Add(BukrsModel);
        //     model.SALES_DATA.Add(saleModel);
        //     model.BASIC_DATA.KTOKD = callingDomain.MsgBody.custAccGroupID;  //客户帐户组 
        //     model.BASIC_DATA.LANGU = "1";//默认1
        //     model.BASIC_DATA.NAME1 = callingDomain.MsgBody.customerName;  //名称
        //     model.BASIC_DATA.LOCATION = callingDomain.MsgBody.street;  //街道 5
        //     model.BASIC_DATA.HOUSE_NUM1 = callingDomain.MsgBody.houseNo;
        //     model.BASIC_DATA.COUNC = callingDomain.MsgBody.countryCode;  //县代码编号
        //     model.BASIC_DATA.REGION = callingDomain.MsgBody.provinceCode;  //地区 (州、省、县)编号
        //     model.BASIC_DATA.KUKLA = callingDomain.MsgBody.customerCategory;  //客户分类
        //
        //     model.BASIC_DATA.TEL_NUMBER = callingDomain.MsgBody.contractTphone;  //第一个电话号
        //     model.BASIC_DATA.STKZA = "";  //平衡税（普票）
        //     model.BASIC_DATA.STCEG = callingDomain.MsgBody.taxNo;  //增值税登记号 
        //
        //     model.BASIC_DATA.STREET = callingDomain.MsgBody.street;  //街道
        //     model.BASIC_DATA.POST_CODE1 = callingDomain.MsgBody.zipCode;  //城市邮政编码
        //
        //     model.BASIC_DATA.COUNTRY = callingDomain.MsgBody.country;  //国家代码
        //
        //     model.BASIC_DATA.TELF2 = callingDomain.MsgBody.telphone;  //第一个电话号码: 拨号 + 编号
        //
        //     model.BASIC_DATA.FAX_NUMBER = callingDomain.MsgBody.fax;  //第一个传真号: 拨号 + 编号
        //     model.BASIC_DATA.SORT1 = callingDomain.MsgBody.searchItem;  //检索项1
        //     model.BASIC_DATA.SORT2 = "";  //检索项2
        //     model.BASIC_DATA.BRSCH = callingDomain.MsgBody.industry;  //第二级分类，行业代码
        //     model.BASIC_DATA.BRAN1 = callingDomain.MsgBody.industry1;  //第三级分类，行业代码1
        //     model.BASIC_DATA.RPMKR = "";  //地区市场
        //     model.BASIC_DATA.NIELS = "";  //Nielsen 标识（尼尔森指示符)
        //     model.BASIC_DATA.PO_BOX = "";
        //
        //     model.BASIC_DATA.CITY1 = callingDomain.MsgBody.cityCode;
        //     model.BASIC_DATA.CITYC = callingDomain.MsgBody.cityCode;
        //     foreach (var item in callingDomain.MsgBody.knvp)
        //     {
        //         saleModel.PARVW_DATA = new List<ParvwDataItem>() {
        //                 new ParvwDataItem()
        //                 {
        //                        KUNN2 = item.kunn2,
        //                     PARVW = item.parvw
        //                 }
        //             };
        //     }
        //     requestDomain.REQUEST = new List<CustomerResquestBody>();
        //     requestDomain.REQUEST.Add(model);
        //     var response = SAPPOHelper.Send<List<CustomerResquestBody>,
        //         List<CustomerResponseBody>>("CRM",
        //         SAPUrlAddress.CUSTOMER_MASTER_DATA_URL,
        //         nameof(SAPUrlAddress.CUSTOMER_MASTER_DATA_URL),
        //         requestDomain);
        //
        //     if (response.Success && response.RESPONSE != null && response.RESPONSE.Count > 0 && response.RESPONSE[0].MSGTY.Equals("S") && !string.IsNullOrWhiteSpace(response.RESPONSE[0].KUNNR))
        //     {
        //         ResponseBody.customerCode = response.RESPONSE[0].KUNNR.TrimStart('0');
        //     }
        //     else
        //     {
        //         string errorMessage = response.ResponseJson;
        //         //系统已存在该客户的编号，请去查看sap其他资料信息是否一致！0002011590
        //         if (errorMessage.Contains("系统已存在该客户的编号"))
        //         {
        //             string code = errorMessage.Replace("系统已存在该客户的编号，请去查看sap其他资料信息是否一致！", "").TrimStart('0');
        //             if (code.Length == 7)
        //             {
        //                 ResponseBody.customerCode = code;
        //             }
        //             else
        //             {
        //                 ResponseHeader.retCode = "N";
        //                 ResponseHeader.retErrCode = "0060";
        //                 ResponseHeader.retMessage = "创建客户失败:" + errorMessage;
        //
        //             }
        //
        //         }
        //         else
        //         {
        //             ResponseHeader.retCode = "N";
        //             ResponseHeader.retErrCode = "0060";
        //             ResponseHeader.retMessage = "创建客户失败:" + errorMessage;
        //
        //         }
        //
        //     }
        //
        //     ResponseDomain.MsgHeader = ResponseHeader;
        //     ResponseDomain.MsgBody = ResponseBody;
        //     return ResponseDomain;
        // }
        // #endregion
    }
}
