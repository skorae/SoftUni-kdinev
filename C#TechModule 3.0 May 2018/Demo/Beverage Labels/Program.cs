using System;

namespace Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double sugar = double.Parse(Console.ReadLine());

            double totalEnergy = volume * (energy/100);
            double totalSugar = volume * (sugar / 100);

            Console.WriteLine($"{volume}ml {name}:\n{totalEnergy}kcal, {totalSugar}g sugars");
        }
    }
}
