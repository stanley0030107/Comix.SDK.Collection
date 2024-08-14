using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.Model.RespModels
{
    /// <summary>
    /// 合同单条查询返回参数
    /// </summary>
    public class QueryContractFindOneResp
    {
        /// <summary>
        /// 详见结构体说明合同
        /// </summary>
        public QueryContractFindOneRespBase _base { get; set; }
        /// <summary>
        /// 详见结构体说明合同-履约
        /// </summary>
        public QueryContractFindOneRespStatement statement { get; set; }
        public object[] districts { get; set; }
        public object[] contacts { get; set; }
        public object[] companies { get; set; }
        public object[] categories { get; set; }
        public object[] auditLogs { get; set; }
        public object[] attachments { get; set; }
        public object[] areas { get; set; }

    }

    /// <summary>
    /// 详见结构体说明合同
    /// </summary>
    public class QueryContractFindOneRespBase
    {
        public int? contractId { get; set; }
        public int? projectId { get; set; }
        public string projectName { get; set; }
        public string biddingName { get; set; }
        public string biddingCode { get; set; }
        public string contractName { get; set; }
        public string contractCode { get; set; }
        public object contractCodePrefix { get; set; }
        public DateTime contractExpirationDateBegin { get; set; }
        public DateTime contractExpirationDateEnd { get; set; }
        public string categoryName { get; set; }
        public int? contractAmount { get; set; }
        public string customerWeight { get; set; }
        public string finalistSupplier { get; set; }
        public string contractStatus { get; set; }
        public string contractAuditStatus { get; set; }
        public string contractAuditCode { get; set; }
        public string platformFeePoints { get; set; }
        public string tenderAgentFeePoints { get; set; }
        public string otherFeePoints { get; set; }
        public string onRemark { get; set; }
        public object originContractCode { get; set; }
        public object originContractId { get; set; }
        public string isCooperative { get; set; }
    }

    /// <summary>
    /// 详见结构体说明合同-履约
    /// </summary>
    public class QueryContractFindOneRespStatement
    {
        public int? deliveryId { get; set; }
        public int? contractId { get; set; }
        public string shipmentsRule { get; set; }
        public int? shipmentsDeadlineHours { get; set; }
        public string deliveryRule { get; set; }
        public int? deliveryDeadlineHours { get; set; }
        public string estimateProfit { get; set; }
        public string basePrice { get; set; }
        public string deliveryOutletsCount { get; set; }
        public string payCondition { get; set; }
        public string payConditionCode { get; set; }
        public int? payConditionDays { get; set; }
        public string securityDeposit { get; set; }
        public string billType { get; set; }
        public int? invoiceDeliveryMonthDay { get; set; }
        public string paymentExpiresType { get; set; }
        public int? paymentDeadDays { get; set; }
        public string paymentMethod { get; set; }
        public string paymentPlatform { get; set; }
        public string invoiceType { get; set; }
        public string invoiceTitle { get; set; }
        public string taxpayerIdentifierNo { get; set; }
        public string receiveTel { get; set; }
        public string receiveAddress { get; set; }
        public string bank { get; set; }
        public string bankAccount { get; set; }
    }
}
