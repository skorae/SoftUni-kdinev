using System;

namespace Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceGame = 0;
            string game = "";
            double totalSpent = 0;
            double balance = budget;

            while (budget > 0)
            {
                game = Console.ReadLine();


                if (game == "OutFall 4")
                {
                    priceGame = 39.99;
                }
                else if (game == "CS: OG")
                {
                    priceGame = 15.99;
                }
                else if (game == "Zplinter Zell")
                {
                    priceGame = 19.99;
                }
                else if (game == "Honored 2")
                {
                    priceGame = 59.99;
                }
                else if (game == "RoverWatch")
                {
                    priceGame = 29.99;
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    priceGame = 39.99;
                }
                else if (game == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
                    return;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    continue;
                }

                balance -= priceGame;

                if (balance >= 0)
                {
                    Console.WriteLine($"Bought {game}");
                }

                else if (priceGame > balance)
                {
                    Console.WriteLine("Too Expensive");
                    balance += priceGame;
                    continue;
                }
                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                totalSpent = budget - balance;
            }
        }
    }
}
