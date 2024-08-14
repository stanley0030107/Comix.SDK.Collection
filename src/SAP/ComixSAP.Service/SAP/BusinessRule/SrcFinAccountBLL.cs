using Comix.Pay.Model.SrcFinAccountModels;
using Comix.Pay.SDK.Services;
using ComixCDP.Common.Entity;
using ComixSAP.API.Service;
using ComixSAP.Service.Common;
using Furion;
using Suzsoft.Smart.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace ComixSAP.Service
{
    public class SrcFinAccountBLL : BusinessBase
    {
        public virtual bool GetRealDataFromSAPNew(string enterpriseCode, string creditScope, out string errorMessage)
        {
            var srcFinAccountModel = new SrcFinAccountDto();
            errorMessage = "";
            string emailContent = "开始实时读取信控信息:\r\n ";
            emailContent += " 客户编号:" + enterpriseCode + "\r\n";
            emailContent += " 开始时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
            string dataKey = "ACT_" + enterpriseCode;
            //SysDataLockEntity lockEntity = new SysDataLockEntity { DataKey = dataKey };
            API.Service.FIN.CustomerBalanceBLL APIHelper = new API.Service.FIN.CustomerBalanceBLL();
            try
            {
                DataTable dt = null;
                //if (!IsExist(dataKey))
                //{
                //    DataAccess.Insert(lockEntity);
                //}
                DateTime dtStart = DateTime.Now;

                #region 传入Table

                if (!API.Service.SAPPOHelper.POIsEnable)
                {
                    DataTable dtInput = new DataTable();
                    dtInput.Columns.Add("KKBER");
                    DataRow dr1 = dtInput.NewRow();
                    dr1[0] = "2000";
                    dtInput.Rows.Add(dr1);
                    DataRow dr2 = dtInput.NewRow();
                    dr2[0] = "2500";
                    dtInput.Rows.Add(dr2);
                    dt = SAPSyncBLL.Instance.GetSAPDataByNfc2("ZDRPBALANCE", new List<string>() { enterpriseCode, "1100" }, dtInput);
                }
                else
                {
                    dt = APIHelper.CustomerBalanceData(enterpriseCode, "1100");
                }

                #endregion 传入Table

                DateTime dtEnd = DateTime.Now;
                TimeSpan ts = dtEnd - dtStart;
                emailContent += " 结束时间:" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                emailContent += " 访问SAP耗费时长:" + ts.TotalSeconds.ToString() + "\r\n   ";

                var pay = App.GetService<IPayService>();


                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] drs2000 = dt.Select("KKBER='2000'");

                    #region ODLCODE

                    foreach (DataRow dr in drs2000)
                    {
                        emailContent += " 逾期金额:" + dr["DMBTR"].ToString();
                        bool isNew = false;
                        decimal oldAvailableBalance = 0;
                        string kunnr = dr["KUNNR"].ToString().TrimStart('0');
                        var resp = pay.GetSrcFinAccountByCode(new Comix.Pay.SDK.Models.RequestHeader(), kunnr);
                        var searchEntity = resp.MsgBody;
                        if (searchEntity == null)
                        {
                            isNew = true;
                        }
                        else
                        {
                            srcFinAccountModel.AccountCode = searchEntity.AccountCode;
                            srcFinAccountModel.AccountType = "00";
                            srcFinAccountModel.AccountName = "基本账户";
                            srcFinAccountModel.EnterpriseCode = searchEntity.AccountCode;
                            srcFinAccountModel.TotalBalance = searchEntity.TotalBalance;
                            srcFinAccountModel.LockBalance = searchEntity.LockBalance;
                            srcFinAccountModel.AvailableBalance = searchEntity.AvailableBalance;
                            srcFinAccountModel.CreditLimit = searchEntity.CreditLimit;
                            srcFinAccountModel.CreditUsed = searchEntity.CreditLimit;
                            srcFinAccountModel.CreditOver = searchEntity.CreditOver;
                            srcFinAccountModel.PayconditionCode = searchEntity.PayconditionCode;
                            srcFinAccountModel.Remark = searchEntity.Remark;
                            srcFinAccountModel.CreatedBy = searchEntity.CreatedBy;
                            srcFinAccountModel.CreatedTime = searchEntity.CreatedTime;
                            srcFinAccountModel.ModifiedBy = "EDI";
                            srcFinAccountModel.ModifiedTime = DateTime.Now;
                            oldAvailableBalance = searchEntity.AvailableBalance;
                        }

                        srcFinAccountModel.AccountCode = kunnr;
                        srcFinAccountModel.EnterpriseCode = kunnr;
                        srcFinAccountModel.PayconditionCode = dr["ZTERM"].ToString();
                        srcFinAccountModel.CreditLimit = Convert.ToDecimal(dr["KLIMK"].ToString());
                        srcFinAccountModel.CreditOver = Convert.ToDecimal(dr["DMBTR"].ToString());
                        if (srcFinAccountModel.AccountCode.Equals("2100") ||
                            srcFinAccountModel.AccountCode.Equals("2200") ||
                            srcFinAccountModel.AccountCode.Equals("2300") ||
                            srcFinAccountModel.AccountCode.Equals("2400") ||
                            srcFinAccountModel.AccountCode.Equals("5300"))
                        {
                            srcFinAccountModel.CreditLimit = 999999999;
                        }

                        //账期客户处理
                        srcFinAccountModel.TotalBalance = Convert.ToDecimal(dr["OBLIG"].ToString()); //表示应收总额
                        if (Convert.ToDecimal(dr["OBLIG"].ToString()) > 0) //已使用额度
                        {
                            srcFinAccountModel.CreditUsed = Convert.ToDecimal(dr["OBLIG"].ToString());
                        }
                        else
                        {
                            //余额
                            srcFinAccountModel.CreditUsed = 0;
                        }

                        srcFinAccountModel.AvailableBalance = -Convert.ToDecimal(dr["OBLIG"].ToString());
                        srcFinAccountModel.LockBalance = Convert.ToDecimal(dr["SAUFT"].ToString());
                        bool if1 = false;
                        if (API.Service.SAPPOHelper.POIsEnable)
                        {
                            if1 = !srcFinAccountModel.PayconditionCode.Equals("Z022") && srcFinAccountModel.AvailableBalance < 0;
                        }
                        else
                        {
                            if1 = !srcFinAccountModel.PayconditionCode.Equals("0001") && srcFinAccountModel.AvailableBalance < 0;
                        }
                        if (if1)
                        {
                            srcFinAccountModel.AvailableBalance = 0;
                        }

                        if (isNew)
                        {
                            srcFinAccountModel.SapUpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                            pay.SaveSrcFinAccount(new Comix.Pay.SDK.Models.RequestHeader(), srcFinAccountModel);
                        }
                        else
                        {
                            //判断有不同才更新
                            if (srcFinAccountModel.TotalBalance != searchEntity.TotalBalance
                                || srcFinAccountModel.AvailableBalance != searchEntity.AvailableBalance
                                || srcFinAccountModel.LockBalance != searchEntity.LockBalance
                                || srcFinAccountModel.CreditLimit != searchEntity.CreditLimit
                                || srcFinAccountModel.CreditOver != searchEntity.CreditOver
                                || srcFinAccountModel.CreditUsed != searchEntity.CreditUsed)
                            {
                                srcFinAccountModel.SapUpdateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                                //不更新
                                pay.SaveSrcFinAccount(new Comix.Pay.SDK.Models.RequestHeader(), srcFinAccountModel);
                            }
                        }
                    }

                    #endregion ODLCODE

                    srcFinAccountModel.BUKRS = dt.Rows[0]["BUKRS"].ToString();
                    srcFinAccountModel.KUNNR = dt.Rows[0]["KUNNR"].ToString();
                    //处理现金科目部分

                    #region 2000

                    if (drs2000 != null && drs2000.Length > 0)
                    {
                        #region NEWCODE

                        DataRow dr2000 = drs2000[0];
                        srcFinAccountModel.Klimk2000 = Convert.ToDecimal(dr2000["KLIMK"].ToString());
                        srcFinAccountModel.Sauft2000 = Convert.ToDecimal(dr2000["SAUFT"].ToString());
                        srcFinAccountModel.Skfor2000 = Convert.ToDecimal(dr2000["SKFOR"].ToString());
                        srcFinAccountModel.Ctlpc2000 = dr2000["CTLPC"].ToString();
                        srcFinAccountModel.Ssobl2000 = Convert.ToDecimal(dr2000["SSOBL"].ToString());
                        srcFinAccountModel.Oblig2000 = Convert.ToDecimal(dr2000["OBLIG"].ToString());
                        srcFinAccountModel.Klprz2000 = Convert.ToDecimal(dr2000["KLPRZ"].ToString());
                        srcFinAccountModel.AmountH2000 = Convert.ToDecimal(dr2000["AMOUNT_H"].ToString());
                        srcFinAccountModel.Zterm2000 = dr2000["ZTERM"].ToString();
                        srcFinAccountModel.Vtext2000 = dr2000["VTEXT"].ToString();
                        srcFinAccountModel.Dmbtr2000 = Convert.ToDecimal(dr2000["DMBTR"].ToString());
                        srcFinAccountModel.Dmbtr72000 = Convert.ToDecimal(dr2000["DMBTR_7"].ToString());
                        srcFinAccountModel.Dmbtr152000 = Convert.ToDecimal(dr2000["DMBTR_15"].ToString());
                        srcFinAccountModel.DmbtrNpd2000 = Convert.ToDecimal(dr2000["DMBTR_NPD"].ToString());
                        srcFinAccountModel.ClzYd2000 = Convert.ToDecimal(dr2000["CLZ_YD"].ToString());
                        srcFinAccountModel.DclFyd2000 = Convert.ToDecimal(dr2000["DCL_FYD"].ToString());
                        srcFinAccountModel.ZRSV01 = dr2000["ZRSV01"].ToString();
                        srcFinAccountModel.ZRSV02 = dr2000["ZRSV02"].ToString();
                        #endregion NEWCODE
                    }

                    #endregion 2000

                    //处理账期部分

                    #region 2500

                    DataRow[] drs2500 = dt.Select("KKBER='2500'");
                    if (drs2500 != null && drs2500.Length > 0)
                    {
                        #region 账期部分

                        DataRow dr2500 = drs2500[0];
                        srcFinAccountModel.Klimk2500 = Convert.ToDecimal(dr2500["KLIMK"].ToString());
                        srcFinAccountModel.Sauft2500 = Convert.ToDecimal(dr2500["SAUFT"].ToString());
                        srcFinAccountModel.Skfor2500 = Convert.ToDecimal(dr2500["SKFOR"].ToString());
                        srcFinAccountModel.Ctlpc2500 = dr2500["CTLPC"].ToString();
                        srcFinAccountModel.Ssobl2500 = Convert.ToDecimal(dr2500["SSOBL"].ToString());
                        srcFinAccountModel.Oblig2500 = Convert.ToDecimal(dr2500["OBLIG"].ToString());
                        srcFinAccountModel.Klprz2500 = Convert.ToDecimal(dr2500["KLPRZ"].ToString());
                        srcFinAccountModel.AmountH2500 = Convert.ToDecimal(dr2500["AMOUNT_H"].ToString());
                        srcFinAccountModel.Zterm2500 = dr2500["ZTERM"].ToString();
                        srcFinAccountModel.Vtext2500 = dr2500["VTEXT"].ToString();
                        srcFinAccountModel.Dmbtr2500 = Convert.ToDecimal(dr2500["DMBTR"].ToString());
                        srcFinAccountModel.Dmbtr72500 = Convert.ToDecimal(dr2500["DMBTR_7"].ToString());
                        srcFinAccountModel.Dmbtr152500 = Convert.ToDecimal(dr2500["DMBTR_15"].ToString());
                        srcFinAccountModel.DmbtrNpd2500 = Convert.ToDecimal(dr2500["DMBTR_NPD"].ToString());
                        srcFinAccountModel.ClzYd2500 = Convert.ToDecimal(dr2500["CLZ_YD"].ToString());
                        srcFinAccountModel.DclFyd2500 = Convert.ToDecimal(dr2500["DCL_FYD"].ToString());

                        #endregion 账期部分
                    }

                    #endregion 2500
                }
                else
                {
                    if (enterpriseCode.ToUpper().IndexOf("A000") == -1)
                    {
                        SysEmailEntity mailEntity = new SysEmailEntity
                        {
                            EMAIL_ID = Guid.NewGuid().ToString(),
                            EMAIL_KEYCODE = "",
                            EMAIL_TITLE = "获取客户信贷数据错误，客编：" + enterpriseCode,
                            EMAIL_TOUSER = "shengwu.he@qx.com",
                            EMAIL_CCUSER = "",
                            EMAIL_CONTENT = "错误:SAP返回null",
                            ATTACHMENTS_PATH = "",
                            EMAIL_DATE = DateTime.Now,
                            EMAIL_SENDER = "",
                            SEND_TIMES = 0,
                            SEND_STATUS = 0,
                            REMARK = "",
                            LAST_MODIFIED_BY = "DDP",
                            LAST_MODIFIED_TIME = DateTime.Now
                        };
                        DataAccess.Insert(mailEntity);

                        return false;
                    }
                }
                ////特殊处理
                //if (srcFinAccountModel.AvailableBalance > 0)
                //{
                //    srcFinAccountModel.Oblig2500 = srcFinAccountModel.AvailableBalance;
                //    srcFinAccountModel.Skfor2500 = 0;
                //    srcFinAccountModel.Ssobl2500 = srcFinAccountModel.AvailableBalance * -1;
                //}
                //if (srcFinAccountModel.Oblig2000 < 0)
                //    srcFinAccountModel.Oblig2000 = 0;
                if (!string.IsNullOrEmpty(creditScope) && creditScope.Equals("2500"))
                {
                    srcFinAccountModel.AvailableBalance = (srcFinAccountModel.Oblig2500 ?? 0) * -1;
                }
                pay.SaveSrcFinAccount(new Comix.Pay.SDK.Models.RequestHeader(), srcFinAccountModel);
                //DataAccess.Delete(lockEntity);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + ex.StackTrace;
                //DataAccess.Delete(lockEntity);
                SysEmailEntity mailEntity = new SysEmailEntity
                {
                    EMAIL_ID = Guid.NewGuid().ToString(),
                    EMAIL_KEYCODE = "",
                    EMAIL_TITLE = "实时获取信控数据异常",
                    EMAIL_TOUSER = "jungui.sun@qx.com",
                    EMAIL_CCUSER = "shengwu.he@qx.com",
                    EMAIL_CONTENT = "错误:" + errorMessage,
                    ATTACHMENTS_PATH = "",
                    EMAIL_DATE = DateTime.Now,
                    EMAIL_SENDER = "",
                    SEND_TIMES = 0,
                    SEND_STATUS = 0,
                    REMARK = "",
                    LAST_MODIFIED_BY = "DDP",
                    LAST_MODIFIED_TIME = DateTime.Now
                };
                DataAccess.Insert(mailEntity);
                return false;
            }
        }
    }
}