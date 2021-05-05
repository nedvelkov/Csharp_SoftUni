using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
   public class Product
    {
        private string name;
        private decimal price;
        public string Name { get => this.name; set=> this.name=value; }
        public decimal Price { get=> this.price; set 
            {
                this.price = value;
            } }

        public Product(string name,decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
