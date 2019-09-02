using System;
using System.Collections.Generic;
using System.Linq;

namespace Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            Queue<long> queue = new Queue<long>(data);

            long count = 0;

            for (long i = 0; i < n; i++)
            {
                long platsToDie = 0;
                long pesticideLevel = queue.Dequeue();

                if (queue.Peek() == pesticideLevel + 1 || queue.Peek() == pesticideLevel - 1)
                {
                    queue.Enqueue(pesticideLevel);
                    queue.Enqueue(queue.Dequeue());
                }
                else
                {
                    platsToDie++;
                }
                if (platsToDie == 0)
                {
                    break;
                }
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
