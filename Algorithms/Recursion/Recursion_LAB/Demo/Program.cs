using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;

            int[] arr = new int[n];
            List<int> list = new List<int>();

            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }

            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
