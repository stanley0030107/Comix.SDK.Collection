using Comix.BMS.SDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.BMS.SDK
{
    public class BMSExtension
    {
        public static void AddService(string url,string token)
        {
            BmsSdkOptions.Url = url;
            BmsSdkOptions.Authorization = token;
        }
    }
}
