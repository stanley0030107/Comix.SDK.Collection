using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.LinqBuilder;

namespace Comix.Core.Util
{
    public static class StringExtensions
    {
        /// <summary>
        /// Gets the enum valueItem based on the given enum type and display name.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        public static T GetEnumFromValue<T>(this string value) where T : System.Enum
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                return default(T);
            }

            return (T)System.Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// 根据长度分割字符串
        /// </summary>
        /// <param name="str">被分割的字符串</param>
        /// <param name="len">分割长度</param>
        /// <returns></returns>
        public static string SplitByLen(this string? str, int len)
        {
            if (str.IsNullOrEmpty())
            {
                return str;
            }

            if (str.Length < len)
            {
                return str;
            }

            return str.Substring(0, len);
        }

        /// <summary>
        /// 根据长度分割字符串
        /// </summary>
        /// <param name="str">被分割字符串</param>
        /// <param name="len">分割长度</param>
        /// <param name="tail">分割之后的字符串尾部</param>
        /// <returns></returns>
        public static string SplitByLen(this string? str, int len, out string tail)
        {
            var head = SplitByLen(str, len);
            if (head.IsNullOrEmpty())
            {
                tail = str;
                return head;
            }

            tail = str.TrimStart(head.ToCharArray());
            return head;
        }
    }
}
