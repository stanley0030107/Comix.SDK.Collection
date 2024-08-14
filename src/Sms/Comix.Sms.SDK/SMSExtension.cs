using Comix.Sms.SDK.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Sms.SDK
{
    public class SMSExtension
    {
        public static void AddService(string url)
        {
            SMSOptions.Url = url;
        }
    }
}
