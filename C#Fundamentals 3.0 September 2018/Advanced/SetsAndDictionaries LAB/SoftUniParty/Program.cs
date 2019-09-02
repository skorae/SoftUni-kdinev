using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {

            string data = Console.ReadLine();

            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (data != "PARTY")
            {
                if (Char.IsDigit(data[0]))
                {
                    vip.Add(data);
                }
                else
                {
                  regular.Add(data);
                }
                data = Console.ReadLine();
            }
            data = Console.ReadLine();

            while (data != "END")
            {
                if (Char.IsDigit(data[0]))
                {
                    vip.Remove(data);
                }
                else
                {
                    regular.Remove(data);
                }
                data = Console.ReadLine();
            }
            Console.WriteLine(vip.Count + regular.Count);

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}
