using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] evenArr = new int[n];
            int[] oddArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] temp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    evenArr[i] = temp[0];
                    oddArr[i] = temp[1];
                }
                else
                {
                    evenArr[i] = temp[1];
                    oddArr[i] = temp[0];
                }
            }

            Console.WriteLine(string.Join(" ", evenArr));
            Console.WriteLine(string.Join(" ", oddArr));
        }
    }
}
