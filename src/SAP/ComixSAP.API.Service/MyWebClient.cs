using System;
using System.Net;
namespace ComixSAP.API.Service
{
    public class MyWebClient : WebClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout">超时时间（单位:秒）</param>
        public MyWebClient(int timeout)
        {
            Timeout = timeout;
        }
        /// <summary>
        /// 超时时间
        /// </summary>
        private int Timeout { get; set; } = 10;

        //重写超时时间
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = 1000 * Timeout;//单位为毫秒
            request.ReadWriteTimeout = 1000 * Timeout;
            return request;
        }

     

    }

}
