using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> n = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < n.Count; i++)
            {
                if (n[i] % 2 !=0)
                {
                    n.Remove(n[i]);
                    i--;
                }
            }
            double average = 0;
            double sum = 0;
            foreach (var item in n)
            {
                sum += item;
            }
            average = sum / n.Count();
            for (int i = 0; i < n.Count; i++)
            {
                if (n[i] <= average)
                {
                    n[i]--;
                }
                else
                {
                    n[i]++;
                }
            }
            Console.WriteLine(string.Join(" ", n));
        }
    }
}
