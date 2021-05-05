using System;
using CarManufacturer;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        public string Make { get => this.make; set => this.make=value; }
        public string Model { get => this.model; set => this.model=value; }
        public int Year { get=> this.year; set => this.year=value; }
        public double FuelQuantity { get; set; }
        public double  FuelConsumation { get; set; }
        public Engine Engine { get; set; }
        public Tire[]  Tires { get; set; }
        public Car()
        {
            //this.Tires = new Tire[4];
        }
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year,double fuelQuantity, double fuelConsumation):this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumation,Engine engine,Tire[] tires):this(make,model,year,fuelQuantity,fuelConsumation)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            double leftFuel = this.FuelQuantity - distance * this.FuelConsumation/100;
            if (leftFuel < 0)
            {
               // Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity = leftFuel;
            }
        }
        //public Car DriveDistance(Car car,double distance)
        //{
        //    car.Drive(distance);
        //    return car;
        //}
        public void WhoAmI()
        {
            Console.WriteLine($"Make: {this.make}{Environment.NewLine}Model: {this.model}{Environment.NewLine}Year: {this.year}{Environment.NewLine}Fuel: {this.FuelQuantity:f2}L");
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.AppendLine($"FuelQuantity: {this.FuelQuantity:f1}");
            return sb.ToString();
        }
    }
}
