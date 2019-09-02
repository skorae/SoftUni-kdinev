using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").Select(x => x).ToList();

            string[] @do = Console.ReadLine().Split(":");

            while (@do[0] != "course start")
            {
                string command = @do[0];
                string name = @do[1];


                switch (command)
                {
                    case "Add":
                        if (lessons.Contains(name) == false)
                        {
                            lessons.Add(name);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(@do[2]);
                        if (lessons.Contains(name) == false && index >=0 && index <= lessons.Count)
                        {
                            
                            lessons.Insert(index, name);
                        }

                        break;
                    case "Remove":
                        lessons.Remove(name);
                        if (lessons.Contains($"{name}-Exersice"))
                        {
                            lessons.Remove($"{name}-Exersice");
                        }
                        break;
                    case "Swap":
                        string lesToSwap = @do[2];
                        if (lessons.Contains(name) && lessons.Contains(lesToSwap))
                        {
                            string temp = name;
                            int lesIndex = lessons.IndexOf(lesToSwap);
                            int nameIndex = lessons.IndexOf(name);
                            lessons[nameIndex] = lesToSwap;
                            lessons[lesIndex] = temp;
                            if (lessons.Contains($"{name}-Exercise"))
                            {
                                string nameEx = $"{name}-Exercise";
                                lessons.Remove(nameEx);
                                lessons.Insert(lessons.IndexOf(name) + 1, nameEx);
                            }
                            if (lessons.Contains($"{lesToSwap}-Exercise"))
                            {
                                string lesEX = $"{lesToSwap}-Exercise";
                                lessons.Remove(lesEX);
                                lessons.Insert(lessons.IndexOf(lesToSwap) + 1, lesEX);
                            }

                        }
                        break;
                    case "Exercise":
                        string EX = $"{name}-Exercise";

                        if (lessons.Contains(name) == false)
                        {
                            lessons.Add(name);
                            lessons.Add(EX);
                        }

                        if (lessons.Contains(EX) == false)
                        {
                            int s = lessons.IndexOf(name);
                            if (s == lessons.Count - 1)
                            {
                                lessons.Add(EX);
                            }
                            else
                            {
                                lessons.Insert(s + 1, EX);
                            }
                        }

                        break;
                }
                @do = Console.ReadLine().Split(":");
            }
            int count = 1;
            foreach (var item in lessons)
            {
                Console.WriteLine($"{count}.{item}");
                count++;
            }
        }
    }
}
