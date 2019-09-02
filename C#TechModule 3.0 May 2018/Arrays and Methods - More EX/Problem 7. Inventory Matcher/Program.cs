using System;
using System.Diagnostics;
using System.Linq;

namespace Problem_7._Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] product = Console.ReadLine().Split();
            long[] volume = Console.ReadLine().Split().Select(long.Parse).ToArray();
            decimal[] price = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            long[] quantity = new long[product.Length];

            for (int i = 0; i < volume.Length; i++)
            {
                quantity[i] = volume[i];
            }


            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command == "done")
                {
                    return;
                }

                long order = long.Parse(input[1]);
                int index = Array.IndexOf(product, command);

                if (quantity[index] < order)
                {
                    Console.WriteLine($"We do not have enough {product[index]}");
                    continue;
                }
                else
                {
                    quantity[index] -= order;
                }

                decimal sum = (order * 1.0m) * price[index];

                Console.WriteLine($"{product[index]} x {order} costs {sum:f2}");
            }
        }
    }
}