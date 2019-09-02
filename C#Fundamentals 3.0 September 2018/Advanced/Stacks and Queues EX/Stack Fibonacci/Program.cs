using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            else if (n == 0)
            {
                Console.WriteLine(0);
            }

            for (long i = 1; i < n; i++)
            {
                long a = stack.Pop();
                long b = stack.Pop() + a;

                stack.Push(a);
                stack.Push(b);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
