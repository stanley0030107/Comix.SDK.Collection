using System.Threading.Tasks;

namespace Comix.Qx.Infrastructure.Interfaces
{
    public interface IQxService
    {
        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<T> ExecuteAsync<T>(string path, object req);

        /// <summary>
        /// 执行post请求
        /// </summary>
        /// <param name="path"></param>
        /// <param name="req"></param>
        /// <returns>Response Content.ReadAsString</returns>
        /// <exception cref="Exception"></exception>
        Task<string> ExecuteReturnStringAsync(string path, object req);
    }
}