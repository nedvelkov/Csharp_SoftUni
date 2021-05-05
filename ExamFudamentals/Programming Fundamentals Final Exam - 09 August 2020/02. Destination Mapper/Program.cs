using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\=\/])(?<destination>[A-Z][A-Za-z]{2,})(\1)";
            Regex regex = new Regex(pattern);
            string massage = Console.ReadLine();
            List<string> destination = new List<string>();
            int travelPoints = 0;
            MatchCollection matches = regex.Matches(massage);
            foreach (Match match in matches)
            {
                string location = match.Groups["destination"].Value;
                destination.Add(location);
                travelPoints += location.Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ",destination)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
