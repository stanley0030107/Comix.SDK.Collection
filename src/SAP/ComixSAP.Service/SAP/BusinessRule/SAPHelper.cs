using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComixSAP.Service
{
    public class SAPHelper
    {
        public static string DestinationType
        {
            get
            {
                return Furion.App.Configuration["DestinationType"].ToString().Trim();
            }
        }

        public static void ExecuteRFC(string[] param, string RfcName)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
            IRfcFunction function = destination.Repository.CreateFunction(RfcName);
            foreach (string str in param)
            {
                string[] strArray = str.Split(new char[] { '|' });
                function.SetValue(strArray[0], strArray[1].Trim());
            }
            function.Invoke(destination);
        }

        public static Dictionary<string,string> GetSapDataDictionary(string[] param, string RfcName)
        {
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
                IRfcFunction function = destination.Repository.CreateFunction(RfcName);
                if ((param != null) && (param.Length > 0))
                {
                    foreach (string str in param)
                    {
                        string[] strArray = str.Split(new char[] { '|' });
                        function.SetValue(strArray[0], strArray[1].Trim());
                    }
                }
                function.Invoke(destination);
                for (int i = 0; i < function.ElementCount; i++)
                {
                    string name = function.GetElementMetadata(i).Name;
                    dic.Add(name, function.GetValue(i).ToString());
                }
                return dic;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetSapData(string[] param, string RfcName, string IT_tableName)
        {
            try
            {
                RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
                IRfcFunction function = destination.Repository.CreateFunction(RfcName);
                if ((param != null) && (param.Length > 0))
                {
                    foreach (string str in param)
                    {
                        string[] strArray = str.Split(new char[] { '|' });
                        function.SetValue(strArray[0], strArray[1].Trim());
                    }
                }


                function.Invoke(destination);
                IRfcTable table = function.GetTable(IT_tableName);
                DataTable table2 = new DataTable();
                for (int i = 0; i < table.ElementCount; i++)
                {
                    string name = table.GetElementMetadata(i).Name;
                    table2.Columns.Add(name);
                }
                for (int j = 0; j < table.RowCount; j++)
                {
                    object[] values = new object[table.ElementCount];
                    for (int k = 0; k < table2.Columns.Count; k++)
                    {
                        values[k] = table[j][table2.Columns[k].ColumnName].GetValue();
                    }
                    table2.Rows.Add(values);
                }
                return table2;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }
        public static DataTable GetSapData2(string[] param, string RfcName, string IT_tableName, string InTableName, DataTable dtInput)
        {
            try
            {
                RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
                IRfcFunction function = destination.Repository.CreateFunction(RfcName);
                if ((param != null) && (param.Length > 0))
                {
                    foreach (string str in param)
                    {
                        string[] strArray = str.Split(new char[] { '|' });
                        function.SetValue(strArray[0], strArray[1].Trim());
                    }
                }

                if (dtInput != null && dtInput.Rows.Count > 0)
                {
                    IRfcTable inputTable = function.GetTable(InTableName);

                    foreach (DataRow dr in dtInput.Rows)
                    {
                        inputTable.Insert();
                        foreach (DataColumn item in dtInput.Columns)
                        {
                            inputTable.CurrentRow.SetValue(item.ColumnName, dr[item]);
                        }
                    }
                    function.SetValue(InTableName, inputTable);
                }



                function.Invoke(destination);
                IRfcTable table = function.GetTable(IT_tableName);
                DataTable table2 = new DataTable();
                for (int i = 0; i < table.ElementCount; i++)
                {
                    string name = table.GetElementMetadata(i).Name;
                    table2.Columns.Add(name);
                }
                for (int j = 0; j < table.RowCount; j++)
                {
                    object[] values = new object[table.ElementCount];
                    for (int k = 0; k < table2.Columns.Count; k++)
                    {
                        values[k] = table[j][table2.Columns[k].ColumnName].GetValue();
                    }
                    table2.Rows.Add(values);
                }
                return table2;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public static IRfcTable GetSAPRfcTable(string[] param, string RfcName, string IT_tableName)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
            IRfcFunction function = destination.Repository.CreateFunction(RfcName);
            if ((param != null) && (param.Length > 0))
            {
                foreach (string str in param)
                {
                    string[] strArray = str.Split(new char[] { '|' });
                    function.SetValue(strArray[0], strArray[1].Trim());
                }
            }
            function.Invoke(destination);
            return function.GetTable(IT_tableName);
        }

        public static Dictionary<string, IRfcTable> GetSAPRfcTableList(string[] param, string RfcName, HashSet<string> IT_tableNameList)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
            IRfcFunction function = destination.Repository.CreateFunction(RfcName);
            foreach (string str in param)
            {
                string[] strArray = str.Split(new char[] { '|' });
                function.SetValue(strArray[0], strArray[1].Trim());
            }
            function.Invoke(destination);
            Dictionary<string, IRfcTable> dictionary = new Dictionary<string, IRfcTable>();
            foreach (string str2 in IT_tableNameList)
            {
                IRfcTable table = function.GetTable(str2);
                dictionary.Add(str2, table);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取sap数据集
        /// </summary>
        /// <param name="param"></param>
        /// <param name="RfcName"></param>
        /// <param name="IT_tableNameList"></param>
        /// <returns></returns>
        public static Dictionary<string, DataTable> GetSAPTableList(string[] param, string RfcName, HashSet<string> IT_tableNameList)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
            IRfcFunction function = destination.Repository.CreateFunction(RfcName);
            foreach (string str in param)
            {
                string[] strArray = str.Split(new char[] { '|' });
                function.SetValue(strArray[0], strArray[1].Trim());
            }
            function.Invoke(destination);
            Dictionary<string, DataTable> dictionary = new Dictionary<string, DataTable>();
            foreach (string str2 in IT_tableNameList)
            {
                IRfcTable table = function.GetTable(str2);
                //IRfcTable 转换成基本DataTable
                DataTable table2 = new DataTable();
                for (int i = 0; i < table.ElementCount; i++)
                {
                    string name = table.GetElementMetadata(i).Name;
                    table2.Columns.Add(name);
                }
                for (int j = 0; j < table.RowCount; j++)
                {
                    object[] values = new object[table.ElementCount];
                    for (int k = 0; k < table2.Columns.Count; k++)
                    {
                        values[k] = table[j][table2.Columns[k].ColumnName].GetValue();
                    }
                    table2.Rows.Add(values);
                }
                dictionary.Add(str2, table2);
            }
            return dictionary;
        }

        public static string GetSAPString(string[] param, string RfcName, string OutName)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(DestinationType);
            IRfcFunction function = destination.Repository.CreateFunction(RfcName);
            foreach (string str in param)
            {
                string[] strArray = str.Split(new char[] { '|' });
                function.SetValue(strArray[0], strArray[1].Trim());
            }
            function.Invoke(destination);
            return function.GetString("").ToString();
        }
    }
}

