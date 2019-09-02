using System;
using System.Linq;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(LinearSearch(arr, number));
           // Console.WriteLine(BinarySearch(arr, number, arr.Length / 2));
        }

        private static int BinarySearch(int[] arr, int number, int index)
        {
            if (arr[index] == number)
            {
                return index;
            }

            if (index == 0 || index >= arr.Length)
            {
                return -1;
            }
            else if (arr[index] > number)
            {
                return BinarySearch(arr, number, index / 2);
            }
            else
            {
                return BinarySearch(arr, number, index + (index / 2));
            }
        }

        private static int LinearSearch(int[] arr, int number)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
