using System;

namespace _5._Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = Result(n);
            if (n == 0)
            {
                Console.WriteLine(1);
            }
            else if (n == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(result);
            }

        }
        static int Result(int n)
        {
            int a = 1;
            int b = 1;
            int temp = 0;

            for (int i = 2; i <= n; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }
            return temp;
        }
    }
}
