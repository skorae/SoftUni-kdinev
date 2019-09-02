using System;

namespace _9._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));
            int result = EndResult(num);

            Console.WriteLine(result);

        }

        private static int EndResult(int num)
        {
            int evenSum = 0;
            int oddSum = 0;
            int result = 0;
            while (num > 0)
            {
                int lastDigit = num % 10;

                if (lastDigit % 2 == 0)
                {
                    evenSum += lastDigit;
                }
                else
                {
                    oddSum += lastDigit;
                }
                result = evenSum * oddSum;
                num /= 10;
            }
            return result;
        }
    }
}
