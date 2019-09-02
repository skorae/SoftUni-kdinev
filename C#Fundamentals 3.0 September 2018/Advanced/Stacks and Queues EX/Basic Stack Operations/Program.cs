using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] toDo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }

            for (int i = 0; i < toDo[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }
            if (stack.Contains(toDo[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
