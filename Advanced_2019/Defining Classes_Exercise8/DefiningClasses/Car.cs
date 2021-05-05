using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }
        public Car()
        {

        }
        public Car(string model,Engine engine,double weight,string color):this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            string weightCar = this.Weight == -1 ? "n/a" : this.Weight.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{new string(' ',2)}{this.Engine}");
            sb.AppendLine($"{new string(' ', 2)}Weight: {weightCar}");
            sb.Append($"{new string(' ', 2)}Color: {this.Color}");
            return sb.ToString();
        }
    }
}
