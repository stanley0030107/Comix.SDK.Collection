namespace Comix.Core.Entity;

    ///<summary>
    ///
    ///</summary>
    [SugarTable("SYS_CODE_RULE")]
    public partial class SysCodeRule
    {
        public SysCodeRule()
        {
        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsNullable = false)]
        public CodeType CodeType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? PreCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 18, IsNullable = true)]
        public string? MidCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 18, IsNullable = true)]
        public string? MidCodeFormat { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? SeedNum { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? WaterNum { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public int? WaterNumLength { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true)]
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 10, IsNullable = true)]
        public string? LastModifyBy { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 255, IsNullable = true)]
        public string? Remark { get; set; }

        public string GetMidCode()
        {
            return MidCodeFormat.ToLower() switch {
                "yymm" => DateTime.Now.ToString("yyMM"),
                "yymmdd" => DateTime.Now.ToString("yyMMdd"),
                "yyyymmdd" => DateTime.Now.ToString("yyyyMMdd"),
                _ => DateTime.Now.ToString("yyyyMMdd")
            } ;
        }
    }