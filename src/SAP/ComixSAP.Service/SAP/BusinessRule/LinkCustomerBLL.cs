using System;
using System.Collections.Generic;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class LinkCustomerBLL 
    {
        public virtual string CreateLinkCustomer(LinkCustomerModel customer, out string errorMessage)
        {
            errorMessage = "";
            string emailContent = "";
            // try
            // {                
                CreateCustomerEntity entity = new CreateCustomerEntity();
                List<CreateCustomerModel> customerList = new List<CreateCustomerModel>();
                List<CreateKnvpModel> knvpList = new List<CreateKnvpModel>();

                CreateCustomerModel model = new CreateCustomerModel();
                model.Ktokd = customer.KTOKD;  //客户帐户组 
                model.Bukrs = customer.BUKRS;  //公司代码
                model.Vkorg = customer.VKORG;  //销售组织 
                model.Vtweg = customer.VTWEG;  //分销渠道
                model.Kunnr = "";  //客户编号1
                model.Name1 = customer.NAME1;  //名称
                model.Location = customer.LOCATION;  //街道 5
                model.Counc = customer.COUNC;  //县代码编号
                model.Region = customer.REGION;  //地区 (州、省、县)编号
                model.City = customer.CITY;  //城市编号
                model.Kukla = customer.KUKLA;  //客户分类
                model.Bzirk = customer.BZIRK;  //销售地区 
                model.Vkbur = customer.VKBUR;  //销售部门 
                model.Vkgrp = customer.VKGRP;  //销售组
                model.Vwerk = customer.VWERK;  //交货工厂 (自有或外部)
                model.Nxname1 = customer.NXNAME1;  //名称 1
                model.Telf1 = customer.TELF1;  //第一个电话号
                model.Stkza = customer.STKZA;  //平衡税（普票）
                model.Stceg = customer.STCEG;  //增值税登记号 
                model.Bankn = customer.BANKN;  //增票银行帐户号码
                model.Koinh = customer.KOINH;  //增票帐户持有人姓名 
                model.Tlfns = customer.TLFNS;  //增票电话
                model.Intad = customer.INTAD;  //增票地址
                model.Namev = customer.NAMEV;  //名 
                model.Spart = customer.SPART;  //产品组 
                model.Street = customer.STREET;  //街道
                model.PostCod1 = customer.POST_COD1;  //城市邮政编码
                model.Klabc = customer.KLABC;  //客户分类( ABC 分析)
                model.Akont = customer.AKONT;  //总帐中的统驭科目
                model.Zterm = customer.ZTERM;  //付款条件代码
                model.Waers = customer.WAERS;  //货币码 
                model.Banks = customer.BANKS;  //银行国家代码
                model.Country = customer.COUNTRY;  //国家代码
                model.Langu = customer.LANGU;  //语言代码
                model.Abtnr = customer.ABTNR;  //部门编号
                model.Kalks = customer.KALKS;  //定价过程分配到该客户
                model.TelNumber = customer.TEL_NUMBER;  //第一个电话号码: 拨号 + 编号
                model.Lprio = customer.LPRIO;  //交货优先权 
                model.Ktgrd = customer.KTGRD;  //客户组的帐户分配
                model.Taxkd = customer.TAXKD;  //客户税分类 
                model.Vsbed = customer.VSBED;  //装运条件
                model.Antlf = customer.ANTLF;  //每个项目允许的部分交货最大数
                model.Konda = customer.KONDA;  //价格组(客户)
                model.Pltyp = customer.PLTYP;  //价格清单类型
                model.Versg = customer.VERSG;  //客户统计组 
                model.Inco1 = customer.INCO1;  //国际贸易条款 (部分1)
                model.Inco2 = customer.INCO2;  //国际贸易条件(部分2)
                model.Title = customer.TITLE;  //地址关键字的表格
                model.MobNumber = customer.MOB_NUMBER;  //第一个移动电话号码：区号 + 电话号码
                model.FaxNumber = customer.FAX_NUMBER;  //第一个传真号: 拨号 + 编号
                model.Sort1 = customer.SORT1;  //检索项1
                model.Sort2 = customer.SORT2;  //检索项2

                model.Brsch = customer.BRSCH;  //第二级分类，行业代码
                model.Bran1 = customer.BRAN1;  //第三级分类，行业代码1
                model.Rpmkr = customer.RPMKR;  //地区市场
                model.Niels = customer.NIELS;  //Nielsen 标识（尼尔森指示符)
                model.Email = customer.EMAIL;
                model.Kdgrp = customer.KDGRP;
                customerList.Add(model);
                entity.CustomerList = customerList;                
                entity.KnvpList = knvpList;
                //送达方默认为自己
                entity.Validate();
                SapStructureService<CreateCustomerEntity>.GetSAPRFCEntity(entity);
                if (entity.ReturnType.Equals("S"))
                {
                    //CDPService.EmailService.Send("LINK" + entity.ReturnMessage.TrimStart('0'), "创建合约客户", "hailong.wang@qx.com", "xiaoming.zhu@qx.com;si.ai@qx.com", "自动创建LINK客户", "自动创建合约客户:" + model.Name1 + "成功，客户为【" + entity.ReturnMessage.TrimStart('0') + "】");
                    return entity.ReturnMessage.TrimStart('0');
                }
                else
                {                    
                    errorMessage = entity.ReturnMessage;
                    //系统已存在该客户的编号，请去查看sap其他资料信息是否一致！0002011590
                    if (errorMessage.Contains("系统已存在该客户的编号"))
                    {
                        string code = errorMessage.Replace("系统已存在该客户的编号，请去查看sap其他资料信息是否一致！", "").TrimStart('0');
                        if (code.Length == 7)
                            return code;
                    }

                }
                return "";
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!";
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "创建SAP客户["+customer.NAME1+"]错误";
            //     mailEntity.EMAIL_TOUSER = "shengwu.he@qx.com";
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
