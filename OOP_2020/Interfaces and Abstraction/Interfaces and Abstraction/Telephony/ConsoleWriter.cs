using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class ConsoleWriter : IWrite
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
