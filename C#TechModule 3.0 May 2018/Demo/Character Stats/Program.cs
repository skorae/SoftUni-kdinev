using System;

namespace Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int healthMax = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int energyMax = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");

            Console.Write("Health: |");
            for (int i = 1; i <= healthMax; i++)
            {
                if (i <= currentHealth)
                {
                    Console.Write("|");
                    continue;
                }
                Console.Write(".");
            }
            Console.Write("|\nEnergy: |");

            for (int i = 1; i <= energyMax; i++)
            {
                if (i <= currentEnergy)
                {
                    Console.Write("|");
                    continue;
                }
                Console.Write(".");
            }
            Console.Write("|");
        }
    }
}
