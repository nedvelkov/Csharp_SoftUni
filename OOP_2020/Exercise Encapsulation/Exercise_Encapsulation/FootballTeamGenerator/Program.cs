﻿using System;

namespace FootballTeamGenerator
{
   public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            while (true)
            {
                engine.Run();
            }
        }
    }
}
