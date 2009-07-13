using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cctalklib.converter
{
    class ByteToAscii
    {
        internal static string execute(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        internal static string execute(byte by)
        {
            StringBuilder builder = new StringBuilder( 3);
            builder.Append(Convert.ToString(by, 16).PadLeft(2, '0').PadRight(3, ' '));
            return builder.ToString().ToUpper();
        }

        
    }
}
