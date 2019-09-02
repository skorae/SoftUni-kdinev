using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            

            Console.WriteLine(arr.Count);
            Console.WriteLine(arr.Sum());
        }
    }
}
