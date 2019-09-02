using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string arr = Console.ReadLine();

            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();

            foreach (var item in arr)
            {
                if (dictionary.ContainsKey(item) == false)
                {
                    dictionary.Add(item, 1);
                    continue;
                }
                dictionary[item]++;
            }

            foreach (var key in dictionary)
            {
                Console.WriteLine($"{key.Key}: {key.Value} time/s");
            }
        }
    }
}
