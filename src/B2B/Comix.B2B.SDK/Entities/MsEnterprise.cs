using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.B2B.SDK.Entities
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Ms_Enterprise")]
    [Tenant(B2bSetup.ConfigId)]
    public partial class MsEnterprise
    {
        public MsEnterprise()
        {

            this.Balance = Convert.ToDecimal("0");
            this.PayConditionCode = Convert.ToString("0001");
            this.PayConditionName = Convert.ToString("立即付款无扣除");
            this.IsCash = false;
            this.EnterpriseType = Convert.ToInt32("0");
            this.SupplierCode = Convert.ToString("1100");
            this.SupplierId = Convert.ToInt32("6");
            this.LimitAmount = Convert.ToDecimal("0");
            this.PricePackageCode = Convert.ToString("");
            this.CreditScope = Convert.ToString("2000");
            this.Type = Convert.ToInt32("0");

        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, IsNullable = false)]
        public int EnterpriseID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true)]
        public string? EnterpriseCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public string? Introduction { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? RegisteredCapital { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? TelPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? CellPhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ContactMail { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? RegionID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true)]
        public string? Address { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 1000, IsNullable = true)]
        public string? Remark { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Contact { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false)]
        public string UserName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public DateTime? EstablishedDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? EstablishedCity { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? LOGO { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? Fax { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? PostCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? HomePage { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? ArtiPerson { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? EnteRank { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? EnteClassID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public short? CompanyType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? BusinessLicense { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? TaxNumber { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? AccountBank { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? AccountInfo { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 300, IsNullable = true)]
        public string? ServicePhone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? QQ { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? MSN { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public short? Status { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? CreatedUserID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? UpdatedUserID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? Balance { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int AgentID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? CustCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? CustAccGroupID { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? CustAccGroupName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? SearchItem { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? SearchItem2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? HouseNo { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? Street { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? IsDelete { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? AddressNo { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? OrderFreeze { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? DeliveryFreeze { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? Discount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = true)]
        public string? stockcode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? stockname { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? shippingphone { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true)]
        public string? Accountname { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0001
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false)]
        public string PayConditionCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:立即付款无扣除
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false)]
        public string PayConditionName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? SAPProvince { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? SAPCity { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? SAPCounty { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public bool IsCash { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int EnterpriseType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 5, IsNullable = true, ColumnName = "CREDIT_GRADE")]
        public string? CreditGrade { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? IsShowEZuBo { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? MatchedSupplierId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? MatchedSupplierCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1100
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false)]
        public string SupplierCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:6
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false)]
        public int SupplierId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? PriceGroupCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public decimal? LimitAmount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? PricePackageCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? SaleDepart { get; set; }

        /// <summary>
        /// Desc:
        /// Default:2000
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true)]
        public string? CreditScope { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? Type { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public bool? SkuPackageSpecial1Status { get; set; }

        /// <summary>
        /// Desc:合同客户
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public bool? ContractStatus { get; set; }

    }
}
