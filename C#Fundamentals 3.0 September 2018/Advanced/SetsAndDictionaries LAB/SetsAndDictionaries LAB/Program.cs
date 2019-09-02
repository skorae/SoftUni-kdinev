using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            var dictionary = new Dictionary<double, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsKey(arr[i]) == false)
                {
                    dictionary.Add(arr[i], 1);
                }
                else
                {
                    dictionary[arr[i]] += 1;
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
