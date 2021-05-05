using NUnit.Framework;
using Raiding;
using Raiding.Models;


namespace Raiding.Test
{
    public class Tests
    {
       
        [TestCase("ivan","Druid")]
       // [TestCase("2pack","elf")]
        public void TryToCreateHero(string name,string @class)
        {
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
                    Assert.Fail();
                    break;
            }
        }
        [TestCase("ivan", "Druid")]
        public void TryToHitWithHero(string name,string @class)
        {
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
                    Assert.Fail();
                    return;
            }
            var result = hero.CastAbility();
            var heroName = hero.Name;
            var strength = hero.Power.ToString();

            Assert.IsTrue(result.Contains(heroName) && result.Contains(strength));

        }

    }
}