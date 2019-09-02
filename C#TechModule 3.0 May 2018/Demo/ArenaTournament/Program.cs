using System;

namespace ArenaTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            string arena = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();
            string itemQuality = Console.ReadLine().ToLower();

            double discount = 0;
            double allItemPrice = 0;
            double pricePerItem = 0;


            switch (arena)
            {
                case "nagrand":
                    if (day.Equals("monday") || day.Equals("wednesday"))
                    {
                        discount = 0.05;
                    }
                    break;
                case "gurubashi":
                    if (day.Equals("tuesday") || day.Equals("thursday"))
                    {
                        discount = 0.1;
                    }
                    break;
                case "dire maul":
                    if (day.Equals("friday") || day.Equals("saturday"))
                    {
                        discount = 0.07;
                    }
                    break;
            }

            switch (itemQuality)
            {
                case "poor":
                    allItemPrice = 7000 - (7000 * discount);
                    break;
                case "normal":
                    allItemPrice = 14000 - (14000 * discount);
                    break;
                case "legendary":
                    allItemPrice = 21000 - (21000 * discount);
                    break;
            }

            pricePerItem = allItemPrice / 5;
            int itemsBought = (int)(points / pricePerItem);

            if (itemsBought > 5)
            {
                itemsBought = 5;
            }

            double diff = Math.Abs(points - (pricePerItem * itemsBought));

            if (points >= allItemPrice)
            {
                Console.WriteLine($"Items bought: {itemsBought}");
                Console.WriteLine($"Arena points left: {diff}");
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine($"Items bought: {itemsBought}");
                Console.WriteLine($"Arena points left: {diff}");
                Console.WriteLine("Failure!");
            }
        }
    }
}
