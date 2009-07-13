using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.connection;
using cctalklib.checksum;

namespace cctalklib.request
{
    public enum Devices
    {
        CoinReader = 1001,
        CoinDispenser = 1002,
        NotesReader = 1003
    }

    public interface ICommand
    {
        string Mittente
        {
            set;
            get;
        }
        string Destinatario
        {
            set;
            get;
        }
        CheckSumType Checksum
        {
            set;
            get;
        }
        Devices Device
        {
            set;
            get;
        }
        int NByteRequest
        {
            //set;
            get;
        }
        int NByteResponse
        {
            //set;
            get;
        }
        string Header
        {
            //set;
            get;
        }

        IByteArray Bytes
        {
            set;
            get;
        }

        byte[] getRequest();

        //void execute(IConnection conn);

    }
}
