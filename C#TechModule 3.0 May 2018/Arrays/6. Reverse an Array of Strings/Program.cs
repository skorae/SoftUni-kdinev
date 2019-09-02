using System;
using System.Linq;

namespace _6._Reverse_an_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < input.Length / 2; i++)
            {
                string oldElemnet = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = oldElemnet;

            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
