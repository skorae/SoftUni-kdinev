using System;

namespace Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenghts = int.Parse(Console.ReadLine());

            double mega = ((widht * lenghts) * 1.0) / 1000000;

            Console.WriteLine($"{widht}x{lenghts} => {Math.Round(mega,1)}MP");
        }
    }
}
