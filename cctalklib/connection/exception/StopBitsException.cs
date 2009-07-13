using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.connection.exception
{
    class StopBitsException : ApplicationException
    {
        public StopBitsException(string sb)
            : base("StopBits code error !!!! " + sb)
        {
        }

        public StopBitsException(string sb, Exception inner)
            : base("StopBits code error !!!! " + sb, inner)
        {
        }
    }
}
