using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_4._Cahracter_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] word = Console.ReadLine().Split();

            List<char> first = StringToChar(word[0]);
            List<char> second = StringToChar(word[1]);

            int min = Math.Min(first.Count, second.Count);
            int max = Math.Max(first.Count, second.Count);
            int sum = 0;

            if (first.Count <= second.Count)
            {
                for (int i = 0; i < min; i++)
                {
                    int temp = first[i] * second[i];
                    sum += temp;
                }
                for (int y = min; y < max; y++)
                {
                    sum += second[y];
                }
            }
            else
            {
                for (int i = 0; i < min; i++)
                {
                    int temp = first[i] * second[i];
                    sum += temp;
                }
                for (int y = min; y < max; y++)
                {
                    sum += first[y];
                }
            }

            Console.WriteLine(sum);
        }

        private static List<char> StringToChar(string word)
        {
            List<char> temp = new List<char>();

            foreach (var c in word)
            {
                temp.Add(c);
            }
            return temp;
        }
    }
}