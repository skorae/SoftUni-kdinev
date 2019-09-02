using System;

namespace ConLoop_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string prof = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            string bev = Console.ReadLine();
            double price = 0;


            switch (prof)
            {
                case "Athlete":
                    bev = "Water";
                    price = quantity * 0.70;
                    Console.WriteLine($"The {prof} has to pay {price:F2}.");
                    break;
                case "Businessman":
                case "Businesswoman":
                    bev = "Coffee";
                    price = quantity * 1.0;
                    Console.WriteLine($"The {prof} has to pay {price:F2}.");
                    break;
                case "SoftUni Student":
                    bev = "Beer";
                    price = quantity * 1.70;
                    Console.WriteLine($"The {prof} has to pay {price:F2}.");
                    break;
                default:
                    bev = "Tea";
                    price = quantity * 1.20;
                    Console.WriteLine($"The {prof} has to pay {price:F2}.");
                    break;

            }
            
        }
    }
}
