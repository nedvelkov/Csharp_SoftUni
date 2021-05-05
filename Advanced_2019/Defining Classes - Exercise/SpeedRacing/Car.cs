using System;

namespace SpeedRacing
{
    public  class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumationPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car()
        {
        }

        public Car(string model,double fuel,double fuelConsumation):this()
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumationPerKilometer = fuelConsumation;
        }
        public Car(string input)
        {
            string[] tokens = input.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[0];
            double fuel = double.Parse(tokens[1]);
            double fuelConsumation = double.Parse(tokens[2]);
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumationPerKilometer = fuelConsumation;
        }

        public void Drive(double distance)
        {
            double leftFuel = this.FuelAmount - distance * this.FuelConsumationPerKilometer;
            if (leftFuel >= 0)
            {
                this.FuelAmount = leftFuel;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
