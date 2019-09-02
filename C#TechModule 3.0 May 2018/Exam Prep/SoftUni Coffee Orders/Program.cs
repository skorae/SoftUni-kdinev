using System;
using System.Globalization;

namespace SoftUni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            decimal total = 0;

            for (int i = 0; i < orders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                long capsulesCount = long.Parse(Console.ReadLine());

                decimal price = (daysInMonth * capsulesCount) * pricePerCapsule;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                total += price;
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
