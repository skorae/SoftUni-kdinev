using System;
using System.Numerics;

namespace Problem_5._Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            if (sbyte.TryParse(n, out sbyte num))
            {
                Console.WriteLine("Sunny");
            }
            else if (int.TryParse(n,out int num1))
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.TryParse(n , out long num2))
            {
                Console.WriteLine("Windy");
            }
            else
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}
