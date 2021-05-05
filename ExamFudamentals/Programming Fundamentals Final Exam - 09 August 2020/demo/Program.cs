using System;
using System.Collections.Generic;
using System.Linq;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                int num = random.Next(0, 5);
                list.Add(num);
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = 0;
            }
            Console.WriteLine(list.Average());
        }
    }
}
