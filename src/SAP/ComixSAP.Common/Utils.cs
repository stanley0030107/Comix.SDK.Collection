using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Collections;

namespace ComixSAP.Common
{
    //public class MyResourceExpressionBuilder : System.Web.Compilation.ExpressionBuilder
    //{
    //    public override System.CodeDom.CodeExpression GetCodeExpression(System.Web.UI.BoundPropertyEntry entry, object parsedData, System.Web.Compilation.ExpressionBuilderContext context)
    //    {
    //        return new System.CodeDom.CodePrimitiveExpression(Ferrero.Common.Resource.VSASYSResource.ResourceManager.GetString(entry.Expression));
    //    }
    //}


    public static class Utils
    {
        public static DataTable ToDataTable(this IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        public static string ForSQL(this string str)
        {
            return Utils.ToSQLStr(str);
        }

        public static decimal ToDecimal(string str)
        {
            decimal result = 0;
            if (decimal.TryParse(str, out result))
            {
                return result;
            }
            return 0;
        }

        public static int ToInt(string str)
        {
            int result = 0;
            if (int.TryParse(str, out result))
            {
                return result;
            }
            return 0;
        }

        public static double ToDouble(string str)
        {
            double result = 0;
            if (double.TryParse(str, out result))
            {
                return result;
            }
            return 0;
        }

        public static string ToSQLStr(string str)
        {
            return str.Replace("'", "''");
        }

        public static string ToInString(string str)
        {
            string[] strorgs = str.Split(',');
            StringBuilder strBuilder = new StringBuilder("(");
            foreach (string strorg in strorgs)
            {
                if (!string.IsNullOrEmpty(strorg))
                    strBuilder.Append("'" + strorg + "',");
            }
            strBuilder.Append(")");

            string strReturn = strBuilder.ToString().Replace(",)", ")");
            if (strReturn.Equals("()"))
                return "";
            else
                return strReturn;
        }
        /// <summary>
        /// 组合查询条件
        /// </summary>
        public class QueryCondition
        {
            public static QueryCondition Create()
            {
                return new QueryCondition();
            }

            public override string ToString()
            {
                return ConditionSQL;
            }

            protected string ConditionSQL { get; set; }

            /// <summary>
            /// 是否有Where条件
            /// </summary>
            public bool ExistWhereString { get; protected set; }

            /// <summary>
            /// 是否有Order条件
            /// </summary>
            public bool ExistOrderString { get; protected set; }

            public QueryCondition()
            {
                ConditionSQL = string.Empty;
                ExistOrderString = false;
                ExistWhereString = false;
            }

            string FormatString(string value)
            {
                return value.Replace("'", "''");
            }

            void CheckWhereStart()
            {
                if (ExistWhereString)
                {
                    this.ConditionSQL += " and ";
                }
            }

            void CheckWhereStartOr()
            {
                if (ExistWhereString)
                {
                    this.ConditionSQL += " or ";
                }
            }

            void CheckWhereStartAnd()
            {
                if (ExistWhereString)
                {
                    this.ConditionSQL += " and ( ";
                }
            }


            public QueryCondition AndLike(string property, string value)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CheckWhereStartAnd();
                    this.ConditionSQL += " " + property + " like '%" + FormatString(value.ToUpper().Trim()) + "%'";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition OrLike(string property, string value)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CheckWhereStartOr();
                    this.ConditionSQL += " " + property + " like '%" + FormatString(value.ToUpper().Trim()) + "%'";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition Like(string property, string value)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CheckWhereStart();
                    this.ConditionSQL += " " + property + " like '%" + FormatString(value.ToUpper().Trim()) + "%'";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition Or(string property, string value)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    CheckWhereStartOr();
                    this.ConditionSQL += " " + property + "= '" + FormatString(value.ToUpper().Trim()) + "'";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition Equals(string property, object value)
            {
                if (value != null)
                {
                    CheckWhereStart();
                    if (value.GetType().IsValueType)
                    {
                        this.ConditionSQL += property + "=" + value;
                    }
                    else
                    {
                        this.ConditionSQL += " " + property + "='" + FormatString(value.ToString().ToUpper().Trim()) + "'";
                    }
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition NotEquals(string property, object value)
            {
                if (value != null)
                {
                    CheckWhereStart();
                    if (value.GetType().IsValueType)
                    {
                        this.ConditionSQL += property + "<>" + value;
                    }
                    else
                    {
                        this.ConditionSQL += " " + property + "<>'" + FormatString(value.ToString().ToUpper().Trim()) + "'";
                    }
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition EqualsNull(string property)
            {

                CheckWhereStart();
                this.ConditionSQL += " (" + property + " is null or " + property + "='' ) ";
                ExistWhereString = true;
                return this;
            }

            public QueryCondition In(string property, params string[] values)
            {
                if (values.Length > 0)
                {
                    CheckWhereStart();
                    string[] vs = new string[values.Length];
                    for (int i = 0; i < values.Length; i++)
                    {
                        vs[i] = FormatString(values[i].ToString().Trim());
                    }
                    this.ConditionSQL += " " + property + " in ('" + string.Join("','", vs).ToUpper() + "')";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition In(string property, params decimal[] values)
            {
                if (values.Length > 0)
                {
                    CheckWhereStart();
                    string[] vs = new string[values.Length];
                    for (int i = 0; i < values.Length; i++)
                    {
                        vs[i] = values[i].ToString();
                    }
                    this.ConditionSQL += property + " in (" + string.Join(",", vs) + ")";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition Between(string property, string from, string to)
            {
                if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                {
                    CheckWhereStart();
                    this.ConditionSQL += property + " between '" + FormatString(from.Trim()) + "' and '" + FormatString(to.Trim()) + "'";
                    ExistWhereString = true;
                }
                return this;
            }

            public QueryCondition Less(string property, object value)
            {
                if (value != null)
                {
                    CheckWhereStart();
                    if (value.GetType().IsValueType)
                    {
                        this.ConditionSQL += property + "<" + value;
                    }
                    else
                    {
                        this.ConditionSQL += " " + property + "<" + FormatString(value.ToString().ToUpper().Trim()) + "'";
                    }
                    ExistWhereString = true;
                }
                return this;
            }
            #region Order
            public QueryCondition Order(params string[] property)
            {
                foreach (string p in property)
                {
                    this.Order(p);
                }
                return this;
            }

            public QueryCondition Order(string property)
            {
                return Order(property, false);
            }

            public QueryCondition Order(string property, bool desc)
            {
                if (!string.IsNullOrEmpty(property))
                {
                    if (!ExistOrderString)
                    {
                        this.ConditionSQL += " ORDER BY " + property;
                        ExistOrderString = true;
                    }
                    else
                    {
                        this.ConditionSQL += "," + property;
                    }
                    if (desc)
                    {
                        this.ConditionSQL += " DESC ";
                    }
                }
                return this;
            }
            #endregion


        }
        /// <summary>
        /// MD5散列值
        /// </summary>
        public static string MD5Encode(string str)
        {
            byte[] byteInput = UTF8Encoding.UTF8.GetBytes(str);
            MD5CryptoServiceProvider objMd5 = new MD5CryptoServiceProvider();
            byte[] byteOutput = objMd5.ComputeHash(byteInput);
            return BitConverter.ToString(byteOutput).Replace("-", "");
        }

        /// <summary>
        /// xml序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            try
            {
                Type type = obj.GetType();
                XmlSerializer sz = new XmlSerializer(type);
                sz.Serialize(sw, obj);
            }
            finally
            {
                sw.Close();
            }
            return sb.ToString();
        }

        /// <summary>
        /// xml序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void Serialize(object obj, string filePath)
        {
            Stream sw = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                Type type = obj.GetType();
                XmlSerializer sz = new XmlSerializer(type);
                sz.Serialize(sw, obj);
            }
            finally
            {
                sw.Close();
            }
        }

        /// <summary>
        /// xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(fs);
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// 获得季度BPM编码
        /// </summary>
        /// <returns></returns>
        public static string GetBPM(DateTime dt)
        {
            string bpmString = string.Empty;
            switch (dt.Month)
            {
                case 1:
                    bpmString = "NDJF";
                    break;
                case 2:
                    bpmString = "NDJF";
                    break;
                case 3:
                    bpmString = "MAMJ";
                    break;
                case 4:
                    bpmString = "MAMJ";
                    break;
                case 5:
                    bpmString = "MAMJ";
                    break;
                case 6:
                    bpmString = "MAMJ";
                    break;
                case 7:
                    bpmString = "JASO";
                    break;
                case 8:
                    bpmString = "JASO";
                    break;
                case 9:
                    bpmString = "JASO";
                    break;
                case 10:
                    bpmString = "JASO";
                    break;
                case 11:
                    bpmString = "NDJF";
                    break;
                case 12:
                    bpmString = "NDJF";
                    break;

            }
            return bpmString;
        }

        /// <summary>
        /// 获得财年FM编码
        /// </summary>
        /// <returns></returns>
        public static string GetFYBySeparator(DateTime dt)
        {
            string fmString = string.Empty;
            if (dt >= (new DateTime(dt.Year, 7, 1)))
            {
                fmString = dt.AddYears(0).Year.ToString().Substring(2, 2) + "/" + dt.AddYears(1).Year.ToString().Substring(2, 2);
            }
            else
            {
                if (dt > DateTime.MinValue.AddYears(1))
                {
                    fmString = dt.AddYears(-1).Year.ToString().Substring(2, 2) + "/" + dt.AddYears(0).Year.ToString().Substring(2, 2);
                }
            }
            return fmString;
        }

        /// <summary>
        /// 获得财年FY编码
        /// </summary>
        /// <returns></returns>
        public static string GetFY(DateTime dt)
        {
            string fmString = string.Empty;
            if (dt >= (new DateTime(dt.Year, 7, 1)))
            {
                fmString = dt.AddYears(0).Year.ToString().Substring(2, 2) + dt.AddYears(1).Year.ToString().Substring(2, 2);
            }
            else
            {
                if (dt > DateTime.MinValue.AddYears(1))
                {
                    fmString = dt.AddYears(-1).Year.ToString().Substring(2, 2) + dt.AddYears(0).Year.ToString().Substring(2, 2);
                }
            }
            return fmString;
        }

        /// <summary>
        /// 从枚举中读取特性与值集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>特性与值集合。若无特性，则默认枚举名称</returns>
        public static NameValueCollection GetNameValueFromEnum(Type enumType)
        {
            string name = string.Empty;
            string value = string.Empty;
            NameValueCollection coll = new NameValueCollection();
            FieldInfo[] fields = enumType.GetFields();
            Type typeDescription = typeof(DescriptionAttribute);

            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    value = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute des = arr[0] as DescriptionAttribute;
                        name = des.Description;
                    }
                    else
                    {
                        name = field.Name;
                    }

                    coll.Add(name, value);
                }
            }

            return coll;
        }

        public static bool IsMaxDateTime(string strDatetime)
        {
            if (Convert.ToDateTime(strDatetime).ToString("yyyy-MM-dd") == "9999-12-31")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsMaxDateTime(DateTime strDatetime)
        {
            if (strDatetime.ToString("yyyy-MM-dd") == "9999-12-31")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string DateToHHMM(string strDate)
        {
            try
            {
               return  Convert.ToDateTime(strDate).ToString("yyyy-MM-dd HH:mm");
            }
            catch {
                return "";
            }
        }
        public static string DateToHHMM(DateTime dtDate)
        {
            return dtDate.ToString("yyyy-MM-dd HH:mm");
        }

        public static decimal ChinaRound(decimal value, int decimals)
        {
            if (value < 0)
            {
                return Math.Round(value + 5 / Convert.ToDecimal(Math.Pow(10, decimals + 1)), decimals, MidpointRounding.AwayFromZero);
            }
            else
            {
                return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
            }
        } 
    }
}
