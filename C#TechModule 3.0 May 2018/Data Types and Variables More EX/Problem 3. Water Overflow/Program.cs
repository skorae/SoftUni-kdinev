using System;

namespace Problem_3._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int limit = 255;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                sum += input;
                if (sum > limit)
                {
                    Console.WriteLine("Insufficient capacity!");
                    sum -= input;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
