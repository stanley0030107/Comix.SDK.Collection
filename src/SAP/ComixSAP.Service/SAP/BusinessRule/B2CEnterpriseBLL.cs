using System;
using System.Collections.Generic;
using ComixSAP.Common.Entity;
using ComixSAP.Service.Common;
using ComixSAP.Common.Model;
using ComixSAP.API.Service;

namespace ComixSAP.Service
{
    public class B2CEnterpriseBLL : BusinessBase
    {
        public virtual string CreateSAPCustomer(ComixB2C.Common.Entity.MsEnterpriseEntity b2cEnterpriseEntity, ComixB2C.Common.Entity.MsEnterprisegroupEntity b2cgroup, SysSapCustomerParameterEntity customerParameter, out string errorMessage)
        {
            errorMessage = "";
            string emailContent = "";
            // try
            // {
                if (SAPPOHelper.POIsEnable)
                {
                    return POService.CreateCustomerService.B2CCreateCustomer(b2cEnterpriseEntity, b2cgroup,customerParameter, out errorMessage);
                }
                //创建过滤表
                //string dataKey = "CUSTOMER_" + b2cEnterpriseEntity.ContactMail;
                //SysDataFilterEntity filterEntity = new SysDataFilterEntity();
                //using (DataAccessBroker broker = DataAccessFactory.Instance())
                //{                    
                //    filterEntity.DataKey = dataKey;
                //    DataAccess.Insert(filterEntity, broker);
                //}
                CreateCustomerEntity entity = new CreateCustomerEntity();
                List<CreateCustomerModel> customerList = new List<CreateCustomerModel>();
                List<CreateKnvpModel> knvpList = new List<CreateKnvpModel>();

                CreateCustomerModel model = new CreateCustomerModel();
                model.Ktokd = b2cEnterpriseEntity.CustAccGroupID;  //客户帐户组 
                model.Bukrs = b2cEnterpriseEntity.SupplierCode;  //公司代码
                model.Vkorg = b2cEnterpriseEntity.SupplierCode;  //销售组织 
                model.Vtweg = b2cEnterpriseEntity.CompanyType.ToString();  //分销渠道
                model.Kunnr = "";  //客户编号1
                model.Name1 = b2cEnterpriseEntity.Name;  //名称
                model.Location = b2cEnterpriseEntity.Address;  //街道 5
                model.Counc = b2cEnterpriseEntity.SAPCounty;  //县代码编号
                model.Region = b2cEnterpriseEntity.SAPProvince;  //地区 (州、省、县)编号
                model.City = b2cEnterpriseEntity.SAPCity;  //城市编号
                model.Kukla = b2cEnterpriseEntity.EnterpriseType.ToString();  //客户分类
                model.Bzirk = b2cEnterpriseEntity.SaleArea;  //销售地区 
                model.Vkbur = b2cEnterpriseEntity.SaleOrg;  //销售部门 
                model.Vkgrp = b2cEnterpriseEntity.SaleGroup;  //销售组
                model.Vwerk = b2cEnterpriseEntity.StockCode;  //交货工厂 (自有或外部)
                model.Nxname1 = b2cEnterpriseEntity.Name;  //名称 1
                model.Telf1 = b2cEnterpriseEntity.TelPhone;  //第一个电话号
                model.Stkza = b2cEnterpriseEntity.VATType;  //平衡税（普票）
                model.Stceg = b2cEnterpriseEntity.VATAccountNo;  //增值税登记号 
                model.Bankn = b2cEnterpriseEntity.VATAccountNo;  //增票银行帐户号码
                model.Koinh = b2cEnterpriseEntity.VATAccountName;  //增票帐户持有人姓名 
                model.Tlfns = b2cEnterpriseEntity.VATTelephone;  //增票电话
                model.Intad = b2cEnterpriseEntity.VATAddress;  //增票地址
                model.Namev = b2cEnterpriseEntity.Name;  //名 
                model.Spart = b2cEnterpriseEntity.ProductGroup;  //产品组 
                model.Street = b2cEnterpriseEntity.Street;  //街道
                model.PostCod1 = b2cEnterpriseEntity.PostCode;  //城市邮政编码
                model.Klabc = b2cEnterpriseEntity.CustomerABC;  //客户分类( ABC 分析)
                model.Akont = b2cEnterpriseEntity.SAPAccountItem;  //总帐中的统驭科目
                model.Zterm = b2cEnterpriseEntity.PayConditionCode;  //付款条件代码
                model.Waers = b2cEnterpriseEntity.Currency;  //货币码 
                model.Banks = "CN";  //银行国家代码
                model.Country = "CN";  //国家代码
                model.Langu = "ZH";  //语言代码
                model.Abtnr = "0004";  //部门编号
                model.Kalks = "1";  //定价过程分配到该客户
                model.TelNumber = b2cEnterpriseEntity.TelPhone;  //第一个电话号码: 拨号 + 编号
                model.Lprio = 1;  //交货优先权 
                model.Ktgrd = "01";  //客户组的帐户分配
                model.Taxkd = "1";  //客户税分类 
                model.Vsbed = "01";  //装运条件
                model.Antlf = 9;  //每个项目允许的部分交货最大数
                model.Konda = "";  //价格组(客户)
                model.Pltyp = "";  //价格清单类型
                model.Versg = "";  //客户统计组 
                model.Inco1 = "";  //国际贸易条款 (部分1)
                model.Inco2 = "";  //国际贸易条件(部分2)
                model.Title = "";  //地址关键字的表格
                model.MobNumber = b2cEnterpriseEntity.CellPhone;  //第一个移动电话号码：区号 + 电话号码
                model.FaxNumber = b2cEnterpriseEntity.Fax;  //第一个传真号: 拨号 + 编号
                model.Sort1 = b2cEnterpriseEntity.SearchItem;  //检索项1
                model.Sort2 = b2cEnterpriseEntity.UserName;  //检索项2
                model.Brsch = b2cEnterpriseEntity.BusinessCode;  //第二级分类，行业代码
                model.Bran1 = b2cEnterpriseEntity.BusinessCode2;  //第三级分类，行业代码1
                model.Rpmkr = b2cEnterpriseEntity.AreaMarket;  //地区市场
                model.Niels = b2cEnterpriseEntity.NielsonFlag;  //Nielsen 标识（尼尔森指示符)
                model.Email = b2cEnterpriseEntity.ContactMail;
                model.Kdgrp = "99";
                customerList.Add(model);
                entity.CustomerList = customerList;
                entity.KnvpList = knvpList;
                //送达方默认为自己
                entity.Validate();
                SapStructureService<CreateCustomerEntity>.GetSAPRFCEntity(entity);
                if (entity.ReturnType.Equals("S"))
                {
                    return entity.ReturnMessage;
                }
                else
                {
                    string sapErrorMessage = entity.ReturnMessage;
                    //系统已存在该客户的编号，请去查看sap其他资料信息是否一致！0002011590
                    if (sapErrorMessage.Contains("系统已存在该客户的编号"))
                    {
                        string code = sapErrorMessage.Replace("系统已存在该客户的编号，请去查看sap其他资料信息是否一致！", "").TrimStart('0');
                        if (code.Length == 7)
                        {
                           return code;
                        }
                        else
                        {
                            //DataAccess.Delete(filterEntity);
                            errorMessage = entity.ReturnMessage;
                            return "";
                        }
                    }
                    else
                    {
                        //DataAccess.Delete(filterEntity);
                        errorMessage = entity.ReturnMessage;
                        return "";
                    }
                }
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!"+ex.Message;
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "创建SAP客户["+b2cEnterpriseEntity.Name+"]错误";
            //     mailEntity.EMAIL_TOUSER = "jungui.sun@qx.com";
            //     mailEntity.EMAIL_CCUSER = "";
            //     mailEntity.EMAIL_CONTENT = "错误:" + errorMessage;
            //     mailEntity.ATTACHMENTS_PATH = "";
            //     mailEntity.EMAIL_DATE = DateTime.Now;
            //     mailEntity.EMAIL_SENDER = "";
            //     mailEntity.SEND_TIMES = 0;
            //     mailEntity.SEND_STATUS = 0;
            //     mailEntity.REMARK = "";
            //     mailEntity.LAST_MODIFIED_BY = "EDI";
            //     mailEntity.LAST_MODIFIED_TIME = DateTime.Now;
            //     DataAccess.Insert(mailEntity);
            //     return "";
            // }
        }
    }
}
