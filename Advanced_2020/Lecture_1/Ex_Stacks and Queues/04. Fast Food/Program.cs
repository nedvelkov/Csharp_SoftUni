using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>();
            var tokens = Console.ReadLine().Split();
            foreach (var num in tokens)
            {
                int number = int.Parse(num);
                orders.Enqueue(number);
            }
            int maxOrder = orders.Max();
            Console.WriteLine(maxOrder);
            int totalOrders = orders.Count();
            for (int i = 0; i < totalOrders; i++)
            {
                if (quantityFood <= 0) break;
                int order = orders.Peek();
                if (order > quantityFood) break;
                quantityFood -= order;
                orders.Dequeue();
            }
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
        }
    }
}
