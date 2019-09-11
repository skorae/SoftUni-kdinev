using System;
using System.Linq;

namespace SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine($"Sum={arr.Sum()}; Average={arr.Average():f2}");
        }
    }
}
