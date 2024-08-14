using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using ComixSAP.Common.Schema;

namespace ComixSAP.Common.Entity
{
    [Serializable]
    public partial class SysSapParameterEntity : EntityBase
    {
        public SysSapParameterTable TableSchema
        {
            get
            {
                return SysSapParameterTable.Current;
            }
        }


        public SysSapParameterEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return SysSapParameterTable.Current;
            }
        }
        #region 属性列表

        public string ParaId
        {
            get { return (string)GetData(SysSapParameterTable.C_PARA_ID); }
            set { SetData(SysSapParameterTable.C_PARA_ID, value); }
        }

        public string RfcCode
        {
            get { return (string)GetData(SysSapParameterTable.C_RFC_CODE); }
            set { SetData(SysSapParameterTable.C_RFC_CODE, value); }
        }

        public string ParaName
        {
            get { return (string)GetData(SysSapParameterTable.C_PARA_NAME); }
            set { SetData(SysSapParameterTable.C_PARA_NAME, value); }
        }

        public string DataType
        {
            get { return (string)GetData(SysSapParameterTable.C_DATA_TYPE); }
            set { SetData(SysSapParameterTable.C_DATA_TYPE, value); }
        }

        public string ParaDesc
        {
            get { return (string)GetData(SysSapParameterTable.C_PARA_DESC); }
            set { SetData(SysSapParameterTable.C_PARA_DESC, value); }
        }

        public DateTime CreateTime
        {
            get { return (DateTime)(GetData(SysSapParameterTable.C_CREATE_TIME)); }
            set { SetData(SysSapParameterTable.C_CREATE_TIME, value); }
        }

        #endregion
    }
}
