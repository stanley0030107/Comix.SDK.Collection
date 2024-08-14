using Comix.COS.Model.ReqModels;
using Comix.COS.Model.RespModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.COS.SDK.Interfaces
{
    public interface ICOSImageSearchService
    {
        /// <summary>
        /// 图片搜索
        /// </summary>
        COSImageSearchResp ImageSearch(COSImageSearchReq req);
    }
}
