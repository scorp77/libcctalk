using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.connection;

namespace cctalklib.device
{
    class ReaderCoins : CommandsCommonDevices
    {
        public ReaderCoins(IConnection conn)
            : base(conn)
        {

        }
    }
}
