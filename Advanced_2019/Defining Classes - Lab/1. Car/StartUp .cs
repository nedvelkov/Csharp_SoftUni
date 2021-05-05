using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("No more tires")) break;
                string[] tokens = input.Split();
                Tire[] tireCollection = new Tire[4];
                int index = 0;
                for (int i = 0; i < tokens.Length; i++)
                {
                    Tire tire = new Tire();
                    int year = int.Parse(tokens[i]);
                    double preasure = double.Parse(tokens[i + 1]);
                    tire.Year = year;
                    tire.Pressure = preasure;
                    i++;
                    tireCollection[index] = tire;
                    index++;
                }
                tires.Add(tireCollection);

            }
            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Engines done")) break;
                string[] tokens = input.Split();

                for (int i = 0; i < tokens.Length; i++)
                {
                    Engine engine = new Engine();
                    int horsePower = int.Parse(tokens[0]);
                    double cubicCapacity = double.Parse(tokens[1]);
                    engine.HorsePower = horsePower;
                    engine.CubicCapacity = cubicCapacity;
                    i++;
                    engines.Add(engine);
                }
            }
            List<Car> cars = new List<Car>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Show special")) break;
                string[] tokens = input.Split();
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                int fuelQuantity = int.Parse(tokens[3]);
                double fuelConsumation = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tireIndex = int.Parse(tokens[6]);
                Car car = new Car(make,model,year,fuelQuantity,fuelConsumation);
                car.Engine = engines[engineIndex];
                car.Tires = tires[tireIndex];
                cars.Add(car);
            }
            var result = cars.Where(c => c.Year >= 2017)
                .Where(c=>c.Engine.HorsePower>330)
                .Where(c=> 
                {
                    double pressure = 0;
                    foreach (var tire in c.Tires)
                    {
                        pressure += tire.Pressure;
                    }
                    return pressure > 9 && pressure < 10;
                })
                .ToList();
            DriveCar(result);
            Console.WriteLine(string.Join(Environment.NewLine,result));
        }
        public static void DriveCar(List<Car> cars)
        {
            foreach (var car in cars)
            {
                car.Drive(20);
            }
        }
    }
}
