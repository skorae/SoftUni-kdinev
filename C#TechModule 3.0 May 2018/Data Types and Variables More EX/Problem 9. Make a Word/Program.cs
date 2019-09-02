using System;
using System.Collections.Generic;

namespace Problem_9._Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            List<char> @chars = new List<char>();

            for (sbyte i = 0; i < n; i++)
            {
                chars.Add(char.Parse(Console.ReadLine()));
            }
            string result = string.Join("", chars);

            Console.WriteLine($"The word is: {result}");
        }
    }
}
