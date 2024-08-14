using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ComixSAP.Common.Schema
{
    [Serializable]
    public partial class SysSapOutputFieldTable : TableInfo
    {
        public const string C_TableName = "SYS_SAP_OUTPUT_FIELD";

        public const string C_FIELD_ID = "FIELD_ID";

        public const string C_TABLE_ID = "TABLE_ID";

        public const string C_FIELD_NAME = "FIELD_NAME";

        public const string C_TARGET_FIELD = "TARGET_FIELD";

        public const string C_DATA_TYPE = "DATA_TYPE";

        public const string C_DATA_LENGTH = "DATA_LENGTH";

        public const string C_SORT_ORDER = "SORT_ORDER";

        public const string C_REMARK = "REMARK";

        public const string C_CREATE_TIME = "CREATE_TIME";


        public SysSapOutputFieldTable()
        {
            _tableName = "SYS_SAP_OUTPUT_FIELD";
        }

        protected static SysSapOutputFieldTable _current;
        public static SysSapOutputFieldTable Current
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
            _current = new SysSapOutputFieldTable();

            _current.Add(C_FIELD_ID, new ColumnInfo(C_FIELD_ID, "field_id", true, typeof(string)));

            _current.Add(C_TABLE_ID, new ColumnInfo(C_TABLE_ID, "table_id", false, typeof(string)));

            _current.Add(C_FIELD_NAME, new ColumnInfo(C_FIELD_NAME, "field_name", false, typeof(string)));

            _current.Add(C_TARGET_FIELD, new ColumnInfo(C_TARGET_FIELD, "target_field", false, typeof(string)));

            _current.Add(C_DATA_TYPE, new ColumnInfo(C_DATA_TYPE, "data_type", false, typeof(string)));

            _current.Add(C_DATA_LENGTH, new ColumnInfo(C_DATA_LENGTH, "data_length", false, typeof(int)));

            _current.Add(C_SORT_ORDER, new ColumnInfo(C_SORT_ORDER, "sort_order", false, typeof(int)));

            _current.Add(C_REMARK, new ColumnInfo(C_REMARK, "remark", false, typeof(string)));

            _current.Add(C_CREATE_TIME, new ColumnInfo(C_CREATE_TIME, "create_time", false, typeof(DateTime)));

        }


        public ColumnInfo FIELD_ID
        {
            get { return this[C_FIELD_ID]; }
        }

        public ColumnInfo TABLE_ID
        {
            get { return this[C_TABLE_ID]; }
        }

        public ColumnInfo FIELD_NAME
        {
            get { return this[C_FIELD_NAME]; }
        }

        public ColumnInfo TARGET_FIELD
        {
            get { return this[C_TARGET_FIELD]; }
        }

        public ColumnInfo DATA_TYPE
        {
            get { return this[C_DATA_TYPE]; }
        }

        public ColumnInfo DATA_LENGTH
        {
            get { return this[C_DATA_LENGTH]; }
        }

        public ColumnInfo SORT_ORDER
        {
            get { return this[C_SORT_ORDER]; }
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
