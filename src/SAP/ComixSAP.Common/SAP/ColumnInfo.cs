using System;
using System.Runtime.Serialization;
using System.Data;

namespace ComixSAP.Common.SAP
{
    public class ColumnInfo
    {
        public ColumnInfo ReadFromReader(IDataReader reader)
        {
            this.Name = reader["COLUMN_NAME"].ToString();
            this.DataType = reader["DATA_TYPE"].ToString();
            this.OrdinalPosition = Convert.ToInt32(reader["ORDINAL_POSITION"]);
            this.IsNullable = ((string) reader["IS_NULLABLE"]) == "YES";
            this.MaxLength = reader["CHARACTER_MAXIMUM_LENGTH"].ToString();
            return this;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}{2} {3}NULL", new object[] { this.Name, this.DataType, (this.MaxLength == string.Empty) ? "" : ("(" + this.MaxLengthFormatted + ")"), this.IsNullable ? "" : "NOT " });
        }

        public string DataType { get; set; }

        public bool IsNullable { get; set; }

        public string MaxLength { get; set; }

        protected string MaxLengthFormatted
        {
            get
            {
                if (!this.MaxLength.Equals("-1"))
                {
                    return this.MaxLength;
                }
                return "max";
            }
        }

        public string Name { get; set; }

        public int OrdinalPosition { get; set; }
    }
}

