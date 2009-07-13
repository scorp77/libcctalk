using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.request.exception
{
    class TimeOutException: ApplicationException 
    {
        public TimeOutException(string val)
            : base("Il ciclo ha superato il limite imposto dal programmatore di: "+val)
        {


        }
    }
}
