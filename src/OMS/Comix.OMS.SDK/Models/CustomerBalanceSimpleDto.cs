namespace Comix.OMS.SDK.Models;

/// <summary>
/// 客户余额简单dto
/// </summary>
public class CustomerBalanceSimpleDto
{
    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public string? CustCode { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    public decimal? Amount { get; set; }
}