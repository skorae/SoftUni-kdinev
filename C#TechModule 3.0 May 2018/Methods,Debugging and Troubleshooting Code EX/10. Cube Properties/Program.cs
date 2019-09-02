using System;

namespace _10._Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            double result = CubeProperties(n,type);

            Console.WriteLine($"{result:F2}");
        }
        static double CubeProperties(double n, string type)
        {
            double result = 0;

            if (type == "face")
            {
                result = Math.Sqrt(2) * n;
            }
            else if (type == "space")
            {
                result = Math.Sqrt(3) * n;
            }
            else if (type == "volume")
            {
                result = Math.Pow(n, 3);
            }
            else if (type == "area")
            {
                result = 6 * Math.Pow(n, 2);
            }
            return result;
        }
    }
}
