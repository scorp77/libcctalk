using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.converter
{
    class AsciiToByte
    {
        internal static byte[] execute(string msg)
        {
            //remove any spaces from the string
            msg.Replace(" ", "");
            //create a byte array the length of the
            //string divided by 2
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
    }
}
