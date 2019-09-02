using System;

namespace Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsPalindrome(i))
                {
                    if (SumDigits(i))
                    {
                        if (IsEvenDigit(i))
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
        }

        private static bool IsEvenDigit(int i)
        {
            bool isTrue = false;

            while (i > 0)
            {
                int temp = i % 10;

                if (temp % 2 == 0)
                {
                    isTrue = true;
                    break;
                }

                i /= 10;
            }

            return isTrue;
        }

        private static bool SumDigits(int i)
        {
            bool isTrue = false;
            int sum = 0;

            while (i > 0)
            {
                int temp = i % 10;
                sum += temp;
                i /= 10;
            }

            if (sum % 7 == 0)
            {
                isTrue = true;
            }

            return isTrue;
        }

        private static bool IsPalindrome(int i)
        {
            bool isTrue = false;
            int currentDigit = 0;
            int reverse = 0;
            int temp = i;

            while (i > 0)
            {
                currentDigit = i % 10;
                reverse = (reverse * 10) + currentDigit;
                i /= 10;
            }

            if (reverse == temp)
            {
                isTrue = true;
            }
            
            return isTrue;
        }
    }
}
