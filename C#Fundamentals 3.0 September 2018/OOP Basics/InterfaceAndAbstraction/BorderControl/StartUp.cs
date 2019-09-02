using BorderControl.Factory;
using BorderControl.Things;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            CitizenFactory factory = new CitizenFactory();
            List<Buyer> buyers = new List<Buyer>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                factory.GetCitizen(arr, buyers);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var b in buyers)
                {
                    b.BuyFood(command);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
