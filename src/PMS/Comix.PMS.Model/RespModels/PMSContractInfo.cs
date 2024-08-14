using Newtonsoft.Json;
using System;

namespace Comix.PMS.Model.RespModels
{
    /// <summary>
    /// PMS合同项目
    /// </summary>
    public class PMSContractInfo
    {
        public Content[] content { get; set; }
        //public Pageable pageable { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public bool last { get; set; }
        //public Sort1 sort { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public int size { get; set; }
        public int number { get; set; }
        public bool empty { get; set; }
    }

    //public class Pageable
    //{
    //    public Sort sort { get; set; }
    //    public int pageNumber { get; set; }
    //    public int pageSize { get; set; }
    //    public int offset { get; set; }
    //    public bool paged { get; set; }
    //    public bool unpaged { get; set; }
    //}

    //public class Sort
    //{
    //    public bool sorted { get; set; }
    //    public bool unsorted { get; set; }
    //    public bool empty { get; set; }
    //}

    //public class Sort1
    //{
    //    public bool sorted { get; set; }
    //    public bool unsorted { get; set; }
    //    public bool empty { get; set; }
    //}

    public class Content
    {
        [JsonProperty(propertyName: "base")]
        public Base _base { get; set; }
        //public Statement statement { get; set; }
        public District[] districts { get; set; }
        public object[] contacts { get; set; }
        public object[] companies { get; set; }
        public object[] categories { get; set; }
        public object[] auditLogs { get; set; }
        public object[] attachments { get; set; }
        public object[] areas { get; set; }
    }

    public class Base
    {
        public int contractId { get; set; }
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string biddingName { get; set; }
        public string biddingCode { get; set; }
        public string contractName { get; set; }
        public string contractCode { get; set; }
        public object contractCodePrefix { get; set; }
        public DateTime? contractExpirationDateBegin { get; set; }
        public DateTime? contractExpirationDateEnd { get; set; }
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

    //public class Statement
    //{
    //    public object deliveryId { get; set; }
    //    public object contractId { get; set; }
    //    public object shipmentsRule { get; set; }
    //    public object shipmentsDeadlineHours { get; set; }
    //    public object deliveryRule { get; set; }
    //    public object deliveryDeadlineHours { get; set; }
    //    public object estimateProfit { get; set; }
    //    public object basePrice { get; set; }
    //    public object deliveryOutletsCount { get; set; }
    //    public object payCondition { get; set; }
    //    public object securityDeposit { get; set; }
    //    public object billType { get; set; }
    //    public object invoiceDeliveryMonthDay { get; set; }
    //    public object paymentExpiresType { get; set; }
    //    public object paymentDeadDays { get; set; }
    //    public object paymentMethod { get; set; }
    //    public object paymentPlatform { get; set; }
    //    public object invoiceType { get; set; }
    //    public object invoiceTitle { get; set; }
    //    public object taxpayerIdentifierNo { get; set; }
    //    public object receiveTel { get; set; }
    //    public object receiveAddress { get; set; }
    //    public object bank { get; set; }
    //    public object bankAccount { get; set; }
    //}

    public class District
    {
        public int districtsId { get; set; }
        public int contractId { get; set; }
        public string contractProjectName { get; set; }
        public string contractProjectCode { get; set; }
        public string pmUserName { get; set; }
        public string pmUserId { get; set; }
        public string pmEmployeeId { get; set; }
        public string servicesUserName { get; set; }
        public string servicesUserId { get; set; }
        public string servicesEmployeeId { get; set; }
        public object districtsName { get; set; }
        public object districtsCode { get; set; }
    }

}
