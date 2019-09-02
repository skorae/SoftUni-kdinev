using System;
using System.Collections.Generic;
using System.Linq;

namespace Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                long start = 0;
                long count = 0;

                if (command[0].Equals("reverse") || command[0].Equals("sort"))
                {
                    start = long.Parse(command[2]);
                    count = long.Parse(command[4]);

                    if (start < 0 || start >= str.Length)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    if (start + count >= str.Length || start + count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                }
                else
                {
                    count = Count(command[1], str.Length);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine().Split();
                        continue;
                    }
                }

                switch (command[0])
                {
                    case "reverse":
                        for (int i = 0; i < count / 2; i++)
                        {
                            string temp = str[start + i];
                            str[start + i] = str[start + count - i - 1];
                            str[start + count - i - 1] = temp;

                        }
                        break;
                    case "sort":
                        List<string> sorted = new List<string>();
                        for (long i = start; i < count; i++)
                        {
                            sorted.Add(str[i]);
                        }
                        sorted.Sort();
                        for (int i = 0; i < sorted.Count; i++)
                        {
                            str[start + i] = sorted[i];
                        }
                        break;
                    case "rollLeft":
                        List<string> left = new List<string>();
                        left.AddRange(str);
                        for (int i = 0; i < count; i++)
                        {
                            string goLeft = left[0];
                            left.RemoveAt(0);
                            left.Add(goLeft);
                        }
                        for (int i = 0; i < str.Length; i++)
                        {
                            str[i] = left[i];
                        }
                        break;
                    case "rollRight":
                        List<string> right = new List<string>();
                        right.AddRange(str);
                        for (int i = 0; i < count; i++)
                        {
                            string goRight = right[right.Count - 1];
                            right.RemoveAt(right.Count - 1);
                            right.Insert(0, goRight);
                        }
                        for (int i = 0; i < right.Count; i++)
                        {
                            str[i] = right[i];
                        }
                        break;
                }

                command = Console.ReadLine().Split();
            }
            Console.WriteLine("[" + string.Join(", ", str) + "]");
        }

        private static int Count(string v, int lenght)
        {
            int count = int.Parse(v);
            while (count > lenght)
            {
                count -= lenght;
            }
            return count;
        }
    }
}
