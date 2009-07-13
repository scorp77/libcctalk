using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.connection
{
    public interface ISetting
    {
        SettingRS232Speed Speed
        {
            set;
            get;
        }
        SettingRS232Handshake Handshake
        {
            set;
            get;
        }
        SettingRS232Parity Parity
        {
            set;
            get;
        }
        SettingRS232Stopbits StopBits
        {
            set;
            get;
        }
        SettingRs232DataBits DataBits
        {
            set;
            get;
        }
        string Port
        {
            set;
            get;
        }
    }
}
