using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }
        public Engine()
        {

        }
        public Engine(string[] engine)
        {
            int speed = int.Parse(engine[0]);
            int power = int.Parse(engine[1]);
            this.Speed = speed;
            this.Power = power;
        }
    }
}
