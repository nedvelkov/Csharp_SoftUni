using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var price = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);
            var newPrice = price.Select(p => p * 1.2);
            foreach (var p in newPrice)
            {
                Console.WriteLine($"{p:f2}");
            }
        }
    }
}
