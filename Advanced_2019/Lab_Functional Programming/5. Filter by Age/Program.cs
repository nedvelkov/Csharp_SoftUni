using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> listPeople = new List<People>();
            int numPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numPeople; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                People person = new People();
                person.Age = age;
                person.Name = name;
                listPeople.Add(person);
            }
            string condition = Console.ReadLine();
            int ageOfCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            List<People> newList = new List<People>();
            if (condition.Equals("older"))
            {
                newList = listPeople.Where(p => p.Age >= ageOfCondition).ToList();
            }
            else
            {
                newList = listPeople.Where(p => p.Age < ageOfCondition).ToList();
            }

            if (format.Equals("age"))
            {
                var print = newList.Select(a => a.Age);
                Console.WriteLine(string.Join(Environment.NewLine,print));
            }else if (format.Equals("name"))
            {
                var print = newList.Select(n => n.Name);
                Console.WriteLine(string.Join(Environment.NewLine, print));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, newList));
            }

        }
    }

    class People
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
