using System;

namespace Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            double energy100 = double.Parse(Console.ReadLine());
            double sugar100 = double.Parse(Console.ReadLine());

            double allEnergy = volume * (energy100 / 100);
            double totalSugar = volume * (sugar100 / 100);

            Console.WriteLine(volume + "ml " + name + ":");
            Console.WriteLine(allEnergy + "kcal, " + totalSugar + "g sugars");

        }
    }
}
