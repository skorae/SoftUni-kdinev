using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            HashSet<string> set = new HashSet<string>();
            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            while (data != "end of contests")
            {
                string[] arr = data.Split(":");

                if (set.Contains(data) == false)
                {
                    set.Add(arr[0] + " " + arr[1]);
                }
                data = Console.ReadLine();
            }

            data = Console.ReadLine();

            while (data != "end of submissions")
            {
                string[] arr = data.Split("=>");
                string contest = arr[0];
                string pass = arr[1];
                string name = arr[2];
                int points = int.Parse(arr[3]);

                string temp = contest + " " + pass;

                if (set.Contains(temp) == false)
                {
                    data = Console.ReadLine();
                    continue;
                }
                else if (dictionary.ContainsKey(name) == false)
                {
                    dictionary.Add(name, new Dictionary<string, int>());
                    dictionary[name].Add(contest, points);
                    data = Console.ReadLine();
                    continue;
                }
                else if (dictionary.ContainsKey(name))
                {
                    if (dictionary[name].ContainsKey(contest) == false)
                    {
                        dictionary[name].Add(contest, points);
                    }
                    else
                    {
                        if (dictionary[name][contest] < points)
                        {
                            dictionary[name][contest] = points;
                        }
                    }
                }

                data = Console.ReadLine();
            }

            string bestName = "";
            int bestResult = 0;

            foreach (var k in dictionary)
            {
                int temp = 0;
                foreach (var v in k.Value)
                {
                    temp += v.Value;
                }
                if (temp > bestResult)
                {
                    bestResult = temp;
                    bestName = k.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestResult} points.");
            Console.WriteLine("Ranking:");

            foreach (var k in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine(k.Key);
                foreach (var v in k.Value.OrderByDescending(y => y.Value))
                {
                    Console.WriteLine($"#  {v.Key} -> {v.Value}");
                }
            }

        }
    }
}
