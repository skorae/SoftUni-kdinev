using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalPrograming_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();
            string mod = Console.ReadLine();

            Console.WriteLine();
        }

    }
}