using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.request;

namespace cctalklib.connection
{
    public interface IConnection
    {
        bool Open(ISetting setting);
        bool IsOpen();
        void Write(ICommand com);
        string Read();
        void Close();
    }
}
