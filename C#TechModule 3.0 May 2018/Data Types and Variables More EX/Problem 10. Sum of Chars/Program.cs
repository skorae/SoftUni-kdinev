using System;

namespace Problem_10._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());

                sum += input;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
