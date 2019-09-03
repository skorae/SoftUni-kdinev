using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOfOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var result = new SortedDictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!result.ContainsKey(arr[i]))
                {
                    result.Add(arr[i], 0);
                }

                result[arr[i]]++;
            }

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
            }
        }
    }
}
