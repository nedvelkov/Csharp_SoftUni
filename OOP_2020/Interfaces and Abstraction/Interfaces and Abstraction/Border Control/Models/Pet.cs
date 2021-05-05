using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Pet : IPet
    {
        private readonly string name;
        private readonly string birthday;

        public Pet(string name,string birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
        public string Name => this.name;

        public string Birthday => this.birthday;
    }
}

