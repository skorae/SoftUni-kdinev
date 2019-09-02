using System;

namespace Miles_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            double mile = 1.60934;
            double kilometers = double.Parse(Console.ReadLine());

            double conv = kilometers * mile;

            Console.WriteLine($"{conv:f2}");
        }
    }
}
