using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comix.Core.Enum
{
    public enum SystemType
    {
        [Description("B2B系统")]
        B2B = 1,
        [Description("OMS系统")]
        OMS,
        [Description("ComixB2B_DDP")]
        ComixB2B_DDP,
        [Description("ComixB2C_DDP")]
        ComixB2C_DDP,
        [Description("ComixCOP_DDP")]
        ComixCOP_DDP,
        [Description("ComixCDP_DDP")]
        ComixCDP_DDP,
        [Description("ComixSAP_DDP")]
        ComixSAP_DDP,
        [Description("ComixVOU_DDP")]
        ComixVOU_DDP,
        [Description("ComixEmail_DDP")]
        ComixEmail_DDP,
        [Description("ComixMP_DDP")]
        ComixMP_DDP,
        [Description("ComixOMS_DDP")]
        ComixOMS_DDP,
        [Description("LINK系统")]
        LINK
    }
}
