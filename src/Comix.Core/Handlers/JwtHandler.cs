using Furion.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Handlers
{
    public class JwtHandler : AppAuthorizeHandler
    {
        public override Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
        {
            // 这里写您的授权判断逻辑，授权通过返回 true，否则返回 false

            return Task.FromResult(true);
        }
    }
}
