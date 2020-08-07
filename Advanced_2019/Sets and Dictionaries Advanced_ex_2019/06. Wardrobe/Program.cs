using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int numInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numInputs; i++)
            {
                string[] token = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = token[0];
                string[] cloths = token[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in cloths)
                {
                    if (wardrobe[color].ContainsKey(item) == false)
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
            }
            string[] tokens = Console.ReadLine().Split();
            string colorCloth = tokens[0];
            string cloth = tokens[1];
            foreach (var kvp in wardrobe)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{kvp.Key} clothes:");
                foreach (var item in kvp.Value)
                {
                    string currentCloth = item.Key;
                    if(currentCloth==cloth && kvp.Key == colorCloth)
                    {
                        sb.AppendLine($"* {currentCloth} - {item.Value} (found!)");
                    }
                    else
                    {
                        sb.AppendLine($"* {item.Key} - {item.Value}");
                    }
                }
                Console.Write(sb);
            }
        }
    }
}
