using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ComixSAP.Common.Schema
{
    [Serializable]
    public partial class SysSapOutputTable : TableInfo
    {
        public const string C_TableName = "SYS_SAP_OUTPUT";

        public const string C_TABLE_ID = "TABLE_ID";

        public const string C_RFC_CODE = "RFC_CODE";

        public const string C_OUTPUT_TABLE = "OUTPUT_TABLE";

        public const string C_TARGET_TABLE = "TARGET_TABLE";

        public const string C_REMARK = "REMARK";

        public const string C_CREATE_TIME = "CREATE_TIME";


        public SysSapOutputTable()
        {
            _tableName = "SYS_SAP_OUTPUT";
        }

        protected static SysSapOutputTable _current;
        public static SysSapOutputTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new SysSapOutputTable();

            _current.Add(C_TABLE_ID, new ColumnInfo(C_TABLE_ID, "table_id", true, typeof(string)));

            _current.Add(C_RFC_CODE, new ColumnInfo(C_RFC_CODE, "rfc_code", false, typeof(string)));

            _current.Add(C_OUTPUT_TABLE, new ColumnInfo(C_OUTPUT_TABLE, "output_table", false, typeof(string)));

            _current.Add(C_TARGET_TABLE, new ColumnInfo(C_TARGET_TABLE, "target_table", false, typeof(string)));

            _current.Add(C_REMARK, new ColumnInfo(C_REMARK, "remark", false, typeof(string)));

            _current.Add(C_CREATE_TIME, new ColumnInfo(C_CREATE_TIME, "create_time", false, typeof(DateTime)));

        }


        public ColumnInfo TABLE_ID
        {
            get { return this[C_TABLE_ID]; }
        }

        public ColumnInfo RFC_CODE
        {
            get { return this[C_RFC_CODE]; }
        }

        public ColumnInfo OUTPUT_TABLE
        {
            get { return this[C_OUTPUT_TABLE]; }
        }

        public ColumnInfo TARGET_TABLE
        {
            get { return this[C_TARGET_TABLE]; }
        }

        public ColumnInfo REMARK
        {
            get { return this[C_REMARK]; }
        }

        public ColumnInfo CREATE_TIME
        {
            get { return this[C_CREATE_TIME]; }
        }

    }
}
