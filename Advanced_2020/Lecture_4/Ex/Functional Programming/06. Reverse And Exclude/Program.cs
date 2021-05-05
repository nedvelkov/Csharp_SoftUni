using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numCollection = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var divide = int.Parse(Console.ReadLine());
            Predicate<int> predicate = new Predicate<int>(a => a % divide != 0);
            var result = numCollection.Reverse().Where(n => predicate(n)).ToArray();
            Console.WriteLine(string.Join(" ",result));

        }

    }
}
