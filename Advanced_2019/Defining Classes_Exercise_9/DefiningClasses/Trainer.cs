using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
        public Trainer()
        {
            this.Pokemons = new List<Pokemon>();
        }
        public Trainer(string name):this()
        {
            this.Name = name;
        }
        public void AddBadge(string element)
        {
            int count = 0;
            foreach (var pokemon in this.Pokemons)
            {
                if (pokemon.Element.Equals(element)) count++;
            }
            if (count > 0) this.Badges++;
            else TakeDamage();
        }
        private void TakeDamage()
        {
            for (int i = 0; i < this.Pokemons.Count; i++)
            {
                var pokemon = this.Pokemons[i];
                pokemon.Healt -= 10;
                if (pokemon.Healt <= 0)
                {
                    this.Pokemons.Remove(pokemon);
                    i--;
                }
            }
        }

        public override string ToString()
        {

            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
