using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping:IGetCalories
    {
        private string type;
        private double weight;
        private double modifier;
        private const int caloriesPerGram = 2;
        public Topping(string type,double weight)
        {
            this.Type = type;
            this.Weight = weight;
            SetModifier();
        }

        public string Type
        {
            get => this.type;
            private set
            {
                switch (value.ToLower())
                {
                    case "meat":
                        this.type = value;
                        break;
                    case "veggies":
                        this.type = value;
                        break;
                    case "cheese":
                        this.type = value;
                        break;
                    case "sauce":
                        this.type = value;
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }
        private void SetModifier()
        {
            switch (this.type.ToLower())
            {
                case "meat":
                    this.modifier = 1.2;
                    break;
                case "veggies":
                    this.modifier = 0.8;
                    break;
                case "cheese":
                    this.modifier = 1.1;
                    break;
                case "sauce":
                    this.modifier = 0.9;
                    break;
            }
        }

        public double GetCalories()
        {
            double totalCalories = this.weight * caloriesPerGram * this.modifier;
            return totalCalories;
        }

        public double GetCaloriesPerGram()
        {
            double calories = this.modifier * caloriesPerGram;
            return calories;
        }
    }
}
