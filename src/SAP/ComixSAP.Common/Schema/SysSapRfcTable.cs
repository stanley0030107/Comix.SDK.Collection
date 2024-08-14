using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ComixSAP.Common.Schema
{
    [Serializable]
    public partial class SysSapRfcTable : TableInfo
    {
        public const string C_TableName = "SYS_SAP_RFC";

        public const string C_RFC_CODE = "RFC_CODE";

        public const string C_RFC_NAME = "RFC_NAME";

        public const string C_RFC_DATABASE = "RFC_DATABASE";

        public const string C_RFC_TYPE = "RFC_TYPE";

        public const string C_RFC_DESC = "RFC_DESC";

        public const string C_CREATE_TIME = "CREATE_TIME";


        public SysSapRfcTable()
        {
            _tableName = "SYS_SAP_RFC";
        }

        protected static SysSapRfcTable _current;
        public static SysSapRfcTable Current
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
            _current = new SysSapRfcTable();

            _current.Add(C_RFC_CODE, new ColumnInfo(C_RFC_CODE, "rfc_code", true, typeof(string)));

            _current.Add(C_RFC_NAME, new ColumnInfo(C_RFC_NAME, "rfc_name", false, typeof(string)));

            _current.Add(C_RFC_DATABASE, new ColumnInfo(C_RFC_DATABASE, "rfc_database", false, typeof(string)));

            _current.Add(C_RFC_TYPE, new ColumnInfo(C_RFC_TYPE, "rfc_type", false, typeof(string)));

            _current.Add(C_RFC_DESC, new ColumnInfo(C_RFC_DESC, "rfc_desc", false, typeof(string)));

            _current.Add(C_CREATE_TIME, new ColumnInfo(C_CREATE_TIME, "create_time", false, typeof(DateTime)));

        }


        public ColumnInfo RFC_CODE
        {
            get { return this[C_RFC_CODE]; }
        }

        public ColumnInfo RFC_NAME
        {
            get { return this[C_RFC_NAME]; }
        }

        public ColumnInfo RFC_DATABASE
        {
            get { return this[C_RFC_DATABASE]; }
        }

        public ColumnInfo RFC_TYPE
        {
            get { return this[C_RFC_TYPE]; }
        }

        public ColumnInfo RFC_DESC
        {
            get { return this[C_RFC_DESC]; }
        }

        public ColumnInfo CREATE_TIME
        {
            get { return this[C_CREATE_TIME]; }
        }

    }
}
