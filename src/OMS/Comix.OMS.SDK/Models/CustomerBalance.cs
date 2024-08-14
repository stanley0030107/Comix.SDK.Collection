using Comix.OMS.SDK;
using SqlSugar;
namespace OMSModels
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Customer_Balance")]
    [Tenant(OmsSetup.DbConfigId)]
    public partial class CustomerBalance
    {
           public CustomerBalance(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,IsNullable=false)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(Length = 50,IsNullable=true)]
           public string? CustCode {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(IsNullable=true)]
           public decimal? Amount {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(IsNullable=true)]
           public DateTime? SyncTime {get;set;}

    }
}
