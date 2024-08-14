using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComixSAP.Common.SAP
{
    [DataContract]
    public class SapModelBase : ISapModel
    {
        private List<string> _primarykeys;
        private List<string> _propertynames;
        private Dictionary<string, string> _propertyrelation;
        private object[] _propertyValues;
        private string _tableName;

        public T ChangeType<T>(object value)
        {
            object obj2;
            if ((value != DBNull.Value) && (value != null))
            {
                if (value is T)
                {
                    return (T) value;
                }
                return (T) Convert.ChangeType(value, typeof(T));
            }
            switch (Type.GetTypeCode(Type.GetType(typeof(T).Name)))
            {
                case TypeCode.Boolean:
                    obj2 = false;
                    break;

                case TypeCode.Char:
                case TypeCode.String:
                    obj2 = "";
                    break;

                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    obj2 = 0;
                    break;

                case TypeCode.DateTime:
                    obj2 = new DateTime(0x76c, 1, 1);
                    break;

                default:
                    obj2 = 0.0;
                    break;
            }
            return (T) Convert.ChangeType(obj2, typeof(T));
        }

        protected T GetProperty<T>(string propertyName)
        {
            return this.ChangeType<T>(this.PropertyList(propertyName));
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
            for (int i = 0; i < this.PropertyNames.Count; i++)
            {
                if (string.Compare(this.PropertyNames[i], propertyName, true) == 0)
                {
                    return this.PropertyValues[i];
                }
            }
            return null;
        }

        public virtual void SetFieldNames()
        {
        }

        public virtual void SetPrimaryKeys()
        {
            this._primarykeys = new List<string>();
        }

        public void SetProperty(string propertyName, object value)
        {
            for (int i = 0; i < this.PropertyNames.Count; i++)
            {
                if (string.Compare(this.PropertyNames[i], propertyName, true) == 0)
                {
                    this.PropertyValues[i] = value;
                    return;
                }
            }
        }

        public void SetProperty(string propertyName, string value, int maxLength)
        {
            if (((value != null) && (maxLength > 0)) && (value.Length > maxLength))
            {
                throw new Exception(string.Concat(new object[] { "Property:", propertyName, "'s length is over the max length:", maxLength }));
            }
            this.SetProperty(propertyName, value);
        }

        public virtual void SetPropertyRelation()
        {
            this._propertyrelation = new Dictionary<string, string>();
        }

        public void SetPropertyValues(object[] values)
        {
            if (values.Length != this.PropertyNames.Count)
            {
                throw new Exception("The length of values don't match the propery length! ");
            }
            this._propertyValues = values;
        }

        public virtual bool Validate()
        {
            return true;
        }

        [DataMember]
        public virtual List<string> PrimaryKeys
        {
            get
            {
                if (this._primarykeys == null)
                {
                    this.SetPrimaryKeys();
                }
                return this._primarykeys;
            }
            set
            {
                this._primarykeys = value;
            }
        }

        [DataMember]
        public virtual List<string> PropertyNames
        {
            get
            {
                if (this._propertynames == null)
                {
                    this.SetFieldNames();
                }
                return this._propertynames;
            }
            set
            {
                this._propertynames = value;
            }
        }

        [DataMember]
        public virtual Dictionary<string, string> PropertyRelation
        {
            get
            {
                if (this._propertyrelation == null)
                {
                    this.SetPropertyRelation();
                }
                return this._propertyrelation;
            }
            set
            {
                this._propertyrelation = value;
            }
        }

        [DataMember]
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
            set
            {
                this._propertyValues = value;
            }
        }

        [DataMember]
        public string TableName
        {
            get
            {
                return this._tableName;
            }
            set
            {
                this._tableName = value;
            }
        }
    }
}

