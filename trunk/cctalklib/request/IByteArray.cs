using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.request
{
    public interface IByteArray : IList<int>
    {
        string ToString();
      
    }
}
