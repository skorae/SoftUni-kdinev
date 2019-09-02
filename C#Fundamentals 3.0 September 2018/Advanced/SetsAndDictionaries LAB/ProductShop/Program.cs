using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            while (data?.ToLower() != "revision" )
            {
                string[] arr = data.Split(", ");

                string shop = arr[0];
                string product = arr[1];
                double price = double.Parse(arr[2]);

                if (dictionary.ContainsKey(shop) == false)
                {
                    dictionary.Add(shop, new Dictionary<string, double>());
                    dictionary[shop].Add(product, price);
                }
                else if (dictionary.ContainsKey(shop))
                {
                    if (dictionary[shop].ContainsKey(product) == false)
                    {
                        dictionary[shop].Add(product, price);
                    }
                }
                data = Console.ReadLine();
            }

            foreach (var k in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{k.Key}->");
                foreach (var v in k.Value)
                {
                    Console.WriteLine($"Product: {v.Key}, Price: {v.Value}");
                }
            }
        }
    }
}
