namespace Comix.OMS.SDK.Models;

public class OMSUser
{
    /// <summary>
    ///UserID
    /// </summary>

    public virtual int UserID { get; set; }

    /// <summary>
    ///CompanyID
    /// </summary>

    public virtual string CompanyID { get; set; }

    /// <summary>
    ///UserCode
    /// </summary>

    public virtual string UserCode { get; set; }

    /// <summary>
    ///UserName
    /// </summary>

    public virtual string UserName { get; set; }

    /// <summary>
    ///Password
    /// </summary>

    public virtual string Password { get; set; }

    /// <summary>
    ///Disabled
    /// </summary>

    public virtual bool Disabled { get; set; }

}