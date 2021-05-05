using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Tire
    {
        public double Pressure { get; set; }
        public int Age { get; set; }
        public Tire()
        {

        }
        public Tire(double preasure,int age):this()
        {
            this.Pressure = preasure;
            this.Age = age;
        }
    }
}
