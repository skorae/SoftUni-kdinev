using System;

namespace NestedLoops
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];

            PrintNestedLoops(0);
        }

        private static void PrintNestedLoops(int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                PrintNestedLoops(index + 1);
            }
        }
    }
}
