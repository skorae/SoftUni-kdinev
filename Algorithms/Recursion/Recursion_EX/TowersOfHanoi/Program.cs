using System;
using System.Collections.Generic;
using System.Linq;

namespace TowersOfHanoi
{
    class Program
    {
        static Stack<int> source;
        static Stack<int> free;
        static Stack<int> destination;

        static int stepsTaken = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var range = Enumerable.Range(1, n);

            source = new Stack<int>(range.Reverse());
            free = new Stack<int>();
            destination = new Stack<int>();

            PrintRods();

            Solve(n, source, destination, free);
        }

        private static void Solve(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> free)
        {
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                StepsTaken();
            }

            Solve(bottomDisk - 1, source, free, destination);

            destination.Push(source.Pop());
            StepsTaken();

            Solve(bottomDisk - 1, free, destination, source);
        }

        private static void StepsTaken()
        {
            stepsTaken++;
            Console.WriteLine($"Step #{stepsTaken}: Moved disk");
            PrintRods();
        }

        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", free.Reverse())}");
            Console.WriteLine();
        }
    }
}
