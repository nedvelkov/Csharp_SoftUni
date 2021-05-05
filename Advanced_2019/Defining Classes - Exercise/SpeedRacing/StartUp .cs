using System;
using System.Collections.Generic;

namespace SpeedRacing
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            var listOfCars = new List<Car>();
            for (int i = 0; i < numOfCars; i++)
            {
                Car car = new Car(Console.ReadLine());
                listOfCars.Add(car);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End")) break;
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double distance = double.Parse(tokens[2]);
                foreach (var car in listOfCars)
                {
                    if (car.Model.Equals(model))
                    {
                        car.Drive(distance);
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,listOfCars));
        }
    }
}
