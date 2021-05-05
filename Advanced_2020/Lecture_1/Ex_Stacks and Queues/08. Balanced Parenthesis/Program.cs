using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            foreach (var item in input)
            {
                stack.Push(item);
                queue.Enqueue(item);
            }
            if (input.Length % 2 == 1) Console.WriteLine("NO");
            else
            {
                int length = input.Length/2;
                bool flag = true;
                for (int i = 0; i < length; i++)
                {
                    var firstChar = queue.Dequeue();
                    var lastChar = stack.Pop();
                    string pair = string.Concat(firstChar, lastChar);
                    switch (pair)
                    {
                        case "{}":
                            break;
                            case"[]":
                            break;
                        case "()":
                            break;
                        default:
                            flag = false;
                            break;
                            
                    }
                }
                if (flag)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            
        }
    }
}
