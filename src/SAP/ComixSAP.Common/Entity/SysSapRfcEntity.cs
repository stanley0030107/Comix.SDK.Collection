using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using ComixSAP.Common.Schema;

namespace ComixSAP.Common.Entity
{
    [Serializable]
    public partial class SysSapRfcEntity : EntityBase
    {
        public SysSapRfcTable TableSchema
        {
            get
            {
                return SysSapRfcTable.Current;
            }
        }


        public SysSapRfcEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return SysSapRfcTable.Current;
            }
        }
        #region 属性列表

        public string RfcCode
        {
            get { return (string)GetData(SysSapRfcTable.C_RFC_CODE); }
            set { SetData(SysSapRfcTable.C_RFC_CODE, value); }
        }

        public string RfcName
        {
            get { return (string)GetData(SysSapRfcTable.C_RFC_NAME); }
            set { SetData(SysSapRfcTable.C_RFC_NAME, value); }
        }

        public string RfcDatabase
        {
            get { return (string)GetData(SysSapRfcTable.C_RFC_DATABASE); }
            set { SetData(SysSapRfcTable.C_RFC_DATABASE, value); }
        }

        public string RfcType
        {
            get { return (string)GetData(SysSapRfcTable.C_RFC_TYPE); }
            set { SetData(SysSapRfcTable.C_RFC_TYPE, value); }
        }

        public string RfcDesc
        {
            get { return (string)GetData(SysSapRfcTable.C_RFC_DESC); }
            set { SetData(SysSapRfcTable.C_RFC_DESC, value); }
        }

        public DateTime CreateTime
        {
            get { return (DateTime)(GetData(SysSapRfcTable.C_CREATE_TIME)); }
            set { SetData(SysSapRfcTable.C_CREATE_TIME, value); }
        }

        #endregion
    }
}
