using System;
using System.Linq;

namespace _4._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ",nums.OrderByDescending(x => x).Take(3)));
        }
    }
}
