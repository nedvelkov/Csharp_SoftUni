using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza : IGetCalories
    {
        private string name;
        private Dough dough;
        private const int maxTopping=10;
        private Topping[] toppings;
        private int index;
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new Topping[maxTopping];
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");

                }
                if (value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get => this.dough;
            set => this.dough = value;
        }
        public void GetTopping(Topping topping)
        {
            if (index != 10)
            {
                this.toppings[index] = topping;
                index++;
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
        public double GetCalories()
        {
            double caloriesDougt = this.dough.GetCaloriesPerGram()*this.dough.Weight;
            double caloresToppings=0.0;
            for (int i = 0; i < index; i++)
            {
                var currentTopping = this.toppings[i];
                caloresToppings += currentTopping.GetCaloriesPerGram() * currentTopping.Weight;
            }
            double calories = caloresToppings + caloriesDougt;
            return calories;
        }

        public double GetCaloriesPerGram()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{this.Name} - {GetCalories():f2} Calories.";
        }
    }
}
