using System;
using System.Linq;

namespace _8._Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int curCount = 0;
            int maxCount = 0;
            int digit = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        curCount++;
                        if (curCount > maxCount)
                        {
                            maxCount = curCount;
                            digit = numbers[i];
                        }
                    }
                }
                curCount = 0;
            }
            Console.WriteLine(digit);
        }
    }
}
