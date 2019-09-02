using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < n[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < n[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
