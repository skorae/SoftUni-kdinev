using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }
            stack.TrimExcess();
            while (stack.Count != 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
