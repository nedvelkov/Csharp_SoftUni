using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough:IGetCalories
    {
        private string flourType;
        private string bakingTehnique;
        private double weight;
        private double modifierFlour;
        private double modifierBaking;
        private const int caloriesPerGram = 2;
        private double calories;

        public Dough(string flour, string baking, double weight)
        {
            this.Flour = flour;
            this.Baking = baking;
            this.Weight = weight;
            SetModifiers();
        }

        public string Flour
        {
            get => this.flourType;
            private set
            {
                switch (value.ToLower())
                {
                    case "white":
                        this.flourType = value;
                        break;
                    case "wholegrain":
                        this.flourType = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public string Baking
        {
            get => this.bakingTehnique;
            private set
            {
                switch (value.ToLower())
                {

                    case "crispy":
                        this.bakingTehnique = value;
                        break;
                    case "chewy":
                        this.bakingTehnique = value;
                        break;
                    case "homemade":
                        this.bakingTehnique = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        private void SetModifiers()
        {
            switch (this.flourType.ToLower())
            {
                case "white":
                    this.modifierFlour = 1.5;
                    break;
                case "wholegrain":
                    this.modifierFlour = 1.0;
                    break;
            }
            switch (this.bakingTehnique.ToLower())
            {
                case "crispy":
                    this.modifierBaking = 0.9;
                    break;
                case "chewy":
                    this.modifierBaking = 1.1;
                    break;
                case "homemade":
                    this.modifierBaking = 1.0;
                    break;
            }
        }

        public double GetCalories()
        {
            this.calories = caloriesPerGram * weight * modifierBaking * modifierFlour;
            return calories;
        }
        public double GetCaloriesPerGram()
        {
            double calories = caloriesPerGram * modifierFlour * modifierBaking;
            return calories;
        }
    }
}
