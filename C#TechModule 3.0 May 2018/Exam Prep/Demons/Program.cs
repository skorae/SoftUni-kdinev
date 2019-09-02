using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Demons
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] n = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            Regex healthPat = new Regex(@"[A-Za-z]");
            Regex dmgPat = new Regex(@"\-?[\d+\.?\d?]+");

            var deamons = new SortedDictionary<string, Dictionary<int, double>>();

            for (int i = 0; i < n.Length; i++)
            {
                int health = Health(healthPat, n[i]);
                double damage = Damage(dmgPat, n[i]);

                if (deamons.ContainsKey(n[i]) == false)
                {
                    deamons.Add(n[i], new Dictionary<int, double>());
                    deamons[n[i]].Add(health, damage);
                }
            }
            foreach (var k in deamons)
            {
                foreach (var item in k.Value)
                {
                    Console.WriteLine($"{k.Key} - {item.Key} health, {item.Value:f2} damage");
                }
            }
        }

        private static double Damage(Regex dmgPat, string v)
        {
            double dmg = 0.0;
            double multiply = 0;
            double divide = 0;

            multiply = v.Count(c => c == '*');
            divide = v.Count(c => c == '/');

            MatchCollection matches = dmgPat.Matches(v);
            foreach (Match item in matches)
            {
                dmg += double.Parse(item.ToString());
            }
            dmg *= Math.Pow(2, multiply);
            dmg /= Math.Pow(2, divide);

            return dmg;
        }

        private static int Health(Regex healthPat, string v)
        {
            int sum = 0;

            MatchCollection matches = healthPat.Matches(v);
            foreach (Match item in matches)
            {
                sum += item.Value[0];
            }

            return sum;
        }
    }
}