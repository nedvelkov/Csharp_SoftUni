using System;

namespace _01._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = new Action<string[]>(PrintNewLine);
            var collection = Console.ReadLine().Split();
            print(collection);

        }

        public static void PrintNewLine(string[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
