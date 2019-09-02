using System;
using System.Linq;

namespace GeneratingCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());
            int[] vectors = new int[n];

            int border = arr.Length - 1;

            VectorGeneration(arr, vectors, 0, 0);
        }

        private static void VectorGeneration(int[] arr, int[] vectors, int index, int border)
        {
            if (index == vectors.Length)
            {
                Console.WriteLine(string.Join(" ", vectors));
                return;
            }

            for (int i = border; i < arr.Length; i++)
            {
                vectors[index] = arr[i];
                VectorGeneration(arr, vectors, index + 1, i + 1);
            }
        }
    }
}
