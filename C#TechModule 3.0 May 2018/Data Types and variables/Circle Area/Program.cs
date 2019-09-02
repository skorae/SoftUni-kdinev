using System;

namespace Circle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double result = Math.PI * rad * rad;

            Console.WriteLine($"{result:f12}");
        }
    }
}
