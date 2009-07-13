using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.connection.exception
{
    class HandshakeException : ApplicationException
    {
        public HandshakeException(string hand)
        : base ("Handshake code error !!!! "+hand)
        {
        }

        public HandshakeException(string hand, Exception inner)
            : base("Handshake code error !!!! " + hand, inner)
        {
        }
    }
}
