using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> command = new List<string>();

            while (true)
            {
                command = Console.ReadLine().Split().ToList();

                switch (command[0])
                {
                    case "add":
                        numList.Insert(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "addMany":
                        for (int i = command.Count - 1; i >= 2; i--)
                        {
                            numList.Insert(int.Parse(command[1]), int.Parse(command[i]));
                        }
                        break;
                    case "contains":
                        bool isTrue = false;
                        for (int i = 0; i < numList.Count; i++)
                        {
                            if (numList[i] == int.Parse(command[1]))
                            {
                                Console.WriteLine(i);
                                isTrue = false;
                                break;
                            }
                            isTrue = true;
                        }
                        if (isTrue)
                        {
                            Console.WriteLine(-1);
                        }
                        break;
                    case "remove":
                        numList.RemoveAt(int.Parse(command[1]));
                        break;
                    case "shift":
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            numList.Add(numList[0]);
                            numList.RemoveAt(0);
                        }
                        break;
                    case "sumPairs":
                        List<int> sum = new List<int>();
                        if (numList.Count % 2 == 0)
                        {
                            for (int i = 0; i < numList.Count - 1; i += 2)
                            {
                                sum.Add(numList[i] + numList[i + 1]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < numList.Count - 2; i += 2)
                            {
                                sum.Add(numList[i] + numList[i + 1]);
                            }
                            sum.Add(numList[numList.Count - 1]);
                        }
                        numList = sum;
                        break;
                    case "print":
                        Console.WriteLine("[" + string.Join(", ", numList) + "]");
                        return;
                }
            }
        }
    }
}
