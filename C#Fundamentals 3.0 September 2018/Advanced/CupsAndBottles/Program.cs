using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] c = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] b = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(c);
            Stack<int> bottles = new Stack<int>(b);
            Stack<int> firstBottles = new Stack<int>(b);

            int wastedWater = 0;
            int count = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (bottles.Peek() > cups.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();
                }
            }

            int final = wastedWater;

            while (wastedWater > 0)
            {
                if (firstBottles.Peek() <= wastedWater)
                {
                    wastedWater -= firstBottles.Pop();
                }
                else
                {
                    wastedWater
                   firstBottles.Push(firstBottles.Pop() - wastedWater);
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {firstBottles.Count}");
                Console.WriteLine($"Wasted litters of water: {final}");
            }
        }
    }
}
