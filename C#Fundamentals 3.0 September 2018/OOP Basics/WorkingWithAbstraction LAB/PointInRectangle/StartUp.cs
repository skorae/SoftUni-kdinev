using System;
using System.Linq;

namespace PointInRectangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] rec = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int topLeftX = rec[0];
            int topLeftY = rec[1];
            int bottomRightX = rec[2];
            int bottomRightY = rec[3];
            int n = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

            for (int i = 0; i < n; i++)
            {
                int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int x = coordinates[0];
                int y = coordinates[1];


                Console.WriteLine(Contains(x,y,rectangle));
            }
        }

        public static bool Contains(int x, int y, Rectangle rectangle)
        {
            bool isInside = false;

            if (x >= rectangle.TopLeftX && x <= rectangle.BottomRightX)
            {
                if (y >= rectangle.TopLeftY && y <= rectangle.BottomRightY)
                {
                    isInside = true;
                }
            }
            else if (y >= rectangle.TopLeftY && y <= rectangle.BottomRightY)
            {
                if (x >= rectangle.TopLeftX && x <= rectangle.BottomRightX)
                {
                    isInside = true;
                }
            }

            return isInside;
        }
    }
}
