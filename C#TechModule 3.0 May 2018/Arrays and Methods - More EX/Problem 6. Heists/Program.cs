using System;

namespace Problem_6._Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lootPrices = Console.ReadLine().Split();
            int jewelPrice = int.Parse(lootPrices[0]);
            int goldPrice = int.Parse(lootPrices[1]);
            long average = 0;

            while (true)
            {
                string[] income = Console.ReadLine().Split();
                if (income[0] == "Jail" && income[1] ==  "Time")
                {
                    if (average >= 0)
                    {
                        Console.WriteLine($"Heists will continue. Total earnings: {average}.");
                    }
                    else
                    {
                        Console.WriteLine($"Have to find another job. Lost: {Math.Abs(average)}.");
                    }
                    return;
                }

                int expenses = int.Parse(income[1]);
                int jewels = 0;
                int gold = 0;
                
                foreach (var item in income[0])
                {
                    if (item == '%')
                    {
                        jewels++;
                    }
                    else if (item == '$')
                    {
                        gold++;
                    }
                }
                average += ((jewelPrice * jewels) + (gold * goldPrice)) - expenses;
            }
        }
    }
}
