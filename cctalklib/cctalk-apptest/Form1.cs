using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cctalklib.connection;

namespace cctalk_apptest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            set.Handshake = SettingRS232Handshake.None;
            set.Parity = SettingRS232Parity.None;
            set.Port = "com6";
            set.Speed = SettingRS232Speed.S9600;
            set.StopBits = SettingRS232Stopbits.One;
            set.DataBits = SettingRs232DataBits.B8;
            ConnectionRS232 con = new ConnectionRS232();
            con.Open(set);

            con.Close();

        }
    }
}
