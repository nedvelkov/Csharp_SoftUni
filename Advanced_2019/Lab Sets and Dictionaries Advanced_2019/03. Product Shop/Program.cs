using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productListInShop = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Revision")) break;
                string[] tokens = input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);
                if (productListInShop.ContainsKey(shop) == false)
                {
                    productListInShop.Add(shop, new Dictionary<string, double>());
                }
                if (productListInShop[shop].ContainsKey(product) == false)
                {
                    productListInShop[shop].Add(product, 0);
                }
                productListInShop[shop][product] = price;

            }
            foreach (var kvp in productListInShop)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{kvp.Key}->");
                foreach (var product in kvp.Value)
                {
                    sb.AppendLine($"Product: {product.Key}, Price: {product.Value}");
                }
                Console.Write(sb);

            }
        }
    }
}
