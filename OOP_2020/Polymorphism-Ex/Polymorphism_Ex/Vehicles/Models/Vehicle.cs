using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    using Contracts;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuel, double consumpion, double capacity)
        {
            this.TankCapacity = capacity;
            this.FuelQuantity = fuel;
            this.FuelConsumption = consumpion;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            private set
            {
                if (value <= 0)
                {
                    throw new AggregateException("Fuel must be a positive number");
                }
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                    return;
                }
                this.fuelQuantity = value;

            }

        }


        public  double FuelConsumption
        {
            get => this.fuelConsumption; private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Consumption can't be negative");
                }
                this.fuelConsumption = value;
            }
        }
        public  double TankCapacity
        {
            get => this.tankCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new AggregateException("Capacity must be a positive number");
                }
                this.tankCapacity = value;
            }
        }

        public virtual void Drive(double distance)
        {
            var needFuel = NeededFuel(distance);
            var tokken = base.ToString().Split('.');
            var name = tokken[^1];

            if (needFuel > this.fuelQuantity)
            {
                Console.WriteLine($"{name} needs refueling");
                return;
            }
            this.fuelQuantity -= needFuel;
            Console.WriteLine($"{name} travelled {distance} km");

        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            double totalFuel = TotalFuel(fuel);
            if (totalFuel < this.tankCapacity)
            {
                this.fuelQuantity = totalFuel;
                return;
            }
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        protected virtual double NeededFuel(double distance)
        {

           return  distance * this.fuelConsumption;
        }

        protected virtual double TotalFuel(double fuel)
        {
            return this.fuelQuantity + fuel;
        }
    }
}
