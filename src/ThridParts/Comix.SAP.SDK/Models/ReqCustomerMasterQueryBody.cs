using Furion.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.SAP.SDK.Models;

public class ReqCustomerMasterQueryBody
{
    public List<ReqCustomerMasterQueryBody_NAME1> NAME1 { get; set; }
}
public class ReqCustomerMasterQueryBody_NAME1
{
    /// <summary>
    /// 条件类型：I(包含) E(排除)
    /// </summary>
    public string SIGN { get; set; }
    /// <summary> 
    /// 运算符 单值(low)：
    /// EQ 等于 
    /// NE 不等于 范围(low high)：
    /// BT 范围内, NB范围外
    /// </summary>
    public string OPTION { get; set; }
    /// <summary>
    /// 客户名称
    /// 范围中的下限值，如果是单值，low就为单值的值
    /// </summary>
    public string LOW { get; set; }
}



