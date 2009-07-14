using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.checksum
{
    public enum CheckSumType
    {
        None = 0,
        Normal = 1,
        CRC = 2
    }

    interface IChecksum
    {
        void setParameter(int len, byte[] array);
        void execute();
    }
}
