using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Healt { get; set; }
        public Pokemon()
        {

        }
        public Pokemon(string name,string element, int healt):this()
        {
            this.Name = name;
            this.Element = element;
            this.Healt = healt;
        }
    }
}
