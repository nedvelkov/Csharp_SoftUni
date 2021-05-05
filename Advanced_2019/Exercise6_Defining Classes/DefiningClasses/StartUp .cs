using System;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[numOfCars];
            for (int i = 0; i < numOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                string[] engine = tokens.Skip(1).Take(2).ToArray();
                string[] cargo = tokens.Skip(3).Take(2).ToArray();
                string[] tires = tokens.TakeLast(8).ToArray();
                Car car = new Car(model, engine, cargo, tires);
                cars[i] = car;
            }
            string parameter = Console.ReadLine();
            Predicate<Car> predicate=c=> false;
            if (parameter.Equals("fragile"))
            {
                predicate = c => c.Cargo.Type == parameter && c.LowPressure();
            }
            else if(parameter.Equals("flamable"))
            {
                predicate = c => c.Cargo.Type == parameter && c.Engine.Power > 250;
            }
            var result = cars.Where(c=>predicate(c)).Select(c=>c.Model);
            Console.WriteLine(string.Join(Environment.NewLine,result));
        }
    }
}
