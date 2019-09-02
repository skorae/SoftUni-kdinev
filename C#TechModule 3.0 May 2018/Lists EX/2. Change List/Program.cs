using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isTrue = true;
            int value = 0;
            int index = 0;
            while (isTrue)
            {
                List<string> comand = Console.ReadLine().Split().ToList();

                if (comand[0].Equals("Delete"))
                {
                    value = int.Parse(comand[1]);
                    input.RemoveAll(petar => petar.Equals(int.Parse(comand[1])));
                    //for (int i = 0; i < input.Count; i++)
                    //{
                    //    if (input[i] == value)
                    //    {
                    //        input.Remove(value);
                    //        i--;
                    //    }
                    //}
                }
                else if (comand[0].Equals("Insert"))
                {
                    value = int.Parse(comand[1]);
                    index = int.Parse(comand[2]);
                    input.Insert(index, value);
                }
                else if (comand[0].Equals("Odd"))
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 != 0)
                        {
                            Console.Write($"{input[i]} ");
                            
                        }
                    }
                    return;
                }
                else if (comand[0].Equals("Even"))
                {
                    for(int i = 0; i < input.Count; i++)
                    {
                        if (input[i] % 2 == 0)
                        {
                            Console.Write($"{input[i]} ");
                            
                        }
                    }
                    return;
                }
            }
        }
    }
}