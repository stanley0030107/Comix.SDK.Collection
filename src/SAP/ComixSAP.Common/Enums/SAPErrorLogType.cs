using System.ComponentModel;

namespace ComixSAP.Common.Enums;

/// <summary>
/// 消息类型
/// </summary>
public enum SAPErrorLogType
{
    /// <summary>
    /// 成功
    /// </summary>
    [Description("成功")] S = 1,

    /// <summary>
    /// 错误
    /// </summary>
    [Description("错误")] E = 2,

    /// <summary>
    /// 警告
    /// </summary>
    [Description("警告")] W = 3,

    /// <summary>
    /// 信息
    /// </summary>
    [Description("信息")] I = 4,

    /// <summary>
    /// 中断
    /// </summary>
    [Description("中断")] A = 5
}