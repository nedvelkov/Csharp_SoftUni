using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> stackOfText = new Stack<string>();
            stackOfText.Push(sb.ToString());
            for (int i = 0; i < numOfCommands; i++)
            {
                var tokens = Console.ReadLine().Split();
                string command = tokens[0];
                switch (command)
                {
                    case "1":
                        sb.Append(tokens[1]);
                        stackOfText.Push(sb.ToString());
                        break;
                    case "2":
                        int count = int.Parse(tokens[1]);
                        sb.Remove(sb.Length - count, count);
                        stackOfText.Push(sb.ToString());
                        break;
                    case "3":
                        int index = int.Parse(tokens[1])-1;
                        Console.WriteLine(sb[index]);
                        break;
                    case "4":
                        stackOfText.Pop();
                        sb = new StringBuilder();
                        sb.Append( stackOfText.Peek());
                        break;
                }

            }
        }
    }
}
