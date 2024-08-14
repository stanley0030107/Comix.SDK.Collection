using Comix.Qx.Infrastructure.Models;

namespace Comix.Qx.Infrastructure
{
    public class QxExtension
    {
        public static void AddQxService(string url)
        {
            QxOptions.Url = url;
        }
    }
}

