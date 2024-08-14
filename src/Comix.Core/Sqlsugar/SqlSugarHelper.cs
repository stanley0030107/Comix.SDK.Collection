using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Sqlsugar
{
    public static class SqlSugarHelper
    {
        /// <summary>
        /// 获取属性在db中的字段名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetDbColumnName<T>(this string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                return field;
            }

            var t = typeof(T);
            var memberInfo = t.GetMember(field).FirstOrDefault();
            if (memberInfo == null)
            {
                return field;
            }
            
            var column = memberInfo.GetCustomAttribute<SugarColumn>();
            if (column == null)
            {
                return field;
            }

            if (string.IsNullOrEmpty(column.ColumnName)) {
                return field;
            }

            return column.ColumnName;
        }
    }
}
