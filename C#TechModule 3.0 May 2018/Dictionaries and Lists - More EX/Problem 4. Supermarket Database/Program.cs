using System;
using System.Collections.Generic;

namespace Problem_4._Supermarket_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<double, int>> products = new Dictionary<string, Dictionary<double, int>>();

            double total = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];

                if (name == "stocked")
                {
                    foreach (var prod in products.Keys)
                    {
                        double sum = 0;
                        foreach (var item in products[prod])
                        {
                            sum += item.Key * item.Value;
                            Console.WriteLine($"{prod}: ${item.Key:F2} * {item.Value} = ${sum:F2}");
                            total += sum;
                        }
                    }
                    for (int i = 0; i < 30; i++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Grand Total: ${total:F2}");
                    return;
                }

                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (products.ContainsKey(name) == false)
                {
                    products.Add(name, new Dictionary<double, int>());
                    products[name].Add(price, quantity);
                }
                else if (products.ContainsKey(name))
                {
                    int temp = 0;
                    foreach (var item in products[name])
                    {
                        temp += item.Value;
                    }
                    products[name] = new Dictionary<double, int>();
                    products[name].Add(price, temp + quantity);
                }
            }
        }
    }
}
