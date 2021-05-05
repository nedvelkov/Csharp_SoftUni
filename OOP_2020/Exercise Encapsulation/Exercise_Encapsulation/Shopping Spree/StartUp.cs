using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> clientList = new Dictionary<string, Person>();

            try
            {
                clientList = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                   .Select(p =>
                   {

                       var current = p.Split("=", StringSplitOptions.RemoveEmptyEntries);
                       var name = current[0];
                       var money = decimal.Parse(current[1]);
                       var client = new Person(name, money);
                       return client;
                   })
                   .ToDictionary(s => s.Name, s => s);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Dictionary<string, Product> productList = new Dictionary<string, Product>();

            try
            {
                productList = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries)
                .Select(p =>
                    {

                        var current = p.Split("=", StringSplitOptions.RemoveEmptyEntries);
                        var name = current[0];
                        var cost = decimal.Parse(current[1]);
                        var product = new Product(name, cost);
                        return product;

                    }).ToDictionary(s => s.Name, s => s);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("END")) break;
                var tokkens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var clientName = tokkens[0];
                var productName = tokkens[1];
                if (clientList.ContainsKey(clientName) && productList.ContainsKey(productName))
                {
                    var product = productList[productName];
                    var client = clientList[clientName];
                    client.GetProduct(product);
                }
            }

            foreach (var client in clientList)
            {
                Console.WriteLine(client.Value);
            }

        }
    }
}
