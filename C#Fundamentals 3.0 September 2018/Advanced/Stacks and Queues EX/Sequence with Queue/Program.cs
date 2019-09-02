using System;
using System.Collections.Generic;
using System.Linq;

namespace Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            List<long> temp = new List<long>();
            temp.Add(n);

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);

            for (int i = 1; i < 50; i++)
            {
                long t = queue.Dequeue();

                long a = t + 1;
                long b = 2 * t + 1;
                long c = t + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                temp.Add(a);
                temp.Add(b);
                temp.Add(c);
            }
            Console.WriteLine(string.Join(" ", temp.Take(50)));
        }
    }
}
