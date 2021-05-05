
namespace BorderControl.Models
{
    using System;
    using BorderControl.Contracts;


    public class Citizen : TownInhabitant, IPerson,IBirthday,ICitizen,IBuyer
    {
        private string name;
        private int age;
        private string birthday;
        private int food;

        public Citizen(string name, int age, string id) : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.food = 0;
        }
        public Citizen(string name, int age, string id,string birthday):this(name,age,id)
        {
            this.birthday = birthday;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be possitive");
                }
                this.age = value;
            }

        }

        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string Birthday => this.birthday;

        public int Food => this.food;

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
