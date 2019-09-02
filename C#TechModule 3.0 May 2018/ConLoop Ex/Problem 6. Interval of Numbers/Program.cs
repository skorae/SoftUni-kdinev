using System;

namespace Problem_6._Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            for (int i = min; i <= max; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
