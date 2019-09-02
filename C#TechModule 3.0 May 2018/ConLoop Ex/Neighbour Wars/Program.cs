using System;

namespace Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int pDMG = int.Parse(Console.ReadLine());
            int gDMG = int.Parse(Console.ReadLine());
            int peshoHP = 100;
            int goshoHP = 100;
            int count = 0;
            string attacker = "";
            string deffender = "";
            string attack = "";
            string winner = "";
            int remains = 0;

            while (peshoHP > 0 && goshoHP > 0)
            {
                count++;

                if (count % 2 == 1)
                {
                    attacker = "Pesho";
                    attack = "Roundhouse kick";
                    deffender = "Gosho";
                    goshoHP -= pDMG;
                    remains = goshoHP;
                }
                else
                {
                    attacker = "Gosho";
                    attack = "Thunderous fist";
                    deffender = "Pesho";
                    peshoHP -= gDMG;
                    remains = peshoHP;
                }
                if (peshoHP > 0 && goshoHP > 0)
                {
                    Console.WriteLine($"{attacker} used {attack} and reduced {deffender} to {remains} health.");
                }
                if (count % 3 == 0 && peshoHP > 0 && goshoHP > 0)
                {
                    peshoHP += 10;
                    goshoHP += 10;
                }

            }
            if (peshoHP <= 0)
            {
                winner = "Gosho";
            }
            else
            {
                winner = "Pesho";
            }
            Console.WriteLine($"{winner} won in {count}th round.");
        }
    }
}
