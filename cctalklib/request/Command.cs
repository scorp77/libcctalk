using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.checksum;

namespace cctalklib.request
{
    

    public abstract class Command : ICommand
    {
        protected string mittente;
        protected string destinatario;
        protected string header;
        protected Devices dev;
        protected CheckSumType checksum = CheckSumType.None;
        protected int nbyterequest;
        protected int nbyteresponse;
        protected IByteArray array;
        private Dictionary<CheckSumType, IChecksum> check;
        protected Dictionary<Devices, CheckSumType> des;

        public Command(){
            this.des = new Dictionary<Devices, CheckSumType>();
            this.des.Add(Devices.CoinDispenser, CheckSumType.Normal);
            this.des.Add(Devices.CoinReader, CheckSumType.Normal);
            this.des.Add(Devices.NotesReader, CheckSumType.CRC);
            this.check = new Dictionary<CheckSumType, IChecksum>();
            this.check.Add(CheckSumType.Normal, new Checksum());
            this.check.Add(CheckSumType.CRC,new CRCChecksum());
        }

        public string Mittente
        {
            get
            {
                return this.mittente;
            }
            set
            {
                this.mittente = value;
            }
        }

        public string Destinatario
        {
            get
            {
                return this.destinatario;
            }
            set
            {
                this.destinatario = value;
            }
        }

        public CheckSumType Checksum
        {
            get
            {
                return this.checksum;
            }
            set
            {
                this.checksum = value;
            }
        }

        public Devices Device
        {
            get
            {
                return this.dev;
            }
            set
            {
                this.dev = value;

            }
        }

        public int NByteRequest
        {
            get { return this.nbyterequest; }
        }

        public int NByteResponse
        {
            get { return this.nbyteresponse; }
        }

        public string Header
        {
            get { return this.header; }
        }

        public IByteArray Bytes
        {
            get
            {
                return this.array;
            }
            set
            {
                this.array = value;
            }
        }

        protected void estimatedChecksum(byte[] arr)
        {
            if (this.checksum == CheckSumType.None) this.checksum = this.des[this.dev];

            IChecksum ck = this.check[this.Checksum];
            ck.setParameter(this.nbyterequest, arr);
            ck.execute();

        }

        public abstract byte[] getRequest();

    }
}
