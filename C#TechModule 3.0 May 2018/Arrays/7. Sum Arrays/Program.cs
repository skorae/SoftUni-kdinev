using System;
using System.Linq;

namespace _7._Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            if (first.Length < second.Length)
            {
                first = ArrayEqualizer(first, second);
            }
            else if (first.Length > second.Length)
            {
                second = ArrayEqualizer(second, first);
            }

            for (int i = 0; i < first.Length; i++)
            {
                sum = first[i] + second[i];
                Console.Write($"{sum} ");
            }

        }
        static int[] ArrayEqualizer(int[] small, int[] big)
        {
            int[] temp = new int[big.Length];
            int count = 0;
            int sCount = 0;
            while (count < big.Length)
            {

                if (sCount == small.Length)
                {
                    sCount = 0;
                }
                temp[count] += small[sCount];
                sCount++;
                count++;
            }
            small = temp;
            return small;
        }
    }
}
