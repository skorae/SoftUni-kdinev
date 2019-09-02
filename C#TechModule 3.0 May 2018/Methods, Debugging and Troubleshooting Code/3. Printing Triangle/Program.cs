using System;

namespace _3._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintPiramid(1, i);

            }
           
            for (int i = n - 1; i >= 1; i--)
            {
                PrintPiramid(1, i);
            }
            Console.WriteLine();
        }
        static void PrintPiramid(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}