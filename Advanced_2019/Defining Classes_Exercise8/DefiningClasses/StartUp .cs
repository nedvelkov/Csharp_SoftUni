using System;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int numEngines = int.Parse(Console.ReadLine());
            Engine[] engines = new Engine[numEngines];
            for (int i = 0; i < numEngines; i++)
            {
                string input = Console.ReadLine();
                Engine engine = new Engine(input);
                engines[i] = engine;
            }
            int numCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[numCars];
            for (int i = 0; i < numCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string engineModel = tokens[1];
                double weight = -1;
                string color = "n/a";
                for (int j = 2; j < tokens.Length; j++)
                {
                    var type = double.TryParse(tokens[j],out double value);
                    if (type == false) color = tokens[j];
                    else weight = double.Parse(tokens[j]);
                }
                var engine = engines.FirstOrDefault(m => m.Model.Equals(engineModel));
                Car car = new Car(model, engine, weight, color);
                cars[i] = car;
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
