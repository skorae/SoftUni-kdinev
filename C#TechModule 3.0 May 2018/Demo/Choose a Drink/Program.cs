using System;

namespace Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {
            string proff = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            switch (proff)
            {
                case "Athlete":
                    price = quantity * 0.70;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = quantity * 1;
                    break;
                case "SoftUni Student":
                    price = quantity * 1.70;
                    break;
                default:
                    price = quantity * 1.20;
                    break;
            }
            Console.WriteLine($"The {proff} has to pay {price:f2}.");
        }
    }
}
