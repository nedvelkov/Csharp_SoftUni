using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Dictionary<char, int> countSymbols = new Dictionary<char, int>();
            foreach (var ch in word)
            {
                if (countSymbols.ContainsKey(ch) == false)
                {
                    countSymbols.Add(ch, 0);
                }
                countSymbols[ch]++;
            }
            foreach (var kvp in countSymbols.OrderBy(k=> k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
