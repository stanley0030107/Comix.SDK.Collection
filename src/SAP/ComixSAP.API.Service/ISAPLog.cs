
namespace ComixSAP.API.Service
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public interface ISAPLog
    {
        /// <summary>
        /// 创建日志
        /// </summary>
        /// <typeparam name="T">日志对象</typeparam>
        /// <param name="systemCode">系统编号</param>
        /// <param name="urlCategoryName">接口参数名</param>
        /// <param name="callingJson">请求实体</param>
        /// <param name="emailTitle">标题</param>
        /// <returns></returns>
        SysLogServiceEntity CreateLog(string systemCode,string urlCategoryName,string callingJson, string emailTitle);

        /// <summary>
        /// 插入日志
        /// </summary>
        /// <typeparam name="T">日志泛型</typeparam>
        /// <param name="logEntity">实体对象</param>
        /// <param name="retCode">Y表示成功 N失败</param>
        /// <param name="rtnMessage">消息日志</param>
        /// <param name="errorCode">错误编码</param>
        /// <param name="responseJson">请求返回报文</param>
        /// <param name="exStackTrace">异常信息</param>
        /// <param name="emailTitle">邮件标题</param>
        /// <returns></returns>
        bool InsertLog(SysLogServiceEntity logEntity,string retCode,string rtnMessage, string errorCode,string responseJson,string exStackTrace,string emailTitle);
            
    }
}
