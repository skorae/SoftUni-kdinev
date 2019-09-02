using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> temp = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                temp.Add(Reverse(numbers[i]));
            }

            int sum = 0;
            for (int i = 0; i < temp.Count; i++)
            {
                sum += temp[i];
            }
            Console.WriteLine(sum);
        }

        private static int Reverse(int number)
        {
            int temp = 0;
            int reverse = 0;

            while (number > 0)
            {
                temp = number % 10;
                reverse = reverse * 10 + temp;
                number /= 10;
            }

            return reverse;
        }
    }
}
