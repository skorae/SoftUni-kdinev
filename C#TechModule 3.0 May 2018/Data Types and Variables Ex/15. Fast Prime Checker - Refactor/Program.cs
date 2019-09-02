using System;

namespace _15._Fast_Prime_Checker___Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 2; i <= num; i++)
            {
                bool isTrue = true;
                for (int y = 2; y <= Math.Sqrt(i); y++)
                {
                    if (i % y == 0)
                    {
                        isTrue = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isTrue}");
            }

        }
    }
}
