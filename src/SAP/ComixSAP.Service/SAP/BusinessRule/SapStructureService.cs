using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ComixSAP.Common.SAP;
using ComixSAP.Common.Entity;
using Furion.JsonSerialization;
using Newtonsoft.Json.Linq;

namespace ComixSAP.Service
{
    public class SapStructureService<T> where T : SapEntityBase, new()
    {
        public static DataTable ConvertToTable(IRfcTable rfcTable)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < rfcTable.ElementCount; i++)
            {
                string name = rfcTable.GetElementMetadata(i).Name;
                table.Columns.Add(name);
            }
            for (int j = 0; j < rfcTable.RowCount; j++)
            {
                object[] values = new object[rfcTable.ElementCount];
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    values[k] = rfcTable[j][table.Columns[k].ColumnName].GetValue();
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static void GetSAPRFCEntity(T entity)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(ConfigurationEntity.DestinationType);
            RfcRepository saprfcepository = destination.Repository;
            if (string.IsNullOrEmpty(entity.FuncName))
            {
                throw new Exception("SAP RFC function name is null");
            }
            IRfcFunction function = SapStructureService<T>.SetSAPRFCParameters(entity, saprfcepository);
            function.Invoke(destination);
            IEnumerable<KeyValuePair<string, RFCParamater>> source = entity.PropertyNames.Where<KeyValuePair<string, RFCParamater>>(delegate(KeyValuePair<string, RFCParamater> s)
            {
                if (s.Value.ParaDirection != Direction.OutPut)
                {
                    return s.Value.ParaDirection == Direction.Dual;
                }
                return true;
            });
            if ((source != null) && source.Any<KeyValuePair<string, RFCParamater>>())
            {
                using (IEnumerator<KeyValuePair<string, RFCParamater>> enumerator = source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Func<RFCStructParameter, bool> predicate = null;
                        KeyValuePair<string, RFCParamater> keyvalue = enumerator.Current;
                        if ((from s in entity.RfcTableNames select s.RfcTableName.Trim()).Contains<string>(keyvalue.Key.Trim()))
                        {
                            DataTable table2 = SapStructureService<T>.ConvertToTable(function.GetTable(keyvalue.Key));
                            if (table2.Rows.Count > 0)
                            {
                                string str = JSON.Serialize(table2);                                
                                entity.SetProperty(keyvalue.Key, str);
                            }
                        }
                        else
                        {
                            if ((from s in entity.RfcStructNames select s.RfcStructName.Trim()).Contains<string>(keyvalue.Key.Trim()))
                            {
                                IRfcStructure structure = function.GetStructure(keyvalue.Key.Trim());
                                int elementCount = structure.ElementCount;
                                if (predicate == null)
                                {
                                    predicate = s => s.RfcStructName.Equals(keyvalue.Key, StringComparison.CurrentCultureIgnoreCase);
                                }
                                string name = (from s in entity.RfcStructNames.Where<RFCStructParameter>(predicate) select s.PropertyName).FirstOrDefault<string>();
                                Type elementType = SapCommonMethod.GetElementType(entity.GetType().GetProperty(name).PropertyType);
                                if (elementType.BaseType == typeof(SapModelBase))
                                {
                                    SapModelBase base2 = Activator.CreateInstance(elementType) as SapModelBase;
                                    if (base2 != null)
                                    {
                                        for (int i = 0; i < elementCount; i++)
                                        {
                                            string propertyName = structure.GetElementMetadata(i).Name;
                                            base2.SetProperty(propertyName, structure.GetValue(propertyName).ConvertNull());
                                        }
                                        entity.SetProperty(keyvalue.Key, JSON.Serialize(base2));
                                    }
                                }
                                continue;
                            }
                            entity.SetProperty(keyvalue.Key, function.GetValue(keyvalue.Key));
                        }
                    }
                }
            }
        }

        public static IRfcFunction SetSAPRFCParameters(T entity, RfcRepository saprfcepository)
        {
            IRfcFunction function = saprfcepository.CreateFunction(entity.FuncName);
            IEnumerable<KeyValuePair<string, RFCParamater>> source = entity.PropertyNames.Where<KeyValuePair<string, RFCParamater>>(delegate(KeyValuePair<string, RFCParamater> s)
            {
                if (s.Value.ParaDirection != Direction.InPut)
                {
                    return s.Value.ParaDirection == Direction.Dual;
                }
                return true;
            });
            if ((source != null) && source.Any<KeyValuePair<string, RFCParamater>>())
            {
                using (IEnumerator<KeyValuePair<string, RFCParamater>> enumerator = source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Func<RFCStructParameter, bool> predicate = null;
                        KeyValuePair<string, RFCParamater> keyvalue = enumerator.Current;
                        if ((from s in entity.RfcTableNames select s.RfcTableName).Contains<string>(keyvalue.Key))
                        {
                            DataTable table = JsonToDataTable(entity.PropertyList(keyvalue.Key).ToString().Trim());
                            int count = table.Rows.Count;
                            if (count > 0)
                            {
                                IRfcTable table2 = function.GetTable(keyvalue.Key);
                                table2.Append(count);
                                for (int i = 0; i < count; i++)
                                {
                                    for (int j = 0; j < table2.Metadata.LineType.FieldCount; j++)
                                    {
                                        string column = table2.Metadata.LineType[j].Name;
                                        if (table.Columns.Contains(column))
                                        {
                                            if (string.IsNullOrEmpty(table.Rows[i][column].ToString()))
                                            {
                                                if (table2.Metadata.LineType[j].DataType == RfcDataType.NUM || table2.Metadata.LineType[j].DataType == RfcDataType.BCD)
                                                {
                                                    table2[i].SetValue(column, 0);
                                                }
                                                else
                                                {
                                                    table2[i].SetValue(column, "");
                                                }
                                            }
                                            else
                                            {
                                                table2[i].SetValue(column, table.Rows[i][column].ToString().Trim());
                                            }

                                        }
                                        // rfcs.
                                    }
                                    //foreach (DataColumn column in table.Columns)
                                    //{
                                    //    table2[i].SetValue(column.ColumnName, table.Rows[i][column.ColumnName].ToString().Trim());
                                    //}
                                }
                            }
                        }
                        else
                        {
                            if ((from s in entity.RfcStructNames select s.RfcStructName).Contains<string>(keyvalue.Key))
                            {
                                if (predicate == null)
                                {
                                    predicate = s => s.RfcStructName.Equals(keyvalue.Key, StringComparison.CurrentCultureIgnoreCase);
                                }
                                string name = (from s in entity.RfcStructNames.Where<RFCStructParameter>(predicate) select s.PropertyName).FirstOrDefault<string>();
                                entity.GetType().GetProperty(name);
                                SapModelBase tmp = SapCommonMethod.ChangeType<SapModelBase>(entity.GetType().GetProperty(name).GetValue(entity, null));
                                if (tmp != null)
                                {
                                    IRfcStructure rfcStruct = function.GetStructure(keyvalue.Key);
                                    tmp.PropertyNames.ForEach(delegate(string s)
                                    {
                                        rfcStruct.SetValue(s, tmp.PropertyList(s).ConvertNull());
                                    });
                                }
                                continue;
                            }
                            string str2 = entity.PropertyList(keyvalue.Key).ConvertNull().ToString().Trim();
                            if (!string.IsNullOrEmpty(str2))
                            {
                                function.SetValue(keyvalue.Key, str2);
                            }
                        }
                    }
                }
            }
            return function;
        }

        public static DataTable JsonToDataTable(string json)
        {
            DataTable dataTable = new DataTable();

            // Load JSON data into a JArray (or JObject, depending on your JSON structure)
            JArray jsonArray = JArray.Parse(json);

            // Create columns for the DataTable based on the properties in the JSON data
            if (jsonArray.Count > 0)
            {
                JObject firstItem = jsonArray[0].ToObject<JObject>();
                foreach (var property in firstItem.Properties())
                {
                    dataTable.Columns.Add(new DataColumn(property.Name, typeof(string)));
                }
            }

            // Populate the DataTable with JSON data
            foreach (JObject jsonObj in jsonArray)
            {
                DataRow row = dataTable.NewRow();
                foreach (var property in jsonObj.Properties())
                {
                    row[property.Name] = property.Value.ToString();
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}

