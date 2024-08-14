using System;
using System.Collections.Generic;
using System.Text;

namespace Comix.Core.BaseModels
{
    public class ComixBaseResponseDto<T>
    {
        public ResponseHeader MsgHeader { get; set; }
        public T MsgBody { get; set; }
    }

    public class ComixBaseResponseDto
    {
        public ResponseHeader MsgHeader { get; set; }
    }
}
