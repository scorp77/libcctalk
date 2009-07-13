using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.connection;

namespace cctalklib.request
{
    public class Command_229 : Command
    {
        #region ICommand Membri di
        
        private byte[] write;
        

        public Command_229(){
            base.header = "229";
            base.nbyteresponse = 21;
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
