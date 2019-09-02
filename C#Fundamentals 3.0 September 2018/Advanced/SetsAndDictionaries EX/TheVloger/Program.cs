using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVloger
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            var vlogers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (data != "Statistics")
            {
                string[] arr = data.Split();
                string vloger = arr[0];
                string command = arr[1];
                string followed = arr[2];

                switch (command)
                {
                    case "joined":
                        if (vlogers.ContainsKey(vloger) == false)
                        {
                            vlogers.Add(vloger, new Dictionary<string, SortedSet<string>>());
                            vlogers[vloger].Add("followers", new SortedSet<string>());
                            vlogers[vloger].Add("following", new SortedSet<string>());
                        }
                        break;
                    case "followed":
                        if (vlogers.ContainsKey(vloger) == false || vlogers.ContainsKey(followed) == false || vloger == followed)
                        {
                            data = Console.ReadLine();
                            continue;
                        }
                        vlogers[followed]["followers"].Add(vloger);
                        vlogers[vloger]["following"].Add(followed);
                        break;
                }


                data = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogers.Keys.Count} vloggers in its logs.");
            int count = 1;

            

            foreach (var v in vlogers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(f => f.Value["following"].Count))
            {
                Console.WriteLine($"{count}. {v.Key} : {v.Value["followers"].Count} followers, {v.Value["following"].Count} following");
                if (count == 1)
                {
                    foreach (var f in v.Value["followers"])
                    {
                        Console.WriteLine($"*  {f}");
                    }
                }
                count++;
            }
        }
    }
}
