using System;
using System.Diagnostics;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                var pizzaName = input.Split(" ");
                var name = pizzaName[1];
                Pizza pizza = new Pizza(name);
                while (true)
                {
                    input = Console.ReadLine();
                    if (input.Equals("END")) break;
                    var tokken = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var @case = tokken[0];
                    try
                    {
                        switch (@case.ToLower())
                        {
                            case "dough":
                                var flour = tokken[1];
                                var baking = tokken[2];
                                var weightDought = double.Parse(tokken[3]);
                                Dough dough = new Dough(flour, baking, weightDought);
                                pizza.Dough = dough;
                                break;
                            case "topping":
                                var product = tokken[1];
                                var weight = double.Parse(tokken[2]);
                                var topping = new Topping(product, weight);
                                pizza.GetTopping(topping);
                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
           
        }
    }
}
