using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var partyList = Console.ReadLine().Split().ToList();
            Func<string, List<string>, List<string>> func = (a, list) =>
               {
                   var tokens = a.Split();
                   var command = tokens[0];
                   var createra = tokens[1];
                   var mark = tokens[2];
                   if (command.Equals("Remove"))
                   {
                       switch (createra)
                       {
                           case "StartsWith":

                               list = list.Where(a => a.StartsWith(mark) == false).ToList();
                               break;
                           case "EndsWith":
                               list = list.Where(a => a.EndsWith(mark) == false).ToList();
                               break;
                           default:
                               int lenght = int.Parse(mark);
                               list = list.Where(a => a.Length != lenght).ToList();
                               break;
                       }
                   }
                   else
                   {
                       for (int i = 0; i < list.Count; i++)
                       {
                           var name = list[i];
                           switch (createra)
                           {
                               case "StartsWith":
                                   if (name.StartsWith(mark))
                                   {
                                       list.Insert(i + 1, name);
                                       i++;
                                   }
                                   break;
                               case "EndsWith":
                                   if (name.EndsWith(mark))
                                   {
                                       list.Insert(i + 1, name);
                                       i++;
                                   }
                                   break;
                               default:
                                   int lenght = int.Parse(mark);
                                   if (name.Length==lenght)
                                   {
                                       list.Insert(i + 1, name);
                                       i++;
                                   }
                                   break;
                           }

                       }
                   }
                   return list;
               };
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Party!")) break;
                partyList=func(input, partyList);

            }
            if (partyList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", partyList)} are going to the party!");

            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
