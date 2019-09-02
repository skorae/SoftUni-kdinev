using System;

namespace _11._Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = AreaCalculator(figure);

            Console.WriteLine($"{area:F2}");
        }
        static double AreaCalculator(string figure)
        {
            double a = 0;
            double b = 0;
            double area = 0;
            if (figure == "triangle")
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                area = 0.5 * (a * b);
            }
            else if (figure == "square")
            {
                a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (figure == "rectangle")
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                area = a * b; ;
            }
            else if (figure == "circle")
            {
                a = double.Parse(Console.ReadLine());
                area = Math.PI * Math.Pow(a, 2);
            }
            return area;
        }
    }
}
