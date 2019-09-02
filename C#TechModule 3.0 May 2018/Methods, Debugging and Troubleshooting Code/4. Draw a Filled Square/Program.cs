using System;

namespace _4._Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTopAndBotom(1, n * 2, "-");

            for (int i = 1; i <= n - 2; i++)
            {
                Console.WriteLine("-{0}-", NewString("\\/", n - 1));
            }
            PrintTopAndBotom(1, n * 2, "-");

        }
        static void PrintTopAndBotom(int start, int end, string fill)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{fill}");
            }
            Console.WriteLine();
        }
        static string NewString(string symbol, int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                result += symbol;
            }
            return result;
        }
    }
}
