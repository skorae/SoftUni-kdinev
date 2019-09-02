using System;
using System.Collections.Generic;
using System.Linq;

namespace Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
                Console.Write($"{nums[i]:d4} ");
            }

            
        }
    }
}
