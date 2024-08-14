
namespace ComixSAP.API.Service
{
    public class PORequestDomain<T>
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        public string SYSID { get; set; }

        /// <summary>
        /// 请求主体
        /// </summary>
        public T REQUEST { get; set; }
    }
}
