using MilitaryElite.Factory;
using MilitaryElite.Objects;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            SoldierFactory factory = new SoldierFactory();
            List<Soldier> soldiers = new List<Soldier>();

            while (command != "End")
            {
                string[] arr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                factory.SortSoldiers(arr,soldiers);

                command = Console.ReadLine();
            }

            foreach (var s in soldiers)
            {
                Console.WriteLine(s);
            }
        }
    }
}
