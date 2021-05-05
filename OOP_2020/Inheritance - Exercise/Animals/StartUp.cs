using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input.Equals("beast!")) break;
                string[] tokens = Console.ReadLine().Split();
                var animal = new Animal();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];
                try
                {
                    switch (input)
                    {
                        case "cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "tomcat":
                            animal = new Tomcat(name, age, gender);
                            break;
                        case "kittens":
                            animal = new Kitten(name, age, gender);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");

                    }
                        animals.Add(animal);

                }
                catch (Exception massage)
                {

                    Console.WriteLine(massage); ;
                }

            }
            foreach (var currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
                currentAnimal.ProduceSound();
            }
        }
    }
}
