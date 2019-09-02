using System;
using System.Collections.Generic;

namespace Problem_3._Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = int.Parse(Console.ReadLine());
            double temp = health;
            Dictionary<string, int> dataBase = new Dictionary<string, int>();

            while (true)
            {
                string virus = Console.ReadLine();
                if (virus == "end")
                {
                    Console.WriteLine($"Final Health: {temp}");
                    return;
                }
                int sum = 0;
                int attackVirusTime = 0; ;
                if (dataBase.ContainsKey(virus) == false)
                {
                    dataBase.Add(virus, 0);

                    foreach (var c in virus)
                    {
                        sum += c;
                    }
                    dataBase[virus] = sum / 3;
                    attackVirusTime = dataBase[virus] * virus.Length;
                }
                else
                {
                    attackVirusTime = (dataBase[virus] * virus.Length) / 3;
                }

                Console.WriteLine($"Virus {virus}: {dataBase[virus]} => {attackVirusTime} seconds");

                temp -= attackVirusTime;
                if (temp >= 0)
                {
                    int minutes = 0;
                    int seconds = 0;
                    if (attackVirusTime < 59)
                    {
                        seconds = attackVirusTime;
                        Console.WriteLine($"{virus} defeated in {minutes}m {seconds}s.");
                    }
                    else
                    {
                        minutes = attackVirusTime / 60;
                        seconds = attackVirusTime % 60;
                        Console.WriteLine($"{virus} defeated in {minutes}m {seconds}s.");
                    }
                    Console.WriteLine($"Remaining health: {temp}");

                    temp = Math.Floor(temp * 1.20);
                    if (temp > health)
                    {
                        temp = health;
                    }
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
            }
        }
    }
}
