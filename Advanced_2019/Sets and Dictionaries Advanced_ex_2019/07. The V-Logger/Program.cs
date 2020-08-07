using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            // list(0) -> followes
            // list(1) -> following
            Dictionary<string, List<HashSet<string>>> vlogersList = new Dictionary<string, List<HashSet<string>>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Statistics")) break;
                string[] tokens = input.Split();
                string vloger = tokens[0];
                if (input.Contains("joined"))
                {
                    if (vlogersList.ContainsKey(vloger) == false)
                    {
                        vlogersList.Add(vloger, new List<HashSet<string>>());
                        vlogersList[vloger].Add(new HashSet<string>()); //followers
                        vlogersList[vloger].Add(new HashSet<string>()); //following
                    }
                }
                if (input.Contains("followed"))
                {
                    string follower = tokens[2];
                    if (vlogersList.ContainsKey(vloger) == false || vlogersList.ContainsKey(follower)==false) continue;
                    if (vloger == follower) continue;
                    vlogersList[vloger][1].Add(follower);
                    vlogersList[follower][0].Add(vloger);
                }

            }
            int count = 1;
            Console.WriteLine($"The V-Logger has a total of {vlogersList.Count} vloggers in its logs.");
            foreach (var vloger in vlogersList.OrderByDescending(f => f.Value[0].Count).ThenBy(fw => fw.Value[1].Count))
            {
                Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value[0].Count} followers, {vloger.Value[1].Count} following");
                if (count == 1)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var follower in vloger.Value[0].OrderBy(n=>n))
                    {
                        sb.AppendLine($"*  {follower}");
                    }
                    Console.Write(sb);
                }
                count++;
            }


        }
    }

    //class Vloger
    //{
    //    public int Followes { get; set; }
    //    public int Followings { get; set; }

    //    public override int GetHashCode()
    //    {
    //        int num = this.Followes * this.Followings * 58;
    //        return num;  
    //    }

    //}
}
