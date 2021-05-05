using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }
        public double Power { get; set; }
        public double Displacement { get; set; }
        public string Efficiency { get; set; }
        public Engine()
        {

        }
        public Engine(string engineParameters) : this()
        {
            string[] tokens = engineParameters.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[0];
            double power = double.Parse(tokens[1]);
            double displacement=-1;
            string efficiency=null;
            for (int i = 2; i < tokens.Length; i++)
            {
                var boolean = double.TryParse(tokens[i], out double value);
                if (boolean == false) efficiency = tokens[i];
                else displacement = double.Parse(tokens[i]);
            }
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement != -1 ? displacement : -1;
            this.Efficiency = efficiency == null ? "n/a" : efficiency;
        }
        public override string ToString()
        {
            string displacementCurrentEngine = this.Displacement == -1 ? $"n/a" : this.Displacement.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{new string(' ',4)}Power: {this.Power}");
            sb.AppendLine($"{new string(' ', 4)}Displacement: {displacementCurrentEngine}");
            sb.Append($"{new string(' ', 4)}Efficiency: {this.Efficiency}");
            return sb.ToString();
        }
    }
}
