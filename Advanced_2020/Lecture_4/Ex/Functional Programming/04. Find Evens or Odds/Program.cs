using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokkens = Console.ReadLine().Split();
            var numType = Console.ReadLine();
            Predicate<int> predicate = a =>
            {
                if (numType.Equals("odd"))
                {
                    return Math.Abs(a % 2) == 1;
                }
                else if (numType.Equals("even"))
                {
                    return a % 2 == 0;
                }
                return false;
            };
            var list = new List<int>();
            int start = int.Parse(tokkens[0]);
            int end = int.Parse(tokkens[1]);
            for (int i = start; i <= end; i++)
            {
                if (predicate(i)) list.Add(i);
            }
            Console.WriteLine(string.Join(" ",list));
        }

    }
}
