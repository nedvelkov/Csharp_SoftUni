using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numOfCommands; i++)
            {
                var tokens = Console.ReadLine().Split();
                switch (tokens[0])
                {
                    case "1":
                        int number = int.Parse(tokens[1]);
                        stack.Push(number);
                        break;
                    case "2":
                        if(stack.Count>0) stack.Pop();
                        break;
                    case "3":
                        if (stack.Count == 0) break;
                        int maxNumber = stack.Max();
                        Console.WriteLine(maxNumber);
                        break;
                    case "4":
                        if (stack.Count == 0) break;
                        int minNumber = stack.Min();
                        Console.WriteLine(minNumber);
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
