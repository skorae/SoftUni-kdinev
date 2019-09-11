using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var result = new List<int>();
            result.Add(number);

            var sequence = new Queue<int>();
            sequence.Enqueue(number);

            while (result.Count < 50)
            {
                var currentNumber = sequence.Peek();

                var first = currentNumber + 1;
                var second = (currentNumber * 2) + 1;
                var third = currentNumber + 2;

                sequence.Enqueue(first);
                sequence.Enqueue(second);
                sequence.Enqueue(third);

                result.AddRange(new int[] { first, second, third });

                sequence.Dequeue();
            }

            Console.WriteLine(string.Join(", ", result.Take(50)));
        }
    }
}
