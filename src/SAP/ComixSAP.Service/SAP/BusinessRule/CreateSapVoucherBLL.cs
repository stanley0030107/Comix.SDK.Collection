using System;
using System.Linq;
using ComixSAP.Common;
using ComixSAP.Common.Enums;

namespace ComixSAP.Service
{
    public class CreateSapVoucherBLL 
    {
        public virtual bool CreateSapVoucher( NewVoucherEntity entity,out string strVouNo, out string errorMessage)
        {
            errorMessage = "";
            strVouNo = "";
            try
            {
                

                entity.Validate();
                SapStructureService<NewVoucherEntity>.GetSAPRFCEntity(entity);
                if (entity.ReturnMessageList != null && entity.ReturnMessageList[0].ReturnType.Equals(SAPErrorLogType.S.ToString()))
                {
                    foreach (var item in entity.ReturnMessageList)
                    {
                        if (!string.IsNullOrWhiteSpace(strVouNo))
                        {
                            strVouNo += ",";
                        }
                        strVouNo += item.MessageV2;
                    }

                   // strVouNo =string.Join(",", entity.ReturnMessageList.Select(x => x.MessageV2).ToArray<string>()) ;//entity.ReturnMessageList[0].MessageV2;
                    return true;
                }
                else
                {
                    errorMessage = string.Join(",", entity.ReturnMessageList.Select(x => x.Message).ToArray<string>());
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "新版自动凭证发生错误!错误：" + ex.Message + ex.StackTrace;
                return false;
            }
        }

    }
}

