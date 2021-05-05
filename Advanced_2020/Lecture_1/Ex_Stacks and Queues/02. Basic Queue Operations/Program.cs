using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            int countNumbers = int.Parse(tokens[0]);
            int removeNumbers = int.Parse(tokens[1]);
            int lookForNumber = int.Parse(tokens[2]);
            var numbers = Console.ReadLine().Split();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < countNumbers; i++)
            {
                if (i > numbers.Length) break;
                int number = int.Parse(numbers[i]);
                queue.Enqueue(number);
            }
            for (int i = 0; i < removeNumbers; i++)
            {
                if (queue.Count == 0) break;
                queue.Dequeue();
            }
            int minNumber = 0;
            bool flag = queue.Contains(lookForNumber);
            if (flag)
            {
                Console.WriteLine(flag.ToString().ToLower());
            }else if (queue.Count > 0)
            {
                minNumber = queue.Min();
                Console.WriteLine(minNumber);
            }
            else
            {
                Console.WriteLine(minNumber);
            }
        }
    }
}
