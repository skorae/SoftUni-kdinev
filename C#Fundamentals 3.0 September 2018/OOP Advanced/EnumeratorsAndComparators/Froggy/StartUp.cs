using System;
using System.Linq;

namespace Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake lake = new Lake(arr);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
