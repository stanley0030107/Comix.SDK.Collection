using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ComixSAP.Common.Schema
{
    [Serializable]
    public partial class SysSapParameterTable : TableInfo
    {
        public const string C_TableName = "SYS_SAP_PARAMETER";

        public const string C_PARA_ID = "PARA_ID";

        public const string C_RFC_CODE = "RFC_CODE";

        public const string C_PARA_NAME = "PARA_NAME";

        public const string C_DATA_TYPE = "DATA_TYPE";

        public const string C_PARA_DESC = "PARA_DESC";

        public const string C_CREATE_TIME = "CREATE_TIME";


        public SysSapParameterTable()
        {
            _tableName = "SYS_SAP_PARAMETER";
        }

        protected static SysSapParameterTable _current;
        public static SysSapParameterTable Current
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
            _current = new SysSapParameterTable();

            _current.Add(C_PARA_ID, new ColumnInfo(C_PARA_ID, "para_id", true, typeof(string)));

            _current.Add(C_RFC_CODE, new ColumnInfo(C_RFC_CODE, "rfc_code", false, typeof(string)));

            _current.Add(C_PARA_NAME, new ColumnInfo(C_PARA_NAME, "para_name", false, typeof(string)));

            _current.Add(C_DATA_TYPE, new ColumnInfo(C_DATA_TYPE, "data_type", false, typeof(string)));

            _current.Add(C_PARA_DESC, new ColumnInfo(C_PARA_DESC, "para_desc", false, typeof(string)));

            _current.Add(C_CREATE_TIME, new ColumnInfo(C_CREATE_TIME, "create_time", false, typeof(DateTime)));

        }


        public ColumnInfo PARA_ID
        {
            get { return this[C_PARA_ID]; }
        }

        public ColumnInfo RFC_CODE
        {
            get { return this[C_RFC_CODE]; }
        }

        public ColumnInfo PARA_NAME
        {
            get { return this[C_PARA_NAME]; }
        }

        public ColumnInfo DATA_TYPE
        {
            get { return this[C_DATA_TYPE]; }
        }

        public ColumnInfo PARA_DESC
        {
            get { return this[C_PARA_DESC]; }
        }

        public ColumnInfo CREATE_TIME
        {
            get { return this[C_CREATE_TIME]; }
        }

    }
}
