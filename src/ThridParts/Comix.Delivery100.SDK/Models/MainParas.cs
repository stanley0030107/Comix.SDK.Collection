using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Delivery100.SDK.Models
{
    public class MainParas
    {
        public string ordercode { get; set; }
        /// <summary>
        /// 订阅的快递公司的编码，一律用小写字母
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 订阅的快递单号，单号的最大长度是32个字符
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// 收、寄件人的电话号码（手机和固定电话均可，只能填写一个，顺丰单号必填，其他快递公司选填。如座机号码有分机号，分机号无需上传。）
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 出发地城市，省-市-区，非必填，填了有助于提升签收状态的判断的准确率，请尽量提供
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// 目的地城市，省-市-区，非必填，填了有助于提升签收状态的判断的准确率，且到达目的地后会加大监控频率，请尽量提供
        /// </summary>
        public string to { get; set; }
        /// <summary>
        /// 我方分配给贵司的的授权key
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 附加参数信息
        /// </summary>
        public AdditionalParams parameters { get; set; }

        // public override string ToString()
        // {
        //     return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        // }
    }
}
