using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string continent = arr[0];
                string country = arr[1];
                string city = arr[2];

                if (dictionary.ContainsKey(continent) == false)
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                    dictionary[continent].Add(country, new List<string>());
                    dictionary[continent][country].Add(city);
                }
                else if (dictionary.ContainsKey(continent))
                {
                    if (dictionary[continent].ContainsKey(country) == false)
                    {
                        dictionary[continent].Add(country, new List<string>());
                        dictionary[continent][country].Add(city);
                    }
                    else
                    {
                        dictionary[continent][country].Add(city);
                    }
                }
            }

            foreach (var k in dictionary)
            {
                Console.WriteLine($"{k.Key}: ");
                foreach (var v in k.Value)
                {
                    Console.WriteLine($"{v.Key} -> {string.Join(", ",v.Value)}");
                }
            }
        }
    }
}
