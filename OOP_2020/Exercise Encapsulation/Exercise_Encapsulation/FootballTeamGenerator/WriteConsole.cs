using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class WriteConsole : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
