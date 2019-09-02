using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            List<double> input = Console.ReadLine().Split().Select(double.Parse).ToList();
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            
            foreach (var key in input)
            {
                if (counts.Keys.Contains(key) == false)
                {
                    counts.Add(key, 1);
                }
                else
                {
                    counts[key] += 1;
                }
            }
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
           
        }
    }
}
