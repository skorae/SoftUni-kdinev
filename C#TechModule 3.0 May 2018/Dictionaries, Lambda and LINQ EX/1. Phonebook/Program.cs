using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                if (command[0] == "A")
                {
                    if (phoneBook.ContainsKey(command[1]) == false)
                    {
                        phoneBook.Add(command[1], command[2]);                       
                    }
                    phoneBook[command[1]] = command[2];
                }
                else if (command[0] == "S")
                {
                    if (phoneBook.ContainsKey(command[1]) == false)
                    {
                        Console.WriteLine($"Contact {command[1]} does not exist.");
                        continue;
                    }
                    foreach (var kvp in phoneBook)
                    {
                        if (kvp.Key.Contains(command[1]))
                        {
                            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                        }
                    }
                }
                else if (command[0] == "END")
                {
                    return;
                }
            }
        }
    }
}
