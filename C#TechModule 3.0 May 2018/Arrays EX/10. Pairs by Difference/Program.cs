using System;
using System.Linq;

namespace _10._Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());
            int count = 0;
            
            for (int i = 0; i < numbers. Length - 1; i++)
            {
                for (int y = 1 + i; y < numbers.Length; y++)
                {
                    if (Math.Abs(numbers[i] - numbers[y]) == diff )
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
