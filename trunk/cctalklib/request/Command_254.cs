using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.request
{
    class Command_254 : Command
    {
        #region ICommand Membri di
        
        private byte[] write;
        

        public Command_254(){
            base.header = "254";
            base.nbyteresponse = 12;
            base.nbyterequest = 5;
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
