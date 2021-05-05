using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < numOfPeople; i++)
            {
                string input = Console.ReadLine();
                Person person = new Person(input);
                people.Add(person);
            }
            people = people.Where(a => a.Age > 30).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,people));
        }
    }
}
