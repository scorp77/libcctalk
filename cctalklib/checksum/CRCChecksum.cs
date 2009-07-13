using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.checksum
{
    class CRCChecksum : IChecksum
    {
        #region IChecksum Membri di
        private Dictionary<CRCType, ICRC> cr;
        private CRCType obj;
        private byte[] arr;
        private int length;
        public CRCChecksum()
        {
            this.cr = new Dictionary<CRCType, ICRC>();
            this.cr.Add(CRCType.CRC16, new CRC16(InitialCrcValue.Zeros));
            this.cr.Add(CRCType.CRC16CCITT, new CRC16CCITT(InitialCrcValue.Zeros));
            this.cr.Add(CRCType.CRC32, new CRC32(InitialCrcValue.Zeros));
        }

        public void setParameter(int len, byte[] array)
        {
            this.arr = array;
            this.length = len;
        }

        public void execute()
        {

            byte[] tmp = new byte[this.length-2];
            tmp[0] = this.arr[0];
            tmp[1] = this.arr[1];
            tmp[2] = this.arr[3];
            for(int i = 0;i<this.arr[1];i++){
                tmp[3+i] = this.arr[4+i];
            }
            ICRC check = this.cr[CRCType.CRC16];
            byte[] d = check.ComputeChecksumBytes(tmp);
            this.arr[2] = d[1];
            this.arr[this.length - 1] = d[0];

        }

        #endregion
    }
}
