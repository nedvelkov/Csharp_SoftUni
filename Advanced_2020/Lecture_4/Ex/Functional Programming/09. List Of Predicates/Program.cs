using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, List<int>> func = AddCollection;
            Func<int,List<int>,bool> predicate= (a,b)=> 
            {
                bool flag=true;
                foreach (var num in b)
                {
                    if (a % num != 0) return false;
                }

                return flag;
            };
            var collection = func(end);
            collection = collection.Where(a => predicate(a, dividers)).ToList();
            Console.WriteLine(string.Join(" ",collection));
        }

        public static List<int> AddCollection(int end)
        {
            List<int> listNumbers = new List<int>();
            for (int i = 1; i <= end; i++)
            {
                listNumbers.Add(i);
            }
            return listNumbers;
        }
    }
}
