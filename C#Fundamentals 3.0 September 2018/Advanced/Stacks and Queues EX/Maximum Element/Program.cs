using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                switch (arr[0])
                {
                    case 1:
                        stack.Push(arr[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(stack.Max());
                        break;
                }
            }
        }
    }
}
