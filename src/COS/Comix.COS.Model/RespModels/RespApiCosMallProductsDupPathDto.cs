using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.Model.RespModels
{
    public class RespApiCosMallProductsDupPathDto
    {
        public List<RespApiCosMallProductsDupPath_ResultDto> result { get; set; }
    }

    public class RespApiCosMallProductsDupPath_ResultDto
    { 
        /// <summary>
        /// 查询的名称
        /// </summary>
        public string queryName { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string matchName { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode { get; set; }
    }
}
