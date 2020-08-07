using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numInputs = int.Parse(Console.ReadLine());
            HashSet<string> chemicalElements = new HashSet<string>();
            for (int i = 0; i < numInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                foreach (var @string in tokens)
                {
                    chemicalElements.Add(@string);
                }
            }
            var ordered = chemicalElements.OrderBy(e => e);
            Console.WriteLine(string.Join(" ",ordered));
        }
    }
}
