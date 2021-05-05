using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        protected int age;
        private string name;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public virtual int Age
        {
            get => this.age; 
            set
            {
                if (value > 0)
                {
                    this.age = value; ;
                }
            }
        }
        public string Name { get => this.name;
            set => this.name = value; }


        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }
}
