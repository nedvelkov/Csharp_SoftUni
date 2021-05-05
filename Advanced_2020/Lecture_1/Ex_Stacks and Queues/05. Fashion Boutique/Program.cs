using System;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            Stack<int> delivery = new Stack<int>();
            int box = 0;
            int capacityBox = int.Parse(Console.ReadLine());
            foreach (var item in tokens)
            {
                delivery.Push(int.Parse(item));
            }
            while (delivery.Count>0)
            {
                int currentBoxCapacity = 0;
                box++;
                while (currentBoxCapacity<capacityBox && delivery.Count > 0)
                {
                    int cloth = delivery.Peek();
                    currentBoxCapacity += cloth;
                    if (currentBoxCapacity > capacityBox)
                    {
                        currentBoxCapacity -= cloth;
                        break;
                    }
                    else
                    {
                        delivery.Pop();
                    }
                }
            }
            Console.WriteLine(box);
        }
    }
}
