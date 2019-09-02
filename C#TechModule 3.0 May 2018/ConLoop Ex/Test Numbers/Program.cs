using System;

namespace Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());
            int combo = 0;
            int num = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int y = 1; y <= m; y++)
                {
                    combo++;
                    num += (i * y) * 3;

                    if (num >= sum)
                    {
                        Console.WriteLine($"{combo} combinations");
                        Console.WriteLine($"Sum: {num} >= {sum}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combo} combinations");
            Console.WriteLine($"Sum: {num}");
        }
    }
}
