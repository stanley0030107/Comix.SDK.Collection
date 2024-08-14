using System.Runtime.Serialization;

namespace ComixSAP.Common.Entity
{
    [DataContract]
    public class ConfigurationEntity
    {
        [DataMember]
        public static int BatchSize
        {
            get
            {
                return 1000;
            }
        }

        [DataMember]
        public static string DataLogFilePath
        {
            get
            {
                return Furion.App.Configuration["DataLogFielPath"].ToString().Trim();
            }
        }

        [DataMember]
        public static string DestinationType
        {
            get
            {
                return Furion.App.Configuration["DestinationType"].ToString().Trim();
            }
        }
    }
}

