using System;
using System.Linq;

namespace Arrays_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split().ToArray();
            string[] second = Console.ReadLine().Split().ToArray();
            int minLenght = Math.Min(first.Length, second.Length);

            int countLeft = 0;
            int countRight = 0;
            for (int i = 0; i < minLenght; i++)
            {
                if (first[i] == second[i])
                {
                    countLeft++;
                }
                if (first[first.Length - 1 - i] == second[second.Length - 1 - i])
                {
                    countRight++;
                }
            }
            Console.WriteLine(Math.Max(countRight, countLeft));


        }
    }
}