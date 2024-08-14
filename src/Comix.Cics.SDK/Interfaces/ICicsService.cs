using Comix.Cics.Model.ReqModels;
using Comix.Cics.Model.RespModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Cics.SDK.Interfaces
{
    public interface ICicsService
    {
        Task<ResponseBase<bool>> NotifyCallBackAsync(NotifyCallBackParam message);

        ResponseBase<bool> NotifyCallBack(NotifyCallBackParam message);
    }
}
