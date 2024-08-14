using Comix.COM.SDK.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comix.COM.SDK.Interfaces
{
    public interface ICOMService
    {
        Task<ResponseComModel> UniqueIdNewIdAsync(CodeParam req);

        ResponseComModel UniqueIdNewId(CodeParam req);
    }
}
