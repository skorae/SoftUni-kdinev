using System;

namespace Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal lenght = decimal.Parse(Console.ReadLine());
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());

            Console.Write($"Length: ");
            Console.Write($"Width: ");
            Console.Write($"Height: ");

            decimal V = (0.33333333333m) * (lenght * width * height);
            Console.WriteLine("Pyramid Volume: {0:f2}", V);

        }
    }
}
