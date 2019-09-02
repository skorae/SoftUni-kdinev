using System;
using System.Linq;

namespace ReverseAndExecute
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());

            Func<int[], int[]> func = x => x.Reverse().ToArray();

            int[] rev = func(arr);
            
        }
    }
}
