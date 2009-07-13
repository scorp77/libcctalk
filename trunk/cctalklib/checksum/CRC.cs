using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.checksum
{
    abstract class CRC : ICRC
    {
        #region ICRC Membri di
        public CRC(InitialCrcValue val)
        {


        }

        public abstract byte[] ComputeChecksumBytes(byte[] arr);

        protected abstract uint ComputeChecksum(byte[] bytes);

        #endregion
    }
}
