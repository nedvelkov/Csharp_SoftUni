using System;
using System.Collections.Generic;

namespace Raiding
{
    using Core;
    using Models;
    class Program
    {
        static void Main()
        {
            //BaseHero baseHero = new Druid("21");
            //var type = baseHero.GetType().Name;
            //Console.WriteLine(type);
            
            Engine engine = new Engine();
            engine.AddToRaidGroup();
            engine.RaidBoss();
            
        } 
    }
}
