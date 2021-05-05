using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    using Contracts;
    public class Car :Vehicle
    {
        private const double extraConsumption = 0.9;
        public Car(double fuel,double consumpion,double capacity):base(fuel,consumpion,capacity)
        {
        }
        protected override double NeededFuel(double distance)
        {
            return distance*(this.FuelConsumption+extraConsumption);
        }
    }
}
