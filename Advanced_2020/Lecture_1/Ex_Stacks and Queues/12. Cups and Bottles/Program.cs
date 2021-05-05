using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokensCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var tokenBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(tokensCups);
            Stack<int> bottles = new Stack<int>(tokenBottles);

            int bottle = bottles.Peek();
            int cup = cups.Peek();
            int wasteWatter = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (cup > bottle)
                {
                    bottles.Pop();
                    cup -= bottle;
                    bottles.TryPeek(out bottle);
                }
                else if (cup == bottle)
                {
                    bottles.Pop();
                    cups.Dequeue();
                    bottles.TryPeek(out bottle);
                    cups.TryPeek(out cup);
                }
                else // cup<botle
                {
                    cups.Dequeue();
                    bottles.Pop();
                    wasteWatter += bottle - cup;
                    bottles.TryPeek(out bottle);
                    cups.TryPeek(out cup);
                }

            }

            if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wasteWatter}");
        }
    }
}
