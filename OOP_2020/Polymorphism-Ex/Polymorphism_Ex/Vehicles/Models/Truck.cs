using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck :Vehicle
    {
        private const double extraConsumption = 1.6;
        private const double tankEfficienty = 0.95;

        public Truck(double fuel, double consumpion, double capacity):base(fuel,consumpion,capacity)
        {
        }
        protected override double NeededFuel(double distance)
        {
            return distance * (this.FuelConsumption + extraConsumption);
        }

        protected override double TotalFuel(double fuel)
        {
            return this.FuelQuantity + fuel * tankEfficienty;
        }
    }
}
