using System;

namespace Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = Console.ReadLine();
            int curHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int curEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: " + name);
            Console.WriteLine($"Health: |" + new string('|', curHealth) + new string('.', maxHealth - curHealth) + "|");
            Console.WriteLine($"Energy: |" + new string('|', curEnergy) + new string('.', maxEnergy - curEnergy) + "|");

        }
    }
}
