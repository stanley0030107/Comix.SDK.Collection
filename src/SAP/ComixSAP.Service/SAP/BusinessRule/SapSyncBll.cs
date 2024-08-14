using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace ComixSAP.Service
{
    public class SAPSyncBLL
    {

        private static SAPSyncBLL _instance;
        public static SAPSyncBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SAPSyncBLL();
                }
                return _instance;
            }
        }

        #region 构造函数
        private SAPSyncBLL()
        {

        }

        private SAPSyncBLL(string functionName)
        {

        }
        #endregion

        //public static List<SapSyncModel> SapSyncModelList
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 获取sap数据
        /// </summary>
        /// <param name="functionName">方法名称</param>
        /// <param name="paramtValues">参数列表</param>
        /// <returns></returns>
        public Dictionary<string, string> GetSapDataDictionary(string functionName, List<string> paramtValues)
        {
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                SapSyncModel syncmodel = LoadSyncFunction(functionName);
                if (syncmodel != null)
                {
                    string[] paramStrs = new string[0];
                    if (syncmodel.paramStr != "" && syncmodel.paramStr != null)
                    {
                        // 参数赋值
                        paramStrs = syncmodel.paramStr.Split(',');
                        for (int i = 0; i < paramStrs.Length; i++)
                        {
                            if (paramtValues.Count > i)
                                paramStrs[i] = string.Format(paramStrs[i], paramtValues[i]);
                            else
                                paramStrs[i] = string.Format(paramStrs[i], "");
                        }
                    }
                    dic = SAPHelper.GetSapDataDictionary(paramStrs, syncmodel.rfcFunName);
                }
                return dic;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// 获取sap数据
        /// </summary>
        /// <param name="functionName">方法名称</param>
        /// <param name="paramtValues">参数列表</param>
        /// <returns></returns>
        public DataTable GetSAPDataByNfc(string functionName, List<string> paramtValues)
        {
            try
            {
                DataTable dtSAPData = null;
                SapSyncModel syncmodel = LoadSyncFunction(functionName);
                if (syncmodel != null)
                {
                    string[] paramStrs = new string[0];
                    if (syncmodel.paramStr != "" && syncmodel.paramStr != null)
                    {
                        // 参数赋值
                        paramStrs = syncmodel.paramStr.Split(',');
                        for (int i = 0; i < paramStrs.Length; i++)
                        {
                            if (paramtValues.Count > i)
                                paramStrs[i] = string.Format(paramStrs[i], paramtValues[i]);
                            else
                                paramStrs[i] = string.Format(paramStrs[i], "");
                        }
                    }
                    dtSAPData = SAPHelper.GetSapData(paramStrs, syncmodel.rfcFunName, syncmodel.rfcTables.First());
                }
                return dtSAPData;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public DataTable GetSAPDataByNfc2(string functionName, List<string> paramtValues, DataTable dtInput)
        {
            try
            {
                DataTable dtSAPData = null;
                SapSync2Model syncmodel = LoadSyncFunction2(functionName);
                if (syncmodel != null)
                {
                    string[] paramStrs = new string[0];
                    if (syncmodel.paramStr != "" && syncmodel.paramStr != null)
                    {
                        // 参数赋值
                        paramStrs = syncmodel.paramStr.Split(',');
                        for (int i = 0; i < paramStrs.Length; i++)
                        {
                            if (paramtValues.Count > i)
                                paramStrs[i] = string.Format(paramStrs[i], paramtValues[i]);
                            else
                                paramStrs[i] = string.Format(paramStrs[i], "");
                        }
                    }
                    dtSAPData = SAPHelper.GetSapData2(paramStrs, syncmodel.rfcFunName, syncmodel.rfcTables.First(), syncmodel.rfcINTable, dtInput);
                }
                return dtSAPData;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// 获取sap数据列表
        /// </summary>
        /// <param name="functionName">方法名称</param>
        /// <param name="paramtValues">参数列表</param>
        /// <returns></returns>
        public Dictionary<string, DataTable> GetSAPListByNfc(string functionName, List<string> paramtValues)
        {
            try
            {
                Dictionary<string, DataTable> dictionary = null;
                SapSyncModel syncmodel = LoadSyncFunction(functionName);
                if (syncmodel != null)
                {
                    string[] paramStrs = new string[0];
                    if (syncmodel.paramStr != "" && syncmodel.paramStr != null)
                    {
                        // 参数赋值
                        paramStrs = syncmodel.paramStr.Split(',');
                        for (int i = 0; i < paramStrs.Length; i++)
                        {
                            if (paramtValues.Count > i)
                                paramStrs[i] = string.Format(paramStrs[i], paramtValues[i]);
                            else
                                paramStrs[i] = string.Format(paramStrs[i], "");
                        }
                    }
                    dictionary = SAPHelper.GetSAPTableList(paramStrs, syncmodel.rfcFunName, syncmodel.rfcTables);
                }
                return dictionary;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// 获取同步方法配置参数
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        private List<SapSyncModel> LoadSyncFunction()
        {
            try
            {
                List<SapSyncModel> list = new List<SapSyncModel>();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("SyncConfig.xml");
                XmlNode root = xmlDoc.SelectSingleNode("SAPSyncList");
                foreach (XmlNode node in root.ChildNodes)
                {
                    SapSyncModel model = new SapSyncModel();
                    model.Name = node.Attributes["name"].Value.ToString();
                    model.paramStr = node.Attributes["paramStr"].Value;
                    model.rfcFunName = node.ChildNodes[0].InnerText;
                    List<string> ss = node.ChildNodes[1].InnerText.Split(',').ToList();
                    model.rfcTables = new HashSet<string>(ss);
                    //
                    list.Add(model);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取同步方法配置参数
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        private SapSyncModel LoadSyncFunction(string functionName)
        {
            try
            {
                string sapConfigFile = AppDomain.CurrentDomain.BaseDirectory + "SapSyncConfig.xml";
                List<SapSyncModel> list = new List<SapSyncModel>();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(sapConfigFile);
                XmlNode root = xmlDoc.SelectSingleNode("SAPSyncList");
                //
                XmlNode node = root.SelectNodes("//function[@name='" + functionName + "']")[0];
                SapSyncModel model = new SapSyncModel();
                model.Name = node.Attributes["name"].Value.ToString();
                model.paramStr = node.Attributes["paramStr"].Value;
                model.rfcFunName = node.ChildNodes[0].InnerText;
                List<string> ss = node.ChildNodes[1].InnerText.Split(',').ToList();
                model.rfcTables = new HashSet<string>(ss);
                //
                list.Add(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        private SapSync2Model LoadSyncFunction2(string functionName)
        {
            try
            {
                string sapConfigFile = AppDomain.CurrentDomain.BaseDirectory + "SapSyncConfig2.xml";
                List<SapSync2Model> list = new List<SapSync2Model>();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(sapConfigFile);
                XmlNode root = xmlDoc.SelectSingleNode("SAPSyncList");
                //
                XmlNode node = root.SelectNodes("//function[@name='" + functionName + "']")[0];
                SapSync2Model model = new SapSync2Model();
                model.Name = node.Attributes["name"].Value.ToString();
                model.paramStr = node.Attributes["paramStr"].Value;
                model.rfcFunName = node.ChildNodes[0].InnerText;
                List<string> ss = node.ChildNodes[1].InnerText.Split(',').ToList();
                model.rfcTables = new HashSet<string>(ss);
                model.rfcINTable = node.ChildNodes[2].InnerText;
                //
                list.Add(model);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
    }
}
