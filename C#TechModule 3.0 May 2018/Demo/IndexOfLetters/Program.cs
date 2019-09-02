using System;
using System.Linq;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] arr = new char[input.Length];

            arr = input.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} -> {arr[i] - 97}");
            }
        }
    }
}
