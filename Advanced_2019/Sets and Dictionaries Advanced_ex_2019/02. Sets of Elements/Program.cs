using System;
using System.Collections.Generic;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int setOne = int.Parse(tokens[0]);
            int setTwo = int.Parse(tokens[1]);
            HashSet<int> setOneInt = new HashSet<int>();
            HashSet<int> setTwoInt = new HashSet<int>();
            for (int i = 0; i < setOne; i++)
            {
                setOneInt.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < setTwo; i++)
            {
                setTwoInt.Add(int.Parse(Console.ReadLine()));
            }
           
            HashSet<int> printNums = new HashSet<int>();
                foreach (var num in setOneInt)
                {
                    if (setTwoInt.Contains(num)) printNums.Add(num);
                }

            Console.WriteLine(string.Join(" ",printNums));
        }
    }
}
