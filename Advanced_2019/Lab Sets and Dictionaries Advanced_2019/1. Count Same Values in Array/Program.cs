using System;
using System.Collections.Generic;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> countNumbers = new Dictionary<double, int>();
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                double number = double.Parse(input[i]);
                if (countNumbers.ContainsKey(number) == false)
                {
                    countNumbers.Add(number, 0);
                }
                countNumbers[number]++;
            }
            foreach (var kvp in countNumbers)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
