using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.connection.exception;

namespace cctalklib.connection
{
    public enum SettingRS232Handshake
    {
        None = 1,
        RequestToSend = 2,
        RequestToSendXOnXOff = 3,
        XOnXOff = 4
    }
    public enum SettingRS232Parity
    {
        Even = 11,
        Mark = 12,
        None = 13,
        Odd = 14,
        Space = 15

    }
    public enum SettingRS232Stopbits
    {
        None = 21,
        One = 22,
        OnePointFive = 23,
        Two = 24

    }
    public enum SettingRS232Speed
    {
        S110 = 31,
        S300 = 32,
        S1200 = 33,
        S2400 = 34,
        S4800 = 35,
        S9600 = 36,
        S19200 = 37,
        S38400 = 38,
        S57600 = 39,
        S115200 = 40,
        S230400 = 41,
        S460800 = 42,
        S921600 = 43
    }
    public enum SettingRs232DataBits
    {
        B5 = 51,
        B6 = 52,
        B7 = 53,
        B8 = 54
    }


    public class Setting: ISetting
    {
        private SettingRS232Speed sp;
        private SettingRS232Handshake hnd;
        private SettingRS232Parity par;
        private SettingRS232Stopbits sb;
        private SettingRs232DataBits db;
        private string port;

        #region ISetting Membri di
        public Setting()
        {
        }

        public SettingRS232Speed Speed
        {
            get
            {
                return this.sp;
            }
            set
            {
                this.sp = value;
                if (this.sp <= SettingRS232Speed.S110 || this.sp >= SettingRS232Speed.S921600) throw new SpeedException(this.sp.ToString());
            }
        }

        public SettingRS232Handshake Handshake
        {
            get
            {
                return this.hnd;
            }
            set
            {
                this.hnd = value;
                //if (this.hnd <= SettingRS232Handshake.None || this.hnd >= SettingRS232Handshake.XOnXOff) throw new HandshakeException(this.hnd.ToString());
            }
        }

        public SettingRS232Parity Parity
        {
            get
            {
                return this.par;
            }
            set
            {
                this.par = value;
                //if (this.par <= SettingRS232Parity.Space || this.par >= SettingRS232Parity.Even) throw new ParityException(this.par.ToString());
            }
        }

        public SettingRS232Stopbits StopBits
        {
            get
            {
                return this.sb;
            }
            set
            {
                this.sb = value;
                //if (this.sb <= SettingRS232Stopbits.None || this.sb >= SettingRS232Stopbits.Two) throw new StopBitsException(this.sb.ToString());
            }
        }

        public SettingRs232DataBits DataBits
        {
            get
            {
                return this.db;
            }
            set
            {
                this.db = value;
                //if (this.db <= SettingRs232DataBits.B5 || this.db >= SettingRs232DataBits.B8) throw new DataBitsException(this.db.ToString());
            }
        }

        public string Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }

        #endregion
    }
}
