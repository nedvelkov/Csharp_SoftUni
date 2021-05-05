using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson,IIdentifiable,IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Citizen(string name,int age,string id, string birthday):this(name,age)
        {
            this.Id = id;
            this.Birthdate = birthday;
        }
        public string Name
        {
            get => this.name; set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get => this.age; set
            {
                if (value < 0)
                {
                    throw new AggregateException("Age must be positive");
                }
                this.age = value;
            }
        }

        public string Birthdate { get => this.birthdate; set => this.birthdate=value; }
        public string Id { get => this.id; set => this.id=value; }
    }
}
