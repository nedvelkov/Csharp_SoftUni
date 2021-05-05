using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
   public class Team
    {
        private string name;
        private Dictionary<string,Player> players;
        private double rating;
        public Team(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string,Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                GetRating();
                return this.rating;
            }
        }

        public void Add(Player player)
        {
            
                this.players.Add(player.Name, player);
        }

        private void GetRating()
        {
            double rating = 0;
            foreach (var player in this.players)
            {
                rating += (player.Value.Skill());
            }
            this.rating = rating;
        }

        public void Remove(string name)
        {
            if (this.players.ContainsKey(name))
            {
                players.Remove(name);
            }
            else
            {
                IWriter writer = new WriteConsole();
                writer.WriteLine($"Player {name} is not in {this.name} team.");
            }
        }
    }
}
