using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLenght = int.Parse(Console.ReadLine());
            var listNames = Console.ReadLine().Split();
            Predicate<string> predicate = new Predicate<string>(n => n.Length <= nameLenght);
            var result = listNames.Where(n => predicate(n));
            Console.WriteLine(string.Join(Environment.NewLine,result));
        }

    }
}
