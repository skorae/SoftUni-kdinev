using System;
using System.Collections.Generic;

namespace Problem_6._Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<string> remove = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length == 2)
                {
                    remove.Add(input[i]);
                }
            }
            
        }
    }
}
