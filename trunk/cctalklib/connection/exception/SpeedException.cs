using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.connection.exception
{
    class SpeedException: ApplicationException
    {
        public SpeedException(string sp)
            : base("DataBits code error !!!! " + sp)
        {
        }

        public SpeedException(string sp, Exception inner)
            : base("DataBits code error !!!! " + sp, inner)
        {
        }
    }
}
