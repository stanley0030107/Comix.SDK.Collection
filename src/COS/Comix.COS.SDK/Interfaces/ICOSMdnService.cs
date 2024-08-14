using System.Collections.Generic;
using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;

namespace Comix.COS.SDK.Interfaces
{
    public interface ICOSMdnService
    {
        /// <summary>
        /// 查询或新增物料
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        CosResponseDto<List<CosResponse2Dto<QuerySapCodeOutput>>> QuerySapCode(QuerySapCodeInput req);
    }
}