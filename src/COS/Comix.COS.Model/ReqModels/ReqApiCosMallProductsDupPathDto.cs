using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.ReqModels
{
    public class ReqApiCosMallProductsDupPathDto
    {
        /// <summary>
        /// 切换提示词，选项：oneForMulti、oneForOne
        /// </summary>
        public string promptSelect { get; set; }

        public List<ReqApiCosMallProductsDupPathDataDto> querys { get; set; }
    }

    public class ReqApiCosMallProductsDupPathDataDto
    { 
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }
    }
}
