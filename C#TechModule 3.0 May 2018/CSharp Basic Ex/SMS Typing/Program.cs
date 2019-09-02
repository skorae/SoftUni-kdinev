using System;

namespace SMS_Typing
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int numberOfDigits = 0;
            int offSet = 0;

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num == 0)
                {
                    Console.Write(" ");
                    continue;
                }
                if (num / 1000 != 0)
                {
                    numberOfDigits = 4;
                }
                else if (num / 100 != 0)
                {
                    numberOfDigits = 3;
                }
                else if (num / 10 != 0)
                {
                    numberOfDigits = 2;
                }
                else if (num / num == 1)
                {
                    numberOfDigits = 1;
                }

                int mainDigit = num % 10;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offSet = ((mainDigit - 2) * 3) + 1;
                }
                else
                {
                    offSet = (mainDigit - 2) * 3;
                }
                int index = offSet + numberOfDigits - 1;
                char type = (char)('a' + index);

                Console.Write($"{type}");
            }
        }
    }
}
