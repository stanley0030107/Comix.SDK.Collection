using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace ComixSAP.Common.SAP
{
    public static class SapCommonMethod
    {
        public static T ChangeType<T>(object value)
        {
            object obj2;
            if ((value != DBNull.Value) && (value != null))
            {
                if (value is T)
                {
                    return (T) value;
                }
                return (T) Convert.ChangeType(value, typeof(T));
            }
            switch (Type.GetTypeCode(Type.GetType(typeof(T).Name)))
            {
                case TypeCode.Boolean:
                    obj2 = false;
                    break;

                case TypeCode.Char:
                case TypeCode.String:
                    obj2 = "";
                    break;

                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    obj2 = 0;
                    break;

                case TypeCode.DateTime:
                    obj2 = new DateTime(0x76c, 1, 1);
                    break;

                default:
                    obj2 = 0.0;
                    break;
            }
            return (T) Convert.ChangeType(obj2, typeof(T));
        }

        public static string ConvertNull(this object value)
        {
            if (value == null)
            {
                value = "";
            }
            return value.ToString();
        }

        public static DataTable ConvertToDataTable<T>(this List<T> list) where T: SapModelBase, new()
        {
            T local = Activator.CreateInstance<T>();
            int count = local.PropertyNames.Count;
            DataTable table = new DataTable();
            for (int i = 0; i < count; i++)
            {
                table.Columns.Add(local.PropertyNames[i]);
            }
            foreach (T local2 in list)
            {
                object[] values = new object[count];
                for (int j = 0; j < count; j++)
                {
                    values[j] = local2.PropertyValues[j].ConvertNull();
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static List<T> ConvertToList<T>(this DataTable dt) where T: SapModelBase, new()
        {
            List<T> list = new List<T>();
            if (dt.Rows.Count > 0)
            {
                using (DataTableReader reader = dt.CreateDataReader())
                {
                    if (!reader.HasRows)
                    {
                        return list;
                    }
                    int fieldCount = reader.FieldCount;
                    while (reader.Read())
                    {
                        T item = Activator.CreateInstance<T>();
                        for (int i = 0; i < fieldCount; i++)
                        {
                            item.SetProperty(dt.Columns[i].ColumnName, reader[i]);
                        }
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        private static Type FindIEnumerable(Type type)
        {
            if ((type != null) && (type != typeof(string)))
            {
                if (type.IsArray)
                {
                    return typeof(IEnumerable<>).MakeGenericType(new Type[] { type.GetElementType() });
                }
                if (type.IsGenericType)
                {
                    foreach (Type type2 in type.GetGenericArguments())
                    {
                        Type type3 = typeof(IEnumerable<>).MakeGenericType(new Type[] { type2 });
                        if (type3.IsAssignableFrom(type))
                        {
                            return type3;
                        }
                    }
                }
                Type[] interfaces = type.GetInterfaces();
                if ((interfaces != null) && interfaces.Any<Type>())
                {
                    foreach (Type type4 in interfaces)
                    {
                        Type type5 = FindIEnumerable(type4);
                        if (type5 != null)
                        {
                            return type5;
                        }
                    }
                }
                if ((type.BaseType != null) && (type.BaseType != typeof(object)))
                {
                    return FindIEnumerable(type.BaseType);
                }
            }
            return null;
        }

        public static Type GetElementType(Type type)
        {
            Type type2 = FindIEnumerable(type);
            if (type2 == null)
            {
                return type;
            }
            return type2.GetGenericArguments()[0];
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            string name = "";
            if (expr.Body is UnaryExpression)
            {
                return ((MemberExpression) ((UnaryExpression) expr.Body).Operand).Member.Name;
            }
            if (expr.Body is MemberExpression)
            {
                return ((MemberExpression) expr.Body).Member.Name;
            }
            if (expr.Body is ParameterExpression)
            {
                name = ((ParameterExpression) expr.Body).Type.Name;
            }
            return name;
        }
    }
}

