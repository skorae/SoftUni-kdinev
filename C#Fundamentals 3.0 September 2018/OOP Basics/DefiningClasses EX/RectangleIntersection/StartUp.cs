using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangledoubleersection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            double[] param = Console.ReadLine().Split().Select(double.Parse).ToArray();

            double n = param[0];
            double m = param[1];

            for (double i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                string id = arr[0];
                double width = double.Parse(arr[1]);
                double height = double.Parse(arr[2]);
                double x = double.Parse(arr[3]);
                double y = double.Parse(arr[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);

                rectangles.Add(rectangle);
            }

            for (double i = 0; i < m; i++)
            {
                string[] ids = Console.ReadLine().Split();

                string f = ids[0];
                string s = ids[1];

                Rectangle first = rectangles.FirstOrDefault(x => x.Id == f);
                Rectangle second = rectangles.FirstOrDefault(x => x.Id == s);

                if (first.doubleersect(second))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
