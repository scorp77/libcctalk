using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cctalklib.request;

namespace cctalklib.loadfile
{

    public enum Function
    {
        ReadBuffer = 229,
        InibitStatus = 231,
        RequestStatus = 248,
        SimplePoll = 254,
        SerialNumber = 242,
        ModifySorter = 210

    }

    public class CommandContainer
    {
        private Dictionary<Function, ICommand> dict;

        public CommandContainer()
        {
            this.dict = new Dictionary<Function, ICommand>();
            this.dict.Add(Function.ModifySorter,new Command_210());
            this.dict.Add(Function.ReadBuffer, new Command_229());
            this.dict.Add(Function.InibitStatus, new Command_231());
            this.dict.Add(Function.SerialNumber, new Command_242());
            this.dict.Add(Function.RequestStatus, new Command_248());
            this.dict.Add(Function.SimplePoll, new Command_254());
        }


    }
}
