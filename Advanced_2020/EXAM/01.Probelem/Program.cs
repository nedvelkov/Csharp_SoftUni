using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Probelem
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens1 = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var tokens2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var task = new Stack<int>(tokens1);
            var thread = new Queue<int>(tokens2);
            var taskToKill = int.Parse(Console.ReadLine());
            while (true)
            {
                var currentTask = task.Peek();
                var currentThread = thread.Peek();
                if (currentTask.Equals(taskToKill)) break;
                if (currentThread >= currentTask)
                {
                    task.Pop();
                    thread.Dequeue();
                }
                if (currentThread < currentTask)
                {
                    thread.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {thread.Peek()} killed task {taskToKill}");
            Console.WriteLine($"{string.Join(" ",thread)}");
        }
    }
}
