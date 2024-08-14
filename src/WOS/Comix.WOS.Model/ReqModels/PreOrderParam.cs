using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.WOS.Model.ReqModels
{
    /// <summary>
    /// 请求发起工单
    /// </summary>
    public class PreOrderParam
    {
        /// <summary>
        /// 请求接口的平台编码
        /// </summary>
        public string platform { get; set; }

        /// <summary>
        /// 业务单据数据
        /// </summary>
        public Feature feature { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public Acceptor[] acceptor { get; set; }
    }

    /// <summary>
    /// 业务单据数据
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// 集采客户编号
        /// </summary>
        public string customCode { get; set; }

        /// <summary>
        /// 集采客户名称
        /// </summary>
        public string customName { get; set; }

        /// <summary>
        /// LINK单号
        /// </summary>
        public string linkOrderNo { get; set; }

        /// <summary>
        /// 服务商名称
        /// </summary>
        public string supplierName { get; set; }

        /// <summary>
        /// 采购平台订单号
        /// </summary>
        public string purchaseOrderNumber { get; set; }

        /// <summary>
        /// 合同项目
        /// </summary>
        public string contractItemName { get; set; }
    }

    /// <summary>
    /// 处理人
    /// </summary>
    public class Acceptor
    {
        /// <summary>
        /// 工单类型 2, "订单模块"，3, "结算模块"，4, "商品上下架"，5, "投诉建议"，6, "其他"工单类型
        /// </summary>
        public int modelType { get; set; }

        /// <summary>
        /// 员工工号,逗号分隔
        /// </summary>
        public string accounts { get; set; }
    }

}
