using System;

namespace _9._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            string result1 = ClosePointsString(x1, y1, x3, y3);
            string result2 = ClosePointsString(x2, y2, x4, y4);
            double point1 = ClosePointsDouble(x1, y1, x3, y3);
            double point2 = ClosePointsDouble(x2, y2, x4, y4);

            if (point1 <= point2)
            {
                Console.WriteLine(result1 + result2);
            }
            else
            {
                Console.WriteLine(result2 + result1);
            }


        }
        static string ClosePointsString(double x1, double y1, double x2, double y2)
        {
            double point1 = Math.Abs(x1) + Math.Abs(y1);
            double point2 = Math.Abs(x2) + Math.Abs(y2);
            string result = "";

            if (point1 >= point2)
            {
                result = $"({x1}, {y1})";
            }
            else
            {
                result = $"({x2}, {y2})";
            }
            return result;
        }
        static double ClosePointsDouble(double x1, double y1, double x2, double y2)
        {
            double point1 = Math.Abs(x1) + Math.Abs(y1);
            double point2 = Math.Abs(x2) + Math.Abs(y2);
            double result = 0;

            if (point1 >= point2)
            {
                result = point1;
            }
            else
            {
                result = point2;
            }
            return result;
        }
    }
}
