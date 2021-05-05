using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }
        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(string input)
        {
            string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age =int.Parse( tokens[1]);
            Person member = new Person(name,age);
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person member=new Person();
            member = this.People.OrderByDescending(a => a.Age).ToArray()[0];
            return member;
        }
    }
}
