using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            int numInputs=int.Parse(Console.ReadLine());
           // Console.WriteLine(stopwatch.Elapsed);
            Dictionary<string, Plant> plantList = new Dictionary<string, Plant>();
            for (int i = 0; i < numInputs; i++)
            {
                string[] tokens = Console.ReadLine().Split("<->",StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2) continue;
                string plant = tokens[0].TrimEnd();
                double rariry;
                double.TryParse(tokens[1], out rariry);
                if (plantList.ContainsKey(plant) == false)
                {
                    Plant flower = new Plant();
                    flower.Rarity = rariry;
                    plantList.Add(plant, flower);
                }
                plantList[plant].Rarity = rariry;
            }
            while (true && plantList.Count>0)
            {
                string input = Console.ReadLine();
                if (input.Equals("Exhibition"))
                {
                    break;
                }
                string[] token = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = token[0];

                if (command.Equals("Rate"))
                {
                    string[] data = token[1].Split(" - ",StringSplitOptions.RemoveEmptyEntries);
                    string plant = data[0].TrimEnd();
                    double rating;

                    if (plantList.ContainsKey(plant) == false)
                    {
                        Console.WriteLine("error");
                    }
                    else if(double.TryParse(data[1], out rating))
                    {
                        plantList[plant].Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    

                }
                else if (command.Equals("Update"))
                {
                    string[] data = token[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string plant = data[0].TrimEnd();
                    double rarity;
                    
                    if (plantList.ContainsKey(plant) == false)
                    {
                        Console.WriteLine("error");
                    }
                    else if(double.TryParse(data[1], out rarity))
                    {
                        plantList[plant].Rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command.Equals("Reset"))
                {
                    string plant =token[1].TrimEnd();
                    if (plantList.ContainsKey(plant) == false)
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        for (int i = 0; i < plantList[plant].Rating.Count; i++)
                        {
                            plantList[plant].Rating[i] = 0;
                        }
                    }
                }
                else {
                    Console.WriteLine("error");
                }

            }
            Console.WriteLine($"Plants for the exhibition:");
            //Console.WriteLine(stopwatch.Elapsed);
            foreach (var plant in plantList.OrderByDescending(r => r.Value.Rarity).ThenByDescending(rt => rt.Value.Rating.Average()))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.Rating.Average():f2}");
            }
        }
    }

    class Plant
    {
        public Plant()
        {
            this.Rating = new List<double>();
        }
        
        public double Rarity { get; set; }

        public List<double> Rating { get; set; }
    }
}
