using System;

namespace Temperature_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double c = FarenheitToCelsius(n);

            Console.WriteLine($"{c:F2}", c);
        }
        static double FarenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
