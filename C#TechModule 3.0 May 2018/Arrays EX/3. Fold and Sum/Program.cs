using System;
using System.Linq;

namespace _3._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int k = numbersArr.Length / 4;

            int[] upperArr = new int[k * 2];
            int[] lowerArr = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                upperArr[i] = numbersArr[k - i - 1];
                upperArr[upperArr.Length - k + i] =
                    numbersArr[numbersArr.Length - 1 - i];
            }
            for (int i = 0; i < 2 * k; i++)
            {
                lowerArr[i] = numbersArr[k + i];
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
