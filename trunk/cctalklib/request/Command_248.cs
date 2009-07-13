using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.request
{
    class Command_248: Command
    {
        #region ICommand Membri di
        
        private byte[] write;
        

        public Command_248(){
            base.header = "248";
            base.nbyteresponse = 12;
            base.nbyterequest = 5;
            base.Mittente = "1";
            ByteArray xd = new ByteArray();
            //xd.Add(255);
            //xd.Add(255);
            base.Bytes = xd;
            this.write = new byte[255];
        }

        

        public override byte[] getRequest()
        {
            int k = 0;
            this.write[k++] = Byte.Parse(base.Mittente);
            this.write[k++] = (byte) base.Bytes.Count();
            this.write[k++] = Byte.Parse(base.Destinatario);
            this.write[k++] = Byte.Parse(base.Header);
            for (int i = 0; i < base.Bytes.Count(); i++)
            {
                this.write[k++] = (byte)base.Bytes[i];
            }
            base.estimatedChecksum(this.write);
            return this.write; 
        }

        #endregion
    }
}
