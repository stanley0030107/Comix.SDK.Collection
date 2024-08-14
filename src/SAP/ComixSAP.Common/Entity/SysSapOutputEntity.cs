using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using ComixSAP.Common.Schema;

namespace ComixSAP.Common.Entity
{
    [Serializable]
    public partial class SysSapOutputEntity : EntityBase
    {
        public SysSapOutputTable TableSchema
        {
            get
            {
                return SysSapOutputTable.Current;
            }
        }


        public SysSapOutputEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return SysSapOutputTable.Current;
            }
        }
        #region 属性列表

        public string TableId
        {
            get { return (string)GetData(SysSapOutputTable.C_TABLE_ID); }
            set { SetData(SysSapOutputTable.C_TABLE_ID, value); }
        }

        public string RfcCode
        {
            get { return (string)GetData(SysSapOutputTable.C_RFC_CODE); }
            set { SetData(SysSapOutputTable.C_RFC_CODE, value); }
        }

        public string OutputTable
        {
            get { return (string)GetData(SysSapOutputTable.C_OUTPUT_TABLE); }
            set { SetData(SysSapOutputTable.C_OUTPUT_TABLE, value); }
        }

        public string TargetTable
        {
            get { return (string)GetData(SysSapOutputTable.C_TARGET_TABLE); }
            set { SetData(SysSapOutputTable.C_TARGET_TABLE, value); }
        }

        public string Remark
        {
            get { return (string)GetData(SysSapOutputTable.C_REMARK); }
            set { SetData(SysSapOutputTable.C_REMARK, value); }
        }

        public DateTime CreateTime
        {
            get { return (DateTime)(GetData(SysSapOutputTable.C_CREATE_TIME)); }
            set { SetData(SysSapOutputTable.C_CREATE_TIME, value); }
        }

        #endregion
    }
}
