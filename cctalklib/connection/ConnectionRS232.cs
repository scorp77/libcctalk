using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.request;
using cctalklib.converter;
using cctalklib.request.exception;
using System.IO.Ports;
using System.IO;

namespace cctalklib.connection
{
    public class ConnectionRS232 : IConnection
    {

        private SerialPort serialPort1;
        /** dizionari che configurano la seriale **/
        private Dictionary<SettingRS232Handshake, System.IO.Ports.Handshake> hand;
        private Dictionary<SettingRS232Parity, System.IO.Ports.Parity> pari;
        private Dictionary<SettingRS232Stopbits, System.IO.Ports.StopBits> stop;
        private Dictionary<SettingRS232Speed, int> speed;
        private Dictionary<SettingRs232DataBits, int> data;
        /** variabili usate per la lettura **/
        private byte[] read;
        private byte[] write;
        private int val = 0;
        private int realread = 0;
        private int lenris = 0;
        private int lencmd = 0;

        public ConnectionRS232()
        {
            this.serialPort1 = new System.IO.Ports.SerialPort();
            this.MakeDictionary();
            this.read = new byte[255];
            this.write = new byte[255];
        }

        public ~ConnectionRS232()
        {
            if (this.serialPort1.IsOpen) this.serialPort1.Close(); 
        }

        #region IConnection Membri di

        public bool IsOpen()
        {

            return this.serialPort1.IsOpen;
        }

        public bool Open(ISetting setting)
        {
            
            this.serialPort1.PortName = setting.Port;
            this.serialPort1.BaudRate = this.speed[setting.Speed];
            this.serialPort1.DataBits = this.data[setting.DataBits];
            this.serialPort1.Parity = this.pari[setting.Parity];
            this.serialPort1.StopBits = this.stop[setting.StopBits];
            this.serialPort1.Handshake = this.hand[setting.Handshake];

            this.serialPort1.ReadBufferSize = 2048;
            this.serialPort1.WriteBufferSize = 2048;
            this.serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            this.serialPort1.Open();
            return this.IsOpen();
        }

        public void Write(ICommand com)
        {
            /*
            IChecksum chs = this.check[_cmd["checksum"]];
            chs.setParameter(_cmd, this.write);
            chs.execute();
             */


            this.write = com.getRequest();

            serialPort1.Write(this.write, 0, this.lencmd);//5
            long time = DateTime.Now.Ticks;
            long delta = 500;
            while (this.val == 0)
            {
                if (new TimeSpan(DateTime.Now.Ticks - time).TotalMilliseconds == delta)
                {
                    new TimeOutException(delta.ToString());
                }

            }
        }

        public string Read()
        {
            int i;
            StringBuilder build = new StringBuilder();
            for (i = 0; i < this.lenris; i++)
            {
                build.Append(ByteToAscii.execute(this.read[i]));
            }
            return build.ToString();
        }

        public void Close()
        {
            this.serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //user chose binary
                int bytes = serialPort1.BytesToRead;
                //create a byte array to hold the awaiting data
                byte[] comBuffer = new byte[bytes];
                //read the data and store it
                serialPort1.Read(comBuffer, 0, bytes);
                for (int i = this.realread, j = 0; i < bytes + this.realread; i++, j++) this.read[i] = comBuffer[j];
                this.realread += bytes;
                if (this.realread == this.lenris) this.val = this.realread;
            }
            catch (IOException ex)
            {
                Console.WriteLine("eccezione:" + ex.Message);
            }
            catch (InvalidOperationException ex1)
            {
                Console.WriteLine("eccezione:" + ex1.Message);
            }


        }

        private void MakeDictionary()
        {
            this.hand = new Dictionary<SettingRS232Handshake, Handshake>();
            this.hand.Add(SettingRS232Handshake.None, Handshake.None);
            this.hand.Add(SettingRS232Handshake.RequestToSend, Handshake.RequestToSend);
            this.hand.Add(SettingRS232Handshake.RequestToSendXOnXOff, Handshake.RequestToSendXOnXOff);
            this.hand.Add(SettingRS232Handshake.XOnXOff, Handshake.XOnXOff);

            this.pari = new Dictionary<SettingRS232Parity, Parity>();
            this.pari.Add(SettingRS232Parity.Even, Parity.Even);
            this.pari.Add(SettingRS232Parity.Mark, Parity.Mark);
            this.pari.Add(SettingRS232Parity.None, Parity.None);
            this.pari.Add(SettingRS232Parity.Odd, Parity.Odd);
            this.pari.Add(SettingRS232Parity.Space, Parity.Space);
            
            this.stop = new Dictionary<SettingRS232Stopbits, StopBits>();
            this.stop.Add(SettingRS232Stopbits.None, StopBits.None);
            this.stop.Add(SettingRS232Stopbits.One, StopBits.One);
            this.stop.Add(SettingRS232Stopbits.OnePointFive, StopBits.OnePointFive);
            this.stop.Add(SettingRS232Stopbits.Two, StopBits.Two);

            this.speed = new Dictionary<SettingRS232Speed, int>();
            this.speed.Add(SettingRS232Speed.S110, 110);
            this.speed.Add(SettingRS232Speed.S300, 300);
            this.speed.Add(SettingRS232Speed.S1200, 1200);
            this.speed.Add(SettingRS232Speed.S2400, 2400);
            this.speed.Add(SettingRS232Speed.S4800, 4800);
            this.speed.Add(SettingRS232Speed.S9600, 9600);
            this.speed.Add(SettingRS232Speed.S19200, 19200);
            this.speed.Add(SettingRS232Speed.S38400, 38400);
            this.speed.Add(SettingRS232Speed.S57600, 57600);
            this.speed.Add(SettingRS232Speed.S115200, 115200);
            this.speed.Add(SettingRS232Speed.S230400, 230400);
            this.speed.Add(SettingRS232Speed.S460800, 460800);
            this.speed.Add(SettingRS232Speed.S921600, 921600);

            this.data = new Dictionary<SettingRs232DataBits, int>();
            this.data.Add(SettingRs232DataBits.B5, 5);
            this.data.Add(SettingRs232DataBits.B6, 6);
            this.data.Add(SettingRs232DataBits.B7, 7);
            this.data.Add(SettingRs232DataBits.B8, 8);

        }

        #endregion
    }
}
