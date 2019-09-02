using System;

namespace Cake_Ingridients
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string add = "";

            while (n <= 20 && add != "Bake!")
            {
                add = Console.ReadLine();
                if (add == "Bake!")
                {
                    Console.WriteLine($"Preparing cake with {n} ingredients.");
                    return;
                }
                Console.WriteLine($"Adding ingredient {add}.");
                n++;
            }           
        }
    }
}
