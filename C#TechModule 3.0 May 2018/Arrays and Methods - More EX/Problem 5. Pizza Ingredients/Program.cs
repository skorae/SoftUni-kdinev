using System;
using System.Collections.Generic;

namespace Problem_5._Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            List<string> total = new List<string>();
            int count = 0;

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Length == n)
                {
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    total.Add(ingredients[i]);
                    count++;
                }
                if (count == 10)
                {
                    break;
                }
            }
            string result = string.Join(", ", total);
            Console.WriteLine($"Made pizza with total of {count} ingredients.");
            Console.WriteLine($"The ingredients are: {result}.");
        }
    }
}
