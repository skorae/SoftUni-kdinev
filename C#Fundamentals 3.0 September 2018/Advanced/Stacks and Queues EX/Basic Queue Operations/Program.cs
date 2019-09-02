using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] toDo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < toDo[0]; i++)
            {
                queue.Enqueue(arr[i]);
            }

            for (int i = 0; i < toDo[1]; i++)
            {
                queue.Dequeue();

            }

            if (queue.Count < 1)
            {
                Console.WriteLine(0);
                return;
            }
            if (queue.Contains(toDo[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
