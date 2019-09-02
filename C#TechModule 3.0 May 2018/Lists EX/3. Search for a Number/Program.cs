using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> temp = new List<int>();
            int[] comands = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < comands[0]; i++)
            {
                temp.Add(numbers[i]);
            }
            while (comands[1] != 0)
            {
                temp.RemoveAt(0);
                comands[1]--;
            }
            for (int i = 0; i < temp.Count; i++)
            {
                if (comands[2] == temp[i])
                {
                    Console.WriteLine("YES!");
                    return;
                }
            }
            Console.WriteLine("NO!");
        }
    }
}
