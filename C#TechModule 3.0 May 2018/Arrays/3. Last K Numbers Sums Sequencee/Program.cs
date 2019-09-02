using System;

namespace _3._Last_K_Numbers_Sums_Sequencee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] numbers = new long[n];
            numbers[0] = 1;

            SumLastKNumbers(numbers,k);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SumLastKNumbers(long[] numbers, int k)
        {
            for (int currentElement = 0; currentElement < numbers.Length; currentElement++)
            {
                int startIndex = Math.Max(0, currentElement - k);
                long sum = 0;
                for (int i = startIndex; i <= currentElement; i++)
                {
                    sum += numbers[i];
                }
                numbers[currentElement] = sum;
            }
            
        }
    }
}
