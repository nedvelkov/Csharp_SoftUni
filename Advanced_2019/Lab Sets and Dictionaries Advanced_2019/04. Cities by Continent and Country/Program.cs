using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int numInputs = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> listCity = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < numInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];
                if (listCity.ContainsKey(continent) == false)
                {
                    listCity.Add(continent, new Dictionary<string, List<string>>());
                }
                if (listCity[continent].ContainsKey(country) == false)
                {
                    listCity[continent].Add(country, new List<string>());
                }
                
                    listCity[continent][country].Add(city);
                
            }
            foreach (var kvp in listCity)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{kvp.Key}:");
                foreach (var country in kvp.Value)
                {
                    sb.AppendLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
                Console.Write(sb);
            }

        }
    }
}
