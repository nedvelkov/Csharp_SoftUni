using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPetrolStations = int.Parse(Console.ReadLine());
            Queue<string> petrolStations = new Queue<string>();
            for (int i = 0; i < numOfPetrolStations; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                petrolStations.Enqueue(input);
            }
            int totalFuel = 0;
            for (int i = 0; i < numOfPetrolStations; i++)
            {
                var station = petrolStations.Dequeue();
                var info = station.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int fuel = int.Parse(info[0]);
                int distance = int.Parse(info[1]);
                totalFuel += fuel;
                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    totalFuel = 0;
                    i=-1;
                }
                petrolStations.Enqueue(station);
            }
            var numPetrolStation = petrolStations.Peek().Split(" ",StringSplitOptions.RemoveEmptyEntries)[2];
            Console.WriteLine(numPetrolStation);
        }
    }
}
