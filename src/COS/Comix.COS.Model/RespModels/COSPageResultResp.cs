using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
   public class COSPageResultResp<T>
    {
        /// <summary>
        /// 当前页码	
        /// </summary>
        public int current { get; set; }

        /// <summary>
        /// 当前页数	
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 页数	
        /// </summary>
        public int pages { get; set; }

        /// <summary>
        /// 数据总量	
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 是否有前一页	
        /// </summary>
        public bool hasPre { get; set; }

        /// <summary>
        /// 是否有后一页	
        /// </summary>
        public bool hasNext { get; set; }

        /// <summary>
        /// 扩展数据	
        /// </summary>
        public object extra { get; set; }

        /// <summary>
        /// 分类数据
        /// </summary>
        public List<T> records { get; set; } = new List<T>();
    }
}
