using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public class SapEntityBase : ISapEntity
    {
        private string _funcName = string.Empty;
        private SortedDictionary<string, RFCParamater> _propertynames;
        private object[] _propertyValues;
        private List<RFCStructParameter> _rfcStructNames;
        private List<RFCTableParameter> _rfcTableNames;

        protected T GetProperty<T>(string propertyName)
        {
            return SapCommonMethod.ChangeType<T>(this.PropertyList(propertyName));
        }

        protected object GetProperty(string propertyName, TypeCode t)
        {
            object obj2 = this.PropertyList(propertyName);
            if ((obj2 != DBNull.Value) && (obj2 != null))
            {
                return obj2;
            }
            switch (t)
            {
                case TypeCode.Boolean:
                    return false;

                case TypeCode.Char:
                    return null;

                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return 0;

                case TypeCode.DateTime:
                    return new DateTime(0x76c, 1, 1);

                case TypeCode.String:
                    return "";
            }
            return 0.0;
        }

        public object PropertyList(string propertyName)
        {
            int index = 0;
            foreach (KeyValuePair<string, RFCParamater> pair in this.PropertyNames)
            {
                if (pair.Key.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return this.PropertyValues[index];
                }
                index++;
            }
            return null;
        }

        public virtual void SetFieldNames()
        {
            this._propertynames = new SortedDictionary<string, RFCParamater>();
        }

        public void SetProperty(string propertyName, object value)
        {
            int index = 0;
            foreach (KeyValuePair<string, RFCParamater> pair in this.PropertyNames)
            {
                if (pair.Key.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase))
                {
                    this.PropertyValues[index] = value;
                    break;
                }
                index++;
            }
        }

        public void SetProperty(string propertyName, string value, int maxLength)
        {
            if (((value != null) && (maxLength > 0)) && (value.Length > maxLength))
            {
                throw new Exception(string.Concat(new object[] { "属性:", propertyName, "'的长度超过最大长度:", maxLength }));
            }
            this.SetProperty(propertyName, value);
        }

        public void SetPropertyValues(object[] values)
        {
            if (values.Length != this._propertynames.Count)
            {
                throw new Exception("The length of values don't match the propery length! ");
            }
            this._propertyValues = values;
        }

        public virtual void SetStructNames()
        {
            this._rfcStructNames = new List<RFCStructParameter>();
        }

        public virtual void SetTableNames()
        {
            this._rfcTableNames = new List<RFCTableParameter>();
        }

        public virtual bool Validate()
        {
            if (this.RfcTableNames.Any<RFCTableParameter>(s => !this.PropertyNames.Keys.Contains<string>(s.RfcTableName)) || this.RfcStructNames.Any<RFCStructParameter>(s => !this.PropertyNames.Keys.Contains<string>(s.RfcStructName)))
            {
                throw new Exception("SAP属性设置不正确");
            }
            return true;
        }

        [DataMember]
        public string FuncName
        {
            get
            {
                return this._funcName;
            }
            set
            {
                this._funcName = value;
            }
        }

        [DataMember]
        public virtual SortedDictionary<string, RFCParamater> PropertyNames
        {
            get
            {
                if (this._propertynames == null)
                {
                    this.SetFieldNames();
                }
                return this._propertynames;
            }
            protected internal set
            {
                this._propertynames = value;
            }
        }

        public virtual object[] PropertyValues
        {
            get
            {
                if (this._propertyValues == null)
                {
                    this._propertyValues = new object[this.PropertyNames.Count];
                }
                return this._propertyValues;
            }
            protected internal set
            {
                this._propertyValues = value;
            }
        }

        [DataMember]
        public virtual List<RFCStructParameter> RfcStructNames
        {
            get
            {
                if (this._rfcStructNames == null)
                {
                    this.SetStructNames();
                }
                return this._rfcStructNames;
            }
            protected internal set
            {
                this._rfcStructNames = value;
            }
        }

        [DataMember]
        public virtual List<RFCTableParameter> RfcTableNames
        {
            get
            {
                if (this._rfcTableNames == null)
                {
                    this.SetTableNames();
                }
                return this._rfcTableNames;
            }
            protected internal set
            {
                this._rfcTableNames = value;
            }
        }
    }
}

