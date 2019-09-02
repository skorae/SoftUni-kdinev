using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._A_Miner_Task
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> comodity = new Dictionary<string, int>();

            while (true)
            {
                string type = Console.ReadLine();
                if (type == "stop")
                {
                    foreach (var kvp in comodity)
                    {
                        var result = $"{kvp.Key} -> {kvp.Value}";
                        Console.WriteLine(result);
                    }
                    return;
                }

                int value = int.Parse(Console.ReadLine());

                if (comodity.ContainsKey(type) == false)
                {
                    comodity.Add(type, value);
                }
                else
                {
                    comodity[type] += value;
                }
            }

        }
    }
}
