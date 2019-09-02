using System;
using System.Collections.Generic;

namespace Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            Stack<int> stack = new Stack<int>();

            while (n!= 0)
            {
                stack.Push(n % 2);
                n /= 2;
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
