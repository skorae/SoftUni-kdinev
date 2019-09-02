using System;

namespace CombinationsWithoutrepetitions
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

            Combine(0, 0);
        }

        private static void Combine(int index, int currentNumber)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = currentNumber + 1; i <= count; i++)
            {
                arr[index] = i;
                Combine(index + 1, i);
            }
        }
    }
}
