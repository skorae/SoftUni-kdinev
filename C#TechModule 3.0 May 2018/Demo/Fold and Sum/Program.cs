using System;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int k = arr.Length / 4;

            int[] lowerArr = new int[k * 2];
            int[] upperArr = new int[k * 2];

            for (int i = 0; i < k * 2; i++)
            {
                lowerArr[i] = arr[k + i];
            }

            for (int i = 0; i < k; i++)
            {
                upperArr[i] = arr[k - i - 1];
                upperArr[upperArr.Length - k + i] = arr[arr.Length - 1 - i];
            }

            int[] sum = new int[2 * k];

            for (int i = 0; i < 2 * k; i++)
            {
                sum[i] = upperArr[i] + lowerArr[i];
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
