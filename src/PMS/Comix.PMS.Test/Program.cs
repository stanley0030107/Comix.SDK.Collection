// See https://aka.ms/new-console-template for more information
using Comix.COS.Model.ReqModels;
using Comix.COS.SDK.Interfaces;
using Comix.COS.SDK.Services;
using Comix.PMS.SDK.Interfaces;
using Comix.PMS.SDK.Services;
using Comix.PMS.Test;
using Comix.WOS.Model.ReqModels;
using Comix.WOS.Model.RespModels;
using Comix.WOS.SDK.Interfaces;
using Comix.WOS.SDK.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Reflection;

Console.WriteLine("Hello, World!");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient();

#region COS接口测试
//Comix.COS.SDK.COSExtension.AddService("http://apigateway-uat.qx.com");
//builder.Services.AddSingleton<ICOSCategoryService, COSCategoryService>();
builder.Services.AddSingleton<IWOSService, WOSService>();
var app = builder.Build();
ServiceLocator.Instance = app.Services;

//ICOSCategoryService cOSCategoryService= ServiceLocator.Instance.GetService<ICOSCategoryService>();

//COSQueryPageListReq<COSQueryCategoryListDataReq> cOSQueryPageListList = new COSQueryPageListReq<COSQueryCategoryListDataReq>();
//cOSQueryPageListList.Size = 50;
//cOSQueryPageListList.Data = new COSQueryCategoryListDataReq { PlatformType = "BASIC", Type = "1" }; 

//var ret = cOSCategoryService.GetCategoryList(cOSQueryPageListList);

#endregion


//Comix.PMS.SDK.PMSExtension.AddService("http://apigateway.qx.com");

Comix.WOS.SDK.WOSExtension.AddService("http://apigateway-uat.qx.com", "o2o.eyJhbGciOiJIUzUxMiJ9eyJsb2dpbl91c2VyX2tleSI6IjBlY");

//builder.Services.AddSingleton<IPMSService, PMSService>();


//PMS
//IPMSService demoService = ServiceLocator.Instance.GetService<IPMSService>();

//PMS合同项目
//var retContractInfo = demoService.GetContractInfo(new Comix.PMS.Model.ReqModels.PMSContractInfoParam() { ContractProjectCode = "627", DistrictsQuery = true, ProjectCode = "16001078" });

//WOS
IWOSService demoWOSService = ServiceLocator.Instance.GetService<IWOSService>();

//WOS登录
var retloginInfo = demoWOSService.LoginRegisterByPhone(new Comix.WOS.Model.ReqModels.LoginRegisterByPhoneParam() { PhoneNumber = "15888888888" });

string json = "{\"permissions\":[\"complaints:list\",\"changeOrder:list\"],\"roles\":[{\"roleCode\":\"1\",\"roleName\":\"K\",\"dataScope\":5}],\"employeeNo\":\"800018253\",\"credential\":null}";
var p = new Comix.WOS.Model.ReqModels.ExternalSysLoginParam()
{
    EmployeeNo = "800000050",
    Permissions = new List<string>() { "gaiDan.OK", "gaiDan.submit" },
    RoleCodes = new List<Comix.WOS.Model.ReqModels.RoleInfo>() { new RoleInfo() { dataScope = 1, roleCode = "1", roleName = "K" } }
};
p = JsonConvert.DeserializeObject<Comix.WOS.Model.ReqModels.ExternalSysLoginParam>(json);
retloginInfo = demoWOSService.ExternalSysLogin(p
    );

var kkk = demoWOSService.GetComplaintsStatistics(retloginInfo.token);

if (retloginInfo != null && retloginInfo.code == 200)
{
    string s = "登录成功";

    //发起工单
    var preOrderRet = demoWOSService.GetPreOrder(new Comix.WOS.Model.ReqModels.PreOrderParam()
    {
        platform = "O2O",
        feature = new Comix.WOS.Model.ReqModels.Feature()
        {
            customCode = "16001020",
            customName = "中国移动",
            linkOrderNo = "4444",
            purchaseOrderNumber = "1111",
            supplierName = "联想深圳",
            contractItemName = "合同1"
        },
        acceptor = new Comix.WOS.Model.ReqModels.Acceptor[]
         {
            new Comix.WOS.Model.ReqModels.Acceptor()
            {
                modelType=2,
                accounts="800098"
            },
            new Comix.WOS.Model.ReqModels.Acceptor()
            {
                modelType=3,
                accounts="800098"
            }
         }
    }, retloginInfo.token);
}

Console.ReadLine();


