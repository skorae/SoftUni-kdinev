using System;
using System.Linq;

namespace _5._Rounding_Numbers_Away_from_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
            
            for (int i = 0; i < input.Length ; i++)
            {
                    double result = Math.Round(input[i], MidpointRounding.AwayFromZero);
                    Console.WriteLine($"{input[i]} => {result}");
                
            }
        }
    }
}
