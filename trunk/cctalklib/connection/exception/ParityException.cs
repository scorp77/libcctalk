using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.connection.exception
{
    class ParityException : ApplicationException
    {
        public ParityException(string parity)
        : base ("Parity code error !!!! " + parity)
        {
        }

        public ParityException(string parity, Exception inner)
            : base("Parity code error !!!! " + parity, inner)
        {
        }
    }
}
