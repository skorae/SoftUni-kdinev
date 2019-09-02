using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            List<int> sumPairs = new List<int>();
            while (true)
            {
                if (input == "print")
                {
                    break;
                }
                string[] commandsArr = input.Split();

                string command = commandsArr[0];

                if (command == "add")
                {
                    int index = int.Parse(commandsArr[1]);
                    int num = int.Parse(commandsArr[1]);
                    inputList.Insert(index, num);
                }
                else if (command == "addMany")
                {
                    int index = int.Parse(commandsArr[1]);
                    List<int> elementToInsert = new List<int>();

                    for (int i = 2; i < commandsArr.Length; i++)
                    {
                        elementToInsert.Add(int.Parse(commandsArr[i]));
                    }
                    List<int> currentResult = new List<int>();
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (inputList[i] != index)
                        {
                            currentResult.Add(inputList[i]);
                        }
                        else
                        {
                            currentResult.AddRange(elementToInsert);
                        }
                    }
                }
                else if (command == "contains")
                {
                    if (!inputList.Contains(int.Parse(commandsArr[1])))
                    {
                        Console.WriteLine(-1);

                    }
                    else
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList.Contains(int.Parse(commandsArr[1])))
                            {
                                Console.WriteLine(i);
                                break;
                            }
                        }
                    }
                }
                else if (command == "remove")
                {
                    inputList.RemoveAt(int.Parse(commandsArr[1]));
                }
                else if (command == "shift")
                {
                    for (int i = 0; i < int.Parse(commandsArr[1]); i++)
                    {
                        ShiftElements(inputList);
                    }
                }
                else if (command == "sumPairs")
                {
                    int sum = 0;


                    if (inputList.Count % 2 == 0)
                    {
                        for (int i = 0; i < inputList.Count; i += 2)
                        {
                            sum += inputList[i] + inputList[i + 1];
                            sumPairs.Add(sum);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < inputList.Count - 2; i += 2)
                        {
                            sum += inputList[i] + inputList[i + 1];
                            sumPairs.Add(sum);
                        }
                        sumPairs.Add(input[inputList.Count - 1]);
                        inputList = sumPairs;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(" ", sumPairs) + "]");
        }
        static void ShiftElements(List<int> inputList)
        {
            int[] array = new int[inputList.Count];
            array[array.Length - 1] = inputList[0];
            for (int i = array.Length - 2; i >= 0; i--)
            {
                array[i] = inputList[i + 1];
            }
            for (int i = 0; i < array.Length; i++)
            {
                inputList[i] = array[i];
            }
        }
    }
}
