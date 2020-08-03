using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int numInputs = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < numInputs; i++)
            {
                names.Add(Console.ReadLine());
            }
            
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
