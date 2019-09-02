using System;

namespace _12._Master_Numbers
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
                    if (SumOfDigits(i))
                    {
                        if (EvenDigit(i))
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
        }
        static bool IsPalindrome(int i)
        {
            int num = i;
            int rev = 0;
            bool isTrue = true;
            while (num > 0)
            {
                int dig = num % 10;
                rev = rev * 10 + dig;
                num /= 10;

                if (i == rev)
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }

            }
            return isTrue;
        }
        static bool SumOfDigits(int i)
        {
            int num = i;
            int sum = 0;
            bool isTrue = true;

            while (num > 0)
            {
                int last = num % 10;
                sum += last;
                num /= 10;

                if (sum % 7 == 0)
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
        static bool EvenDigit(int i)
        {
            int num = i;
            bool isTrue = true;
            while (num > 0)
            {
                int last = num % 10;
                num /= 10;
                if (last % 2 == 0)
                {
                    isTrue = true;
                    return isTrue;
                }
                else
                {
                    isTrue = false;
                }

            }
            return isTrue;
        }
    }
}
