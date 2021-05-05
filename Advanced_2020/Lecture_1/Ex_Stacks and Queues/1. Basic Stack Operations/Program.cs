using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countNumbers = tokens[0];
            int removeNumbers = tokens[1];
            int lookForNumber = tokens[2];
            Stack<int> stack = new Stack<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < countNumbers; i++)
            {
                if (i > numbers.Length) break;
                int number = numbers[i];
                stack.Push(number);
            }
            for (int i = 0; i < removeNumbers; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            int minNumber = 0;
            bool flag = stack.Contains(lookForNumber);
            if (flag)
            {
                Console.WriteLine(flag.ToString().ToLower());
            }
            else if(stack.Count>0)
            {
                minNumber = stack.Min();
                Console.WriteLine(minNumber);
            }
            else
            {
                Console.WriteLine(minNumber);
            }
        }
    }
}
