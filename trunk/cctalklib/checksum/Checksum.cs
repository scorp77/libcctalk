using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.checksum
{
    class Checksum : IChecksum
    {
        #region IChecksum Membri di
        private byte[] write;
        private int lencmd;
        

        public void setParameter(int len, byte[] array)
        {

            this.write = array;
            this.lencmd = len;

        }

        private byte checksum(byte[] valore, int num)
        {
            long sum = 0L;
            byte div = 0;

            for (int i = 0; i < num; i++)
            {
                sum += valore[i];
            }

            while (sum > 255)
            {
                sum -= 256;
            }
            if (sum == 0) sum = 256;

            div = (byte)(256 - sum);
            return div;

        }


        public void execute()
        {

            this.write[this.lencmd] = this.checksum(this.write, this.lencmd - 1);//4
        }

        #endregion
    }
}
