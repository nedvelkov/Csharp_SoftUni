using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal()
        {

        }
        public Animal(string name, int age, string gender) : this()
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;

        }
        public string Name
        {
            get => this.name; set
            {
                if (string.IsNullOrWhiteSpace(value)==false)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                if (value > 0 || string.IsNullOrWhiteSpace(value.ToString())==false)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");

                }
            }
        }
        public string Gender
        {
            get => this.gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }
        public virtual void ProduceSound() { }

        public override string ToString()
        {
            return $"{this.name} {this.age} {this.gender}";
        }

    }
}
