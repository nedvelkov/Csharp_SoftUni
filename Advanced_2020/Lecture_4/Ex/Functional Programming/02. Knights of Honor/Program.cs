using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = new Action<string[]>(PrintNamesWithPrefix);
            var tokkens = Console.ReadLine().Split();
            print(tokkens);
        }

        public static void PrintNamesWithPrefix(string[] collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"Sir {item}");
            }
        }
    }
}
