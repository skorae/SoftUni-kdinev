using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ');
                for (int y = 0; y < arr.Length; y++)
                {
                    set.Add(arr[y]);
                }
            }

            foreach (var item in set)
            {
                Console.Write($"{item} ");
            }

        }
    }
}
