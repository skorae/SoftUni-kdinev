using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
           var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(FilterArray(arr));
        }

        private static string FilterArray(int[] arr)
        {
            var result = new List<int>();
            var invalid = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (result.Contains(arr[i]))
                {
                    result.Add(arr[i]);
                    continue;
                }
                else if (invalid.Contains(arr[i]))
                {
                    continue;
                }

                var count = CountOccurrences(arr, arr[i], i);

                if (count % 2 == 0)
                {
                    result.Add(arr[i]);
                    continue;
                }

                invalid.Add(arr[i]);
            }

            return string.Join(" ", result);
        }

        private static int CountOccurrences(int[] arr, int value, int index)
        {
            var count = 0;

            for (int i = index; i < arr.Length; i++)
            {
                if (arr[i] == value)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
