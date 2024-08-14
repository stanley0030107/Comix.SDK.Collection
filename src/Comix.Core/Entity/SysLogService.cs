using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Entity
{
    ///<summary>
    /// 系统日志表
    ///</summary>
    [SugarTable("SYS_LOG_SERVICE")]
    public partial class SysLogService
    {
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, Length = 40, IsNullable = false, ColumnName = "LOG_ID")]
        public string LogId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true, ColumnName = "LOG_SYSTEM_NAME")]
        public string? LogSystemName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnName = "LOG_CATEGORY")]
        public string LogCategory { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true, ColumnName = "LOG_KEYWORD")]
        public string? LogKeyword { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = false, ColumnName = "SERV_URL")]
        public string ServUrl { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true, ColumnName = "SERV_PARAMETER")]
        public string? ServParameter { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "RTN_CODE")]
        public string? RtnCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 8000, IsNullable = true, ColumnName = "RTN_MESSAGE")]
        public string? RtnMessage { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "ERROR_CODE")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true, ColumnName = "ERROR_REASON")]
        public string? ErrorReason { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnName = "EX_STACK_TRACE")]
        public string ExStackTrace { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = true, ColumnName = "CALLER_MACHINE_NAME")]
        public string? CallerMachineName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false, ColumnName = "CALLER_IP")]
        public string CallerIp { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 500, IsNullable = true)]
        public string? REMARK { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true, ColumnName = "CREATE_TIME")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true, ColumnName = "EXEC_START_TIME")]
        public DateTime? ExecStartTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true, ColumnName = "EXEC_END_TIME")]
        public DateTime? ExecEndTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true, ColumnName = "EXEC_SECOND")]
        public decimal? ExecSecond { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true, ColumnName = "CALLING_JSON")]
        public string? CallingJson { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(IsNullable = true, ColumnName = "RESPONSE_JSON")]
        public string? ResponseJson { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnName = "LOG_TIME")]
        public DateTime LogTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "BACKFIELD_NAME_1")]
        public string? BackfieldName1 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true, ColumnName = "BACKFIELD_VALUE_1")]
        public string? BackfieldValue1 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "BACKFIELD_NAME_2")]
        public string? BackfieldName2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true, ColumnName = "BACKFIELD_VALUE_2")]
        public string? BackfieldValue2 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "BACKFIELD_NAME_3")]
        public string? BackfieldName3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true, ColumnName = "BACKFIELD_VALUE_3")]
        public string? BackfieldValue3 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "BACKFIELD_NAME_4")]
        public string? BackfieldName4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true, ColumnName = "BACKFIELD_VALUE_4")]
        public string? BackfieldValue4 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = true, ColumnName = "BACKFIELD_NAME_5")]
        public string? BackfieldName5 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = true, ColumnName = "BACKFIELD_VALUE_5")]
        public string? BackfieldValue5 { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false, ColumnName = "LAST_MODIFIED_BY")]
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnName = "LAST_MODIFIED_TIME")]
        public DateTime LastModifiedTime { get; set; }

    }
}
