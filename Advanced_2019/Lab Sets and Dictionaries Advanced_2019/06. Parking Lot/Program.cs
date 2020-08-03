using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> plateNums = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END")) break;
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string plate = tokens[1];
                if (command.Equals("IN"))
                {
                    plateNums.Add(plate);
                }
                else
                {
                    plateNums.Remove(plate);
                }
            }
            if (plateNums.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, plateNums));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
