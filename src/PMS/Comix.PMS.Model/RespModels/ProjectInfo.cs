using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.PMS.Model.RespModels.Project
{
    /// <summary>
    /// PMS项目信息
    /// </summary>

    public class ProjectInfo
    {
        public Content[] content { get; set; }
        public Pageable pageable { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public bool last { get; set; }
        public Sort sort { get; set; }
        public int numberOfElements { get; set; }
        public bool first { get; set; }
        public int size { get; set; }
        public int number { get; set; }
        public bool empty { get; set; }
    }

    public class Pageable
    {
        public Sort sort { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int offset { get; set; }
        public bool paged { get; set; }
        public bool unpaged { get; set; }
    }

    public class Sort
    {
        public bool sorted { get; set; }
        public bool unsorted { get; set; }
        public bool empty { get; set; }
    }  

    public class Content
    {
        [JsonProperty(propertyName: "base")]
        public Base _base { get; set; }
        public Tech tech { get; set; }
        public object[] files { get; set; }
        public object[] answerings { get; set; }
        public object[] productConfs { get; set; }
        public object[] bidSections { get; set; }
        public object contracts { get; set; }
    }

    public class Base
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public string shortName { get; set; }
        public string projectType { get; set; }
        public string projectAttribute { get; set; }
        public string customerIndustry { get; set; }
        public string pmUserName { get; set; }
        public string pmEmployeeId { get; set; }
        public string assistantUserName { get; set; }
        public string assistantEmployeeId { get; set; }
        public string projectStatus { get; set; }
        public string customerSuppliers { get; set; }
        public string customerContactUser { get; set; }
        public string customerContact { get; set; }
        public object companyCode { get; set; }
        public object chatGroupName { get; set; }
        public string customerOrderPlatform { get; set; }
        public string mailReceivers { get; set; }
        public object remark { get; set; }
        public string projectBusinessType { get; set; }
    }

    public class Tech
    {
        public object projectId { get; set; }
        public object projectCode { get; set; }
        public object buttedType { get; set; }
        public object isAfferentOMS { get; set; }
        public object suppliersEntry { get; set; }
        public object url { get; set; }
        public object userAccount { get; set; }
        public object userPassword { get; set; }
        public object qxContactUser { get; set; }
        public object qxContact { get; set; }
        public object integrationType { get; set; }
        public object auditNote { get; set; }
        public object productCategoryLevel { get; set; }
    }
}
