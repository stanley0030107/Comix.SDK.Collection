using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using ComixSAP.Common.Schema;

namespace ComixSAP.Common.Entity
{
    [Serializable]
    public partial class SysSapOutputFieldEntity : EntityBase
    {
        public SysSapOutputFieldTable TableSchema
        {
            get
            {
                return SysSapOutputFieldTable.Current;
            }
        }


        public SysSapOutputFieldEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return SysSapOutputFieldTable.Current;
            }
        }
        #region 属性列表

        public string FieldId
        {
            get { return (string)GetData(SysSapOutputFieldTable.C_FIELD_ID); }
            set { SetData(SysSapOutputFieldTable.C_FIELD_ID, value); }
        }

        public string TableId
        {
            get { return (string)GetData(SysSapOutputFieldTable.C_TABLE_ID); }
            set { SetData(SysSapOutputFieldTable.C_TABLE_ID, value); }
        }

        public string FieldName
        {
            get { return (string)GetData(SysSapOutputFieldTable.C_FIELD_NAME); }
            set { SetData(SysSapOutputFieldTable.C_FIELD_NAME, value); }
        }

        public string TargetField
        {
            get { return (string)GetData(SysSapOutputFieldTable.C_TARGET_FIELD); }
            set { SetData(SysSapOutputFieldTable.C_TARGET_FIELD, value); }
        }

        public string DataType
        {
            get { return (string)GetData(SysSapOutputFieldTable.C_DATA_TYPE); }
            set { SetData(SysSapOutputFieldTable.C_DATA_TYPE, value); }
        }

        public int DataLength
        {
            get { return Convert.ToInt32((GetData(SysSapOutputFieldTable.C_DATA_LENGTH))); }
            set { SetData(SysSapOutputFieldTable.C_DATA_LENGTH, value); }
        }

        public int SortOrder
        {
            get { return Convert.ToInt32((GetData(SysSapOutputFieldTable.C_SORT_ORDER))); }
            set { SetData(SysSapOutputFieldTable.C_SORT_ORDER, value); }
        }

        public string Remark
        {
            get { return (string)GetData(SysSapOutputFieldTable.C_REMARK); }
            set { SetData(SysSapOutputFieldTable.C_REMARK, value); }
        }

        public DateTime CreateTime
        {
            get { return (DateTime)(GetData(SysSapOutputFieldTable.C_CREATE_TIME)); }
            set { SetData(SysSapOutputFieldTable.C_CREATE_TIME, value); }
        }

        #endregion
    }
}
