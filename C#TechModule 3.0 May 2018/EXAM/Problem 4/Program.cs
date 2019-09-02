using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var contestents = new Dictionary<string, int>();
            var progLa = new Dictionary<string, int>();

            while (input[0] != "exam finished")
            {
                string name = input[0];
                string language = input[1];
                if (contestents.ContainsKey(name) && language == "banned")
                {
                    contestents.Remove(name);
                    input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                int result = int.Parse(input[2]);

                if (progLa.ContainsKey(language) == false)
                {
                    progLa.Add(language, 1);
                }
                else
                {
                    progLa[language]++;
                }
                if (contestents.ContainsKey(name)==false)
                {
                    contestents.Add(name,result);
                }
                else
                {
                    if (contestents[name] < result)
                    {
                        contestents[name] = result;
                    }
                }
                input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Results:");
            foreach (var name in contestents.OrderByDescending(k => k.Value).ThenBy(r =>r.Key))
            {
                Console.WriteLine($"{name.Key} | {name.Value}");
            }
            Console.WriteLine($"Submissions:");
            foreach (var lang in progLa.OrderByDescending(k => k.Value).ThenBy(r => r.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
        }
    }
}
