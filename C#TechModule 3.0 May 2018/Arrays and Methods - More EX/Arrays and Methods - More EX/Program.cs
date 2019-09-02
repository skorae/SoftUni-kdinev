using System;
using System.Linq;

namespace Arrays_and_Methods___More_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int min = digits.Min();
            int max = digits.Max();
            int sum = digits.Sum();
            double average = digits.Average();

            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
            
        }
    }
}
