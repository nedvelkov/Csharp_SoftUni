using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public double Endurance
        {
            get => this.endurance;
            set
            {
                // var name = MethodBase.GetCurrentMethod().Name;
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }
        public double Sprint
        {
            get => this.sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }

        public double Dribble
        {
            get => this.dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }

        }
        public double Passing
        {
            get => this.passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }

        public double Shooting
        {
            get => this.shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }
        public double Skill()
        {
            var skilList = new List<double> { this.endurance, this.sprint, this.dribble, this.passing, this.shooting, };
            var skill = skilList.Average();
            return Math.Round(skill);
        }

        private void ValidIndput(int num, string name)
        {

            if (num < 0 || num > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}

