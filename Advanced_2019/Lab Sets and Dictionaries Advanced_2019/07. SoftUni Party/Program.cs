using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("PARTY")) break;
                if(Char.IsDigit( input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END")) break;
                vipGuests.Remove(input);
                guests.Remove(input);
            }
            int count = vipGuests.Count + guests.Count;
            Console.WriteLine(count);

            if(vipGuests.Count>0) Console.WriteLine(string.Join(Environment.NewLine,vipGuests));
            if(guests.Count>0) Console.WriteLine(string.Join(Environment.NewLine,guests));

        }
    }
}
