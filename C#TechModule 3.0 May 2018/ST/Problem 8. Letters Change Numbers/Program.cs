using System;
using System.Numerics;

namespace Problem_8._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
            double total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char firstLetter = input[i][0];
                input[i] = input[i].Remove(0, 1);
                char lastLetter = input[i][input[i].Length - 1];
                input[i] = input[i].Remove(input[i].Length - 1, 1);
                double temp = double.Parse(input[i]);

                if (firstLetter >= 'A' && firstLetter <= 'Z')
                {
                    int divide = (firstLetter - 'A') + 1;
                    temp /= divide;
                }
                else
                {
                    int multiply = (firstLetter -'a') + 1;
                    temp *= multiply;
                }

                if (lastLetter >= 'A' && lastLetter <= 'Z')
                {
                    int subtract = (lastLetter - 'A') + 1;
                    temp -= subtract;
                }
                else
                {
                    int add = (lastLetter -'a') + 1;
                    temp += add;
                }
                total += temp;
            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
