using System;

namespace _8._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            string result = ClosePoints(x1, y1, x2, y2);

            Console.WriteLine(result);
            
        }
        static string ClosePoints(double x1, double y1, double x2, double y2)
        {
            double point1 = Math.Abs(x1) + Math.Abs(y1);
            double point2 = Math.Abs(x2) + Math.Abs(y2);
            string result = "";

            if (point1 <= point2)
            {
                result = $"({x1}, {y1})";
            }
            else
            {
                result = $"({x2}, {y2})";
            }
            return result;
        }
    }
}
