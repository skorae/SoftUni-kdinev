using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "stop")
                {
                    foreach (var kvp in emails)
                    {
                        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }
                    return;
                }
                string addres = Console.ReadLine();

                if (addres.EndsWith("us") || addres.EndsWith("UK"))
                {
                    continue;
                }
                else
                {
                    emails.Add(name, addres);
                }
            }
        }
    }
}
