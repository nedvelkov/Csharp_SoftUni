using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Tournament")) break;
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                int healt = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, element, healt);
                bool flag = true;
                foreach (var trainer in trainers)
                {
                    if (trainer.Name.Equals(trainerName))
                    {
                        trainer.Pokemons.Add(pokemon);
                        flag = false;
                    }
                }
                if (flag)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("End")) break;
                foreach (var trainer in trainers)
                {
                    trainer.AddBadge(input);
                }
            }
            var result = trainers.OrderByDescending(b => b.Badges).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
