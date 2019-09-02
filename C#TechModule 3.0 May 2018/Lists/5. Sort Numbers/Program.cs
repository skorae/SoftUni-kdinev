using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Sort_Numbers
{
    class Program
    {        
        static void Main(string[] args)
        {
            List<double> num = Console.ReadLine().Split().Select(double.Parse).ToList();

            num.Sort();

            Console.Write(string.Join(" <= ", num));

        }
    }
}
