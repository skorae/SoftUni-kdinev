using System;

namespace _3._English_Name_оf_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = Math.Abs(long.Parse(Console.ReadLine()));
            string result = LastDigit(num);

            Console.WriteLine(result);
        }
        static string LastDigit(long num)
        {
            long lastDigit = num % 10;
            string text = "";
            switch (lastDigit)
            {
                case 0:
                    text = "zero";
                    break;
                case 1:
                    text = "one";
                    break;
                case 2:
                    text = "two";
                    break;
                case 3:
                    text = "three";
                    break;
                case 4:
                    text = "four";
                    break;
                case 5:
                    text = "five";
                    break;
                case 6:
                    text = "six";
                    break;
                case 7:
                    text = "seven";
                    break;
                case 8:
                    text = "eight";
                    break;
                case 9:
                    text = "nine";
                    break;
            }
            return text;
        }
    }
}
