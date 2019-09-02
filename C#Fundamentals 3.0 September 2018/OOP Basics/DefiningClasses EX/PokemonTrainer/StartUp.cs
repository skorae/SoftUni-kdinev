using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            string poke = Console.ReadLine();

            while (poke != "Tournament")
            {
                string[] arr = poke.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = arr[0];
                string pokemonName = arr[1].ToLower();
                string element = arr[2].ToLower();
                double health = double.Parse(arr[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, health);

                if (trainers.ContainsKey(trainerName) == false)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                    trainers[trainerName].Pokemons.Add(pokemon);
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(pokemon);
                }

                poke = Console.ReadLine();
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                if (command != "fire" && command != "electricity" && command != "water")
                {
                    command = Console.ReadLine();
                    continue;
                }
                foreach (var t in trainers)
                {
                    if (t.Value.Pokemons.Any(x => x.Element == command))
                    {
                        t.Value.Badges++;
                    }
                    else
                    {
                        foreach (var item in t.Value.Pokemons)
                        {
                            item.Health -= 10;
                        }
                    }
                    t.Value.Pokemons.RemoveWhere(x => x.Health <= 0);
                }
                command = Console.ReadLine().ToLower();
            }
            foreach (var k in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{k.Key} {k.Value.Badges} {k.Value.Pokemons.Count}");
            }
        }
    }
}
