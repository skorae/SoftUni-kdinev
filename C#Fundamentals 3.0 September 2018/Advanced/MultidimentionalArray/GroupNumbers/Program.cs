using System;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = nums.Where(n => Math.Abs(n) % 3 == 0).ToArray();            
            jaggedArray[1] = nums.Where(n => Math.Abs(n) % 3 == 1).ToArray();            
            jaggedArray[2] = nums.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[i]));
            }
        }
    }
}
