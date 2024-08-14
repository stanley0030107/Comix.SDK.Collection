using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Core.BaseModels
{
    public class ComixBaseRequestDto<T>
    {
        public RequestHeader MsgHeader { get; set; }
        [Required]
        public T MsgBody { get; set; }
    }

    public class ComixBaseRequestDto
    {
        public RequestHeader MsgHeader { get; set; }
    }
}
