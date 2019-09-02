using System;

namespace _12._Rectangle_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double perimeter = 2 * a + 2 * b;
            double area = a * b;
            double diagonal = 0.0;
            diagonal = Math.Sqrt((a * a) + (b * b));

            Console.WriteLine($"{perimeter}");
            Console.WriteLine($"{area}");
            Console.WriteLine($"{diagonal}");
        }
    }
}
