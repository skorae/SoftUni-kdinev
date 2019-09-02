using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_5._Parking_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();
            Regex regex = new Regex(@"\b[A-Z]{2}[0-9]{4}[A-Z]{2}\b");

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string user = input[1];
                string regNum = "";

                if (input.Length > 2)
                {
                    regNum = input[2];
                }

                switch (command)
                {
                    case "register":
                        if (users.ContainsKey(user) && users[user] != regNum)
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {users[user]}");
                        }
                        else if (regex.IsMatch(regNum) == false)
                        {
                            Console.WriteLine($"ERROR: invalid license plate {regNum}");
                        }
                        else if (users.ContainsValue(regNum) && users.ContainsKey(user) == false)
                        {
                            Console.WriteLine($"“ERROR: license plate {regNum} is busy”");
                        }
                        else
                        {
                            users.Add(user, regNum);
                            Console.WriteLine($"{user} registered {regNum} successfully");
                        }
                        break;
                    case "unregister":
                        if (users.ContainsKey(user) == false)
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        else
                        {
                            Console.WriteLine($"user {user} unregistered successfully");
                            users.Remove(user);
                        }
                        break;
                }
            }
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Key} => {u.Value}");
            }
        }
    }
}
