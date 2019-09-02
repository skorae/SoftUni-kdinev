using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _1_to_1000
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int page = 0;

            for (int i = 1; i < int.MaxValue; i++)
            {
                List<int> temp = ToList(i);

                count += temp.Count;

                if (count == 1095)
                {
                    page = i;
                    break;
                }
                Console.WriteLine(count);
            }
            Console.WriteLine(page);
        }

        private static List<int> ToList(int i)
        {
            List<int> temp = new List<int>();

            while (i != 0)
            {
                temp.Add(i % 10);
                i /= 10;
            }

            return temp;
        }
    }
}
