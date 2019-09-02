using System;

namespace Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double result = 0;
            double a = 0;
            double b = 0;

            switch (type)
            {
                case "square":
                    a = double.Parse(Console.ReadLine());

                    result = SquareArea(a);

                    break;
                case "triangle":
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());

                    result = TriangleArea(a, b);

                    break;
                case "circle":
                    a = double.Parse(Console.ReadLine());

                    result = CircleArea(a);

                    break;
                case "rectangle":
                    a = double.Parse(Console.ReadLine());
                    b = double.Parse(Console.ReadLine());

                    result = RectangleArea(a, b);

                    break;
            }
            Console.WriteLine($"{result:f2}");
        }

        private static double RectangleArea(double a, double b)
        {
            return a * b;
        }

        private static double CircleArea(double a)
        {
            return (a * a) * Math.PI;
        }

        private static double TriangleArea(double a, double b)
        {
            return (a * b) / 2;
        }

        private static double SquareArea(double a)
        {
            return a * a;
        }
    }
}