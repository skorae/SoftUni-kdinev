using System;

namespace Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numItems = int.Parse(Console.ReadLine());
            double subTotal = 0;

            for (int i = 0; i < numItems; i++)
            {
                string nameItem = Console.ReadLine();
                double priceItem = double.Parse(Console.ReadLine());
                int countItem = int.Parse(Console.ReadLine());

                if (countItem > 1)
                {                  
                    Console.WriteLine($"Adding {countItem} {nameItem}s to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {countItem} {nameItem} to cart.");
                }

                subTotal += priceItem * countItem;
            }
            double diff = Math.Abs(budget - subTotal);

            if (budget >= subTotal)
            {
                Console.WriteLine($"Subtotal: ${subTotal:f2}");
                Console.WriteLine($"Money left: ${diff:f2}");
            }
            else
            {
                Console.WriteLine($"Subtotal: ${subTotal:f2}");
                Console.WriteLine($"Not enough. We need ${diff:f2} more.");
            }
        }
    }
}
