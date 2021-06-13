using System;

namespace _01_Chronometer
{
            using System.Diagnostics;
    class Program
    {
        static  void Main(string[] args)
        {
            var input = Console.ReadLine();
            Chronometer chronometer = new Chronometer();
            while (true)
            {
                if (input.ToLower() == "exit")
                {
                    break;
                }
                switch (input.ToLower())
                {
                    case "lap":
                        Console.WriteLine(chronometer.Lap()); 
                        break;
                    case "laps":
                        Console.WriteLine(string.Join(Environment.NewLine,chronometer.Laps));
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    default:
                        chronometer.Start();
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
