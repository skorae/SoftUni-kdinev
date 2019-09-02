using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            Regex name = new Regex(@"[a-zA-z0-9-\+\.\*\/]+");
            MatchCollection names = name.Matches(n);
            List<string> input = new List<string>();

            foreach (var i in names)
            {
                input.Add(i.ToString());
            }

            Regex healthPat = new Regex(@"[^0-9\+\-\*\/\.]");
            Regex dmgPat = new Regex(@"\+?\-?[\d+\.?\d?]+");

            List<Demon> demons = new List<Demon>();
            for (int i = 0; i < input.Count; i++)
            {
                int health = Health(healthPat, input[i]);
                double damage = Damage(dmgPat, input[i]);

                Demon demon = demons.FirstOrDefault(d => d.Name == input[i]);

                if (demon == null)
                {
                    demons.Add(new Demon(input[i], health, damage));
                }
                else
                {
                    demon.Health = health;
                    demon.Damage = damage;
                }
            }

            foreach (var item in demons.OrderBy(d => d.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Health} health, {item.Damage:f2} damage");
            }
        }

        private static double Damage(Regex dmgPat, string v)
        {
            double dmg = 0.0;
            int multiply = 0;
            int divide = 0;

            foreach (var c in v)
            {
                if (c == '*')
                {
                    multiply++;
                }
                else if (c == '/')
                {
                    divide++;
                }
            }

            MatchCollection matches = dmgPat.Matches(v);

            foreach (Match item in matches)
            {
                dmg += double.Parse(item.Value);
            }
            if (multiply != 0)
            {
                for (int i = 0; i < multiply; i++)
                {
                    dmg *= 2;
                }
            }
            if (divide != 0)
            {
                for (int i = 0; i < divide; i++)
                {
                    dmg /= 2;
                }
            }

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

    class Demon
    {
        public Demon(string name, double health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; set; }
        public double Health { get; set; }
        public double Damage { get; set; }
    }
}
