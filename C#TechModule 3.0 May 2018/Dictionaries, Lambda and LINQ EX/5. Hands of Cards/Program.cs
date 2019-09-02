using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "JOKER")
                {
                    foreach (var kvp in players)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                }


                string[] input = line.Split(": ");
                List<string> results = new List<string>();
                results = input[1].Split(", ").ToList();

                if (players.ContainsKey(input[0]) == false)
                {
                    players.Add(input[0], results);
                }
                else if (players.ContainsKey(input[0]))
                {
                    foreach (var item in players[input[0]])
                    {
                        for (int i = 0; i < results.Count; i++)
                        {
                            if (item.Contains(results[i]) == false)
                            {
                                players[input[0]].Add(results[i]);
                            }
                        }
                    }
                }

                foreach (var item in collection)
                {

                }



            }
        }
    }
}
