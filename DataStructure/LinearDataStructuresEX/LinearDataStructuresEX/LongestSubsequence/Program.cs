using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(Subsequence(arr));
        }

        private static string Subsequence(List<int> arr)
        {
            int longestCount = 0;
            int longestNumber = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                int currentCount = 0;
                int currentNumber = arr[i];

                for (int y = i; y < arr.Count; y++)
                {
                    currentCount++;

                    if (y == arr.Count - 1)
                    {
                        i = y;
                        break;
                    }

                    if (currentNumber != arr[y + 1])
                    {
                        i = y;
                        break;
                    }
                }

                if (currentCount > longestCount)
                {
                    longestCount = currentCount;
                    longestNumber = currentNumber;
                }
            }

            var result = new List<int>();

            for (int i = 0; i < longestCount; i++)
            {
                result.Add(longestNumber);
            }

            return string.Join(" ", result);
        }
    }
}
