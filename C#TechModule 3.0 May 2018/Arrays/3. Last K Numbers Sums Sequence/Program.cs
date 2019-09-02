using System;

namespace _3._Last_K_Numbers_Sums_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                numbers[i] = int.Parse(data[i]);
            }
        }
    }
}
