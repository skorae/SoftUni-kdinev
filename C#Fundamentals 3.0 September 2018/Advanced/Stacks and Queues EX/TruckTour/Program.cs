using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] temp = new int[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                temp[i] = line[0] - line[1];
            }

            int count = 0;
            for (int i = 0; i < temp.Length - 1; i++)
            {
                if (temp[i] < 0)
                {
                    count = i + 1;
                }

                if (temp[i] > 0)
                {
                    temp[i + 1] = temp[i] + temp[i + 1];
                }
            }
            Console.WriteLine(count);
        }
    }
}
