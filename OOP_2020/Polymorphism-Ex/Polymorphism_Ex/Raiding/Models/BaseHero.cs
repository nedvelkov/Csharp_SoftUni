namespace Raiding.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public abstract class BaseHero : IHero
    {
        private string name;
        private int power;
        private Dictionary<string, int> powerClass;

        public BaseHero(string name)
        {
            this.Name = name;
            DefinePower();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }

        public int Power
        {
            get => this.power;
        }

        public virtual string CastAbility()
        {
            return null;
        }
        private void DefinePower()
        {
            this.powerClass = new Dictionary<string, int>
            {
                { "Druid", 80 },
                { "Paladin", 100 },
                { "Rogue", 80 },
                { "Warrior", 100 }
            };
            SetPower();
        }

        protected string ClassName()
        {
            var tokken = base.ToString().Split('.');
            var playerClass = tokken[^1];
            var name = base.GetType().Name;
            return playerClass;
        }
        private  void SetPower()
        {
            var tokken = base.ToString().Split('.');
            var playerClass = tokken[^1];
            this.power = this.powerClass[playerClass];
        }
    }
}
