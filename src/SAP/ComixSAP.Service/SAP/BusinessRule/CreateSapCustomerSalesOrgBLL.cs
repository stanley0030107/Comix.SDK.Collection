using System.Collections.Generic;
using System.Text;
using ComixSAP.Common.Entity;
using ComixSAP.Common.Model;

namespace ComixSAP.Service
{
    public class CreateSapSalesOrgBLL 
    {
        public virtual bool CreateSapCustomerSalesOrg(SapCustomerSalesOrgModel salesOrg, out string errorMessage)
        {
            errorMessage = "";
            // try
            // {
                CreateSapCustomerSalesOrgEntity entity = new CreateSapCustomerSalesOrgEntity();

                List<CreateSapCustomerSalesOrgModel> salesOrgList = new List<CreateSapCustomerSalesOrgModel>();

                CreateSapCustomerSalesOrgModel model = new CreateSapCustomerSalesOrgModel();
                model.Messageid = salesOrg.MessageID;  // 流水号__是
                model.Kunnr001 = salesOrg.CustCode;  // 客户编号1__是
                model.Bukrs002 = salesOrg.CompanyCode;  // 公司代码__是
                model.Vkorg003 = salesOrg.SalesOrgCode;  // 销售组织__是
                model.Vtweg004 = salesOrg.DistChannelCode;  // 分销渠道__是
                model.Ktokd006 = salesOrg.CustGroupAccount;  // 客户帐户组__是
                model.Spart005 = salesOrg.ProdGroup;  // 产品组__是
                model.RefKunnr007 = salesOrg.Ref_CustCode;  // 客户编号1_参考的客户编号_是
                model.RefBukrs008 = salesOrg.Ref_CompanyCode;  // 公司代码_参考的公司代码_是
                model.RefVkorg009 = salesOrg.Ref_SalesOrgCode;  // 销售组织_参考的销售组织_是
                model.RefVtweg010 = salesOrg.Ref_DistChannelCode;  // 分销渠道_参考分销渠道_是
                model.RefSpart011 = salesOrg.Ref_ProdGroup;  // 产品组_参考的产品组_是
                model.Zterm013 = salesOrg.PaymentCode;  // 付款条件代码__是
                model.Bzirk014 = salesOrg.SalesAreaID;  // 销售地区__是
                model.Vkbur016 = salesOrg.SalesDeptID;  // 销售部门__是
                model.Vkgrp017 = salesOrg.SalesGroup;  // 销售组__是
                model.Kdgrp018 = "10";//客户组.
                
                model.Waers019 = salesOrg.Currency;  // 货币码__是
                model.Vwerk026 = salesOrg.FactoryCode;  // 工厂_默认工厂对应表见sheet2_是
                salesOrgList.Add(model);
                List<CreateSapCustomerSalesOrgReturnModel> returnlist = new List<CreateSapCustomerSalesOrgReturnModel>();
                CreateSapCustomerSalesOrgReturnModel returnModel = new CreateSapCustomerSalesOrgReturnModel();
                returnlist.Add(returnModel);
                entity.ReturnList = returnlist;
                entity.SalesOrgList = salesOrgList;

                entity.Validate();
                SapStructureService<CreateSapCustomerSalesOrgEntity>.GetSAPRFCEntity(entity);

                bool isSuccess = false;
                StringBuilder errorStr = new StringBuilder();
                returnlist = entity.ReturnList;
                for (int i = 0; i < returnlist.Count; i++)
                {
                    if (returnlist[i].Msgtyp.ToUpper().Equals("S") && returnlist[i].Msgnr.Equals("174"))
                    {
                        isSuccess =true;
                        break;
                    }
                    errorStr.AppendLine(returnlist[i].Msgv1 + returnlist[i].Msgv2 + returnlist[i].Msgv3 + returnlist[i].Msgv4 + ";");
                }

                if (!isSuccess)
                {
                    errorMessage = "SAP返回错误信息:" + errorStr.Replace("&", "").Replace(" ", "");
                    return false;
                }
                else
                {

                    return true;
                }
            // }
            // catch (Exception ex)
            // {
            //     errorMessage = "执行发生异常!";
            //     SysEmailEntity mailEntity = new SysEmailEntity();
            //     mailEntity.EMAIL_ID = Guid.NewGuid().ToString();
            //     mailEntity.EMAIL_KEYCODE = "";
            //     mailEntity.EMAIL_TITLE = "扩建SAP客户[" + salesOrg.CustCode+ "]错误"+ex.Message;
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
            //     return false;
            // }
        }
    }
}
