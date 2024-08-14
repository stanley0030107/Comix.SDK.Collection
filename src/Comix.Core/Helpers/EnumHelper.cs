namespace Comix.Core.Helpers;

public static class EnumHelper
{
    private static Dictionary<System.Enum, string> dic = new();
    private static object o = new object();
    
    public static string GetDescription(this System.Enum value)
    {
        if (dic.Keys.Any(o => Equals(o, value)))
        {
            return dic[value];
        }
        
        var fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo == null)
        {
            lock (o)
            {
                dic.Add(value, value.ToString());
            }

            return value.ToString();
        }

        if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes 
            && attributes.Length > 0)
        {
            lock (o)
            {
                dic.TryAdd(value, attributes[0].Description);
            }
            return attributes[0].Description;
        }

        return value.ToString();
    }
}