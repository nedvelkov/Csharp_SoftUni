using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> guestList = new SortedDictionary<string, List<string>>();
            int unlikeMeals = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Stop")) break;
                string[] tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string favoure = tokens[0];
                string guest = tokens[1];
                string meal = tokens[2];
                if (favoure.Equals("Like"))
                {
                    if (guestList.ContainsKey(guest) == false)
                    {
                        guestList.Add(guest, new List<string>());
                    }
                    if (guestList[guest].Contains(meal) == false)
                    {
                        guestList[guest].Add(meal);
                    }
                }
                else
                {
                    if (guestList.ContainsKey(guest) == false)
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        if (guestList[guest].Contains(meal) == false)
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlikeMeals++;
                            guestList[guest].Remove(meal);
                        }
                    }
                }



            }
            foreach (var guest in guestList.OrderByDescending(m => m.Value.Count))
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ",guest.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikeMeals}");
        }
    }
}
