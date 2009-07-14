using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.request
{
    class Command_1 : Command
    {
        #region ICommand Membri di
        
        private byte[] write;
        

        public Command_1(){
            base.header = "1";
            base.nbyteresponse = 12;
            base.nbyterequest = 7;
            base.Mittente = "1";
            this.write = new byte[255];
        }

        

        public override byte[] getRequest()
        {
            int k = 0;
            this.write[k++] = Byte.Parse(base.Mittente);
            this.write[k++] = 0;
            this.write[k++] = Byte.Parse(base.Destinatario);
            this.write[k++] = Byte.Parse(base.Header);
            base.estimatedChecksum(this.write);
            return this.write; 
        }

        #endregion
    }
}
