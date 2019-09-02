using System;
using System.Linq;

namespace Problem_4._Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            long sum = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] == n)
                {
                    for (int y = 0; y < i; y++)
                    {
                        sum += numbers[y];
                    }
                    Console.WriteLine(sum);
                    return;
                }
            }
            Console.WriteLine("No occurrences were found!");

        }
    }
}
