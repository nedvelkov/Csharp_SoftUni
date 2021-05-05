using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class ReadConsole : IRead
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
