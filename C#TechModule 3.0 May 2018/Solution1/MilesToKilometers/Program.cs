using System;

namespace MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());

            double sum = a * 1.60934;

            Console.WriteLine("{0:F2}", sum);

        }
    }
}
