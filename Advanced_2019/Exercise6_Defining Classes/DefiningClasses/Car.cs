using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Car
    {
        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
        public Car()
        {
            this.Tires = new Tire[4];
        }
        public Car(string model,string[] engine,string[] cargo,string[] tires):this()
        {
            this.Model = model;
            Engine engine1 = new Engine(engine);
            this.Engine = engine1;
            Cargo cargo1 = new Cargo(cargo);
            this.Cargo = cargo1;
            AddTires(tires);

        }
        void AddTires(string[] tires)
        {
            int index = 0;
            for (int i = 0; i < tires.Length; i++)
            {
                double preasure = double.Parse(tires[i]);
                int age = int.Parse(tires[i + 1]);
                i++;
                Tire tire = new Tire(preasure, age);
                this.Tires[index] = tire;
                index++;
            }
        }
        public bool LowPressure()
        {
            foreach (var tire in this.Tires)
            {
                if (tire.Pressure < 1) return true;
            }

            return false;
        }
    }
}
