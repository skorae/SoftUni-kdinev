using System;
using System.Linq;

namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            PrintReverse(0, arr);
        }

        private static void PrintReverse(int index, int[] arr)
        {
            if (index == arr.Length)
            {
                return;
            }
            else
            {
                PrintReverse(index + 1, arr);
                Console.Write(arr[index] + " ");
            }
        }
    }
}
