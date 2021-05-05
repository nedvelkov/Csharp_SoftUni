using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }
        public Cargo()
        {

        }
        public Cargo(string[] cargo)
        {
            int weight = int.Parse(cargo[0]);
            string type = cargo[1];
            this.Weight = weight;
            this.Type = type;
        }
    }
}
