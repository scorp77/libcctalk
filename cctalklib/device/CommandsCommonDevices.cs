using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.connection;

namespace cctalklib.device
{
    class CommandsCommonDevices
    {

        private IConnection cn;

        public CommandsCommonDevices( IConnection conn )
        {
            this.cn = conn;
        }

        public bool reset()
        {
            return true;
        }

        public string serialNumber()
        {
            return "";
        }

        public bool ack()
        {
            return true;
        }

        public bool status()
        {
            return true;
        }
    }
}
