using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.connection.exception
{
    class DataBitsException : ApplicationException
    {
        public DataBitsException(string db)
            : base("DataBits code error !!!! " + db)
        {
        }

        public DataBitsException(string sb, Exception inner)
            : base("DataBits code error !!!! " + sb, inner)
        {
        }
    }
}
