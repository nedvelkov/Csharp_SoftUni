using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    using Contracts;
    public class Bus : Vehicle
    {
        private double fuelQuantity;
        private const double extraConsumption = 1.4;

        public Bus(double fuel, double consumpion, double capacity):base(fuel,consumpion,capacity)
        {

        }

        public void DriveEmpty(double distance)
        {
            double needFuel = base.NeededFuel(distance);
            if (needFuel > this.fuelQuantity)
            {
                Console.WriteLine($"Bus needs refueling");
                return;
            }
            this.fuelQuantity -= needFuel;
            Console.WriteLine($"Bus travelled {distance} km");

        }
        protected override double NeededFuel(double distance)
        {
            return distance * (this.FuelConsumption + extraConsumption);
        }
    }
}
