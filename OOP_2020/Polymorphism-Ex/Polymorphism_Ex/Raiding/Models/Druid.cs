using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {

        }

        public override string CastAbility()
        {
            var playerClass = ClassName();
            return $"{playerClass} - {this.Name} healed for {this.Power}";
        }
    }
}
