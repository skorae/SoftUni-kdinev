using System;
using System.Linq;

namespace Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = new int[int.Parse(Console.ReadLine())];
            long[] index = Console.ReadLine().Split().Select(long.Parse).ToArray();

            foreach (var i in index)
            {
                if (i >= 0 && i < n.Length)
                {
                    n[i] = 1;
                }
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                long startIndex = int.Parse(command[0]);
                string direction = command[1];
                long count = int.Parse(command[2]);

                if (startIndex >= 0 && startIndex < n.Length)
                {
                    if (n[startIndex] == 1)
                    {
                        n[startIndex] = 0;

                        switch (direction)
                        {
                            case "right":
                                for (int i = 0; i < 1; i++)
                                {
                                    if (startIndex + count < n.Length && startIndex + count >= 0)
                                    {
                                        if (n[startIndex + count] == 0)
                                        {
                                            n[startIndex + count] = 1;
                                        }
                                        else
                                        {
                                            startIndex += count;
                                            i--;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 0; i < 1; i++)
                                {
                                    if (startIndex - count < n.Length && startIndex - count >= 0)
                                    {
                                        if (n[startIndex - (count)] == 0)
                                        {
                                            n[startIndex - (count)] = 1;
                                        }
                                        else
                                        {
                                            startIndex -= count;
                                            i--;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", n));
        }
    }
}
