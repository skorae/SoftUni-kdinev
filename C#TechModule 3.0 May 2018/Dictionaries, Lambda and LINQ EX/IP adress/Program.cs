using System;
using System.Collections.Generic;
using System.Linq;

namespace IP_adress
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new SortedDictionary<string, Dictionary<string, int>>();
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string user = UserName(input);
                string IP = IPO(input);

                if (result.ContainsKey(user) == false)
                {
                    result.Add(user, new Dictionary<string, int>());
                    result[user].Add(IP, 1);
                }
                else if (result.ContainsKey(user))
                {
                    if (result[user].ContainsKey(IP) == false)
                    {
                        result[user].Add(IP, 1);
                    }
                    else
                    {
                        result[user][IP]++;
                    }
                }
            }
            foreach (var kvp in result)
            {
                var final = new List<string>();
                foreach (var item in result[kvp.Key])
                {
                    string output = $"{item.Key} => {item.Value}";
                    final.Add(output);
                }
                Console.WriteLine($"{kvp.Key}:");
                Console.WriteLine(string.Join(", ",final) + ".");
            }

        }
        static string IPO(string input)
        {
            string[] temp = input.Split();
            string tempIP = temp[0];
            string[] IP = tempIP.Split('=').ToArray();

            return IP[1];
        }
        static string UserName(string input)
        {
            string[] temp = input.Split();
            string tempIP = temp[2];
            string[] IP = tempIP.Split('=').ToArray();

            return IP[1];
        }
    }
}
