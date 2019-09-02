using System;

namespace _6._Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double area = TriangleArea(a, b);

            Console.WriteLine(area);

        }
        static double TriangleArea(double a, double b)
        {
            return (a * b) / 2;
        }
    }
}
