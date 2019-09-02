using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[n][];
            List<List<int>> add = new List<List<int>>();

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                List<int> temp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                add.Add(temp);
            }
            for (int i = 0; i < n; i++)
            {
                List<int> temp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                temp.Reverse();
                add[i].AddRange(temp);
            }
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = add[i].ToArray();
                count += jaggedArray[i].Length;
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length != jaggedArray[i + 1].Length)
                {
                    Console.WriteLine($"The total number of cells is: {count}");
                    return;
                }
            }
            foreach (var item in jaggedArray)
            {
                Console.WriteLine($"[{string.Join(", ", item)}]");
            }


        }
    }
}
