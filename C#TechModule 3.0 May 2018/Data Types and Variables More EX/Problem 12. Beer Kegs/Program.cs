using System;

namespace Problem_12._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            string model = "";
            decimal volume = 0m;

            while (n > 0)
            {
                string curentModel = Console.ReadLine();
                decimal radius = decimal.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                decimal temp = (decimal)Math.PI * (radius * radius) * height;

                if (volume <= temp)
                {
                    volume = temp;
                    model = curentModel;
                }

                n--;
            }
            Console.WriteLine($"{model}");
        }
    }
}
