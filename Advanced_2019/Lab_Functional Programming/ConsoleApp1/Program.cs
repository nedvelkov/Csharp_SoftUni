using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var words = text.Where(x => Char.IsUpper(x[0]));
            Console.WriteLine(string.Join(Environment.NewLine,words));
        }
    }
}
