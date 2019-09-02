using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string[] com = arr[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                
                string colour = arr[0];


                if (dictionary.ContainsKey(colour) == false)
                {
                    dictionary.Add(colour, new Dictionary<string, int>());

                    for (int y = 0; y < com.Length; y++)
                    {
                        if (dictionary[colour].ContainsKey(com[y]) == false)
                        {
                            dictionary[colour].Add(com[y], 1);
                            continue;
                        }
                        dictionary[colour][com[y]]++;
                    }
                }
                else
                {
                    for (int y = 0; y < com.Length; y++)
                    {
                        if (dictionary[colour].ContainsKey(com[y]) == false)
                        {
                            dictionary[colour].Add(com[y], 1);
                            continue;
                        }
                        dictionary[colour][com[y]]++;
                    }
                }
            }
            string[] command = Console.ReadLine().Split();
            string color = command[0];
            string clothing = command[1];

            foreach (var key in dictionary)
            {
                Console.WriteLine($"{key.Key} clothes:");
                if (key.Key == color)
                {
                    foreach (var k in dictionary[key.Key])
                    {
                        if (k.Key == clothing)
                        {
                            Console.WriteLine($"* {k.Key} - {k.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {k.Key} - {k.Value}");
                        }
                    }
                }
                else
                {
                    foreach (var k in dictionary[key.Key])
                    {
                        Console.WriteLine($"* {k.Key} - {k.Value}");
                    }
                }

            }
        }
    }
}
