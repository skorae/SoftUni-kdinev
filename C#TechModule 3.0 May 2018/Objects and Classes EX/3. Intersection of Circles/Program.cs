using System;
using System.Linq;

namespace _3._Intersection_of_Circles
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] first = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] second = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Point firstCenter = new Point(first[0], first[2]);
            Point secondCenter = new Point(second[0], second[2]);

        }
    }
    class Point
    {
        public Point ( double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }

        public double Y { get; set; }

    }
    class Circle
    {

        public Circle(Point point, double radius)
        {
            this.Point = point;
            this.Radius = radius;
        }

        public Point Point { get; set; }

        public double Radius { get; set; }
    }
}
