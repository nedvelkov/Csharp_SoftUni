using Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.products = new List<Product>();
            this.Name = name;
            this.Money = money;

        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0 )
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void GetProduct( Product product)
        {
            if (product.Cost <= this.money)
            {
                this.money -= product.Cost;
                products.Add(product);
                Console.WriteLine($"{this.name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
        }


        public override string ToString()
        {
            if (this.products.Count == 0)
            {
                return $"{this.name} - Nothing bought";
            }
            return $"{this.name} - {string.Join(", ", this.products)}"; 
        }

    }
}
