using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class ReadConsole : IRead
    {

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
