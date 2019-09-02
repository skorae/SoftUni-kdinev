using System;
using System.Linq;

namespace _4._Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool found = false;

            for (int a = 0; a < Arr.Length - 1; a++)
            {
                for (int b = a + 1; b < Arr.Length; b++)
                {
                    int sum = Arr[a] + Arr[b];

                    if (Arr.Contains(sum))
                    {
                        found = true;
                        Console.WriteLine($"{Arr[a]} + {Arr[b]} == {sum}");
                    }
                }
            }
            if (found != true)
            {
                Console.WriteLine("No");
            }
        }
    }
}
