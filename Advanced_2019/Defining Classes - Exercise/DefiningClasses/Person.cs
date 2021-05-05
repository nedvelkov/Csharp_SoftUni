
using System;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        public string Name { get => name; set => this.name = value; }
        public int Age { get; set; }
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age):this()
        {
            this.Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            this.Name = name;
        }

        public Person(string input)
        {
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            this.name = tokens[0];
            this.Age = int.Parse(tokens[1]);
        }

        public override string ToString()
        {
            // return $"Name: {this.Name}{Environment.NewLine}Age: {this.Age}";
            // return $"{this.Name} {this.Age}";
            return $"{this.Name} - {this.Age}";
        }
    }
}
