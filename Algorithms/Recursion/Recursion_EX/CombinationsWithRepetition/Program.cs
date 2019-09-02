using System;

namespace CombinationsWithRepetition
{
    class Program
    {
        static int count;
        static int cols;
        static int[] arr;

        static void Main(string[] args)
        {
            count = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            arr = new int[cols];

            GenerateRepetitions(0,1);
        }

        private static void GenerateRepetitions(int index, int currentNumber)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = currentNumber; i <= count; i++)
            {
                arr[index] = i;
                GenerateRepetitions(index + 1, i);
            }
        }
    }
}
