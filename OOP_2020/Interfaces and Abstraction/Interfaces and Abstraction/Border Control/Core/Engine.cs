

namespace BorderControl.Core

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BorderControl.Contracts;
    using BorderControl.Models;


    public class Engine
    {
        private IList<ICitizen> citizens;
        private IList<IBirthday> birthdays;
        private Dictionary<string, IBuyer> buyers;
        public Engine()
        {
            this.citizens = new List<ICitizen>();
            this.birthdays = new List<IBirthday>();
            this.buyers = new Dictionary<string, IBuyer>();
        }

        public void ChekID()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End")) break;
                var tokkens = input.Split();
                string name;
                string id;
                string model;
                int age;
                string birthday;
                try
                {
                    switch (tokkens[0])
                    {
                        case "Robot ":
                            model = tokkens[1];
                            id = tokkens[2];
                            Robot robot = new Robot(model, id);
                            this.citizens.Add(robot);
                            break;
                        case "Citizen":
                            name = tokkens[1];
                            age = int.Parse(tokkens[2]);
                            id = tokkens[3];
                            birthday = tokkens[4];
                            Citizen person = new Citizen(name, age, id, birthday);
                            this.citizens.Add(person);
                            this.birthdays.Add(person);
                            break;
                        case "Pet":
                            name = tokkens[1];
                            birthday = tokkens[2];
                            Pet pet = new Pet(name, birthday);
                            this.birthdays.Add(pet);

                            break;

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Detain()
        {
            string lastDigitsID = Console.ReadLine();
            foreach (var current in this.citizens)
            {
                var currentID = current.GetIdNumber();
                if (currentID.EndsWith(lastDigitsID))
                {
                    Console.WriteLine(current.GetIdNumber());
                }
            }
        }
        public void SelebrateBirthday()
        {
            string year = Console.ReadLine();
            foreach (var birthdate in this.birthdays)
            {
                var currentYear = birthdate.Birthday;
                if (currentYear.EndsWith(year))
                {
                    Console.WriteLine(currentYear);
                }
            }
        }
        public void AddBuyers()
        {
            int numOfBuyers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfBuyers; i++)
            {
                var tokkens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokkens[0];
                int age = int.Parse(tokkens[1]);
                string id;
                string birthday;
                string group;


                switch (tokkens.Length)
                {
                    case 4:
                        id = tokkens[2];
                        birthday = tokkens[3];
                        Citizen citizen = new Citizen(name, age, id, birthday);
                        this.buyers.Add(name, citizen);
                        break;
                    case 3:
                        group = tokkens[2];
                        Rebel rebel = new Rebel(name, age, group);
                        this.buyers.Add(name, rebel);
                        break;
                }
            }
        }
        public void SellFood()
        {
            while (true)
            {
                string name = Console.ReadLine();
                if (name.Equals("End")) break;
                if (this.buyers.ContainsKey(name))
                {
                    this.buyers[name].BuyFood();
                }
            }
            var totalFood = 0.0;
            foreach (var buyer in this.buyers)
            {
                totalFood += buyer.Value.Food;
            }
            Console.WriteLine(totalFood);
        }

    }
}
