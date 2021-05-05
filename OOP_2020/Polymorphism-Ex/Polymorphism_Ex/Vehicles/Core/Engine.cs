using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Core
{
    using Models;
    using Contracts;
    public class Engine
    {
        private readonly Dictionary<string,Vehicle> vehicles;

        public Engine()
        {
            this.vehicles = new Dictionary<string, Vehicle>();
        }

        public void AddVehicle()
        {
            var tokkens = Console.ReadLine().Split();
            var type = tokkens[0];
            double fuel = double.Parse(tokkens[1]);
            double consumption = double.Parse(tokkens[2]);
            double tankCapacity = double.Parse(tokkens[3]);
            Vehicle vehicle = default;

            try
            {
            switch (type)
            {
                case "Car":
                    vehicle = new Car(fuel, consumption, tankCapacity);
                    break;
                case "Truck":
                    vehicle = new Truck(fuel, consumption, tankCapacity);
                    break;
                case "Bus":
                    vehicle = new Bus(fuel, consumption, tankCapacity);
                    break;
            }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            this.vehicles.Add(type, vehicle);
        }
        public void MoveVehicle()
        {
            int commands = int.Parse(Console.ReadLine());
            try
            {

            for (int i = 0; i < commands; i++)
            {
                var tokkens = Console.ReadLine().Split();
                var command = tokkens[0];
                string type = tokkens[1];
                double amount = double.Parse(tokkens[2]);
                    Vehicle vechicle = default;
                switch (command)
                {
                    case "Drive":
                            vechicle = this.vehicles[type];
                            vechicle.Drive(amount);
                        break;
                    case "Refuel":
                        this.vehicles[type].Refuel(amount);
                        break;
                    case "DriveEmpty":
                        var current = this.vehicles[type];
                        if(current is Bus bus)
                        {
                            bus.DriveEmpty(amount);
                        }
                        break;
                }

            }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            foreach (var vehicle in this.vehicles)
            {
                var name = vehicle.Key;
                Console.WriteLine($"{name}: {vehicle.Value.FuelQuantity:f2}");
            }
        }
    }
}
