using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    using Models;
    public class Engine
    {
        private readonly List<BaseHero> heroes;
        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }
        public void AddToRaidGroup()
        {
            int raidGroupNumber = int.Parse(Console.ReadLine());
            while (raidGroupNumber>0)
            {
            string name = Console.ReadLine();
            string @class = Console.ReadLine();
            BaseHero hero;
            switch (@class)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default:
                    Console.WriteLine("Invalid hero!");
                    continue;
            }
            this.heroes.Add(hero);
                raidGroupNumber--;
            }

        }

        public void RaidBoss()
        {
            double bossHealt = double.Parse(Console.ReadLine());
            foreach (var hero in this.heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossHealt -= hero.Power;
            }
            if (bossHealt <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
