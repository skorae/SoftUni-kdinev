using System;
using System.Linq;

namespace MultidimentionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[data[0], data[1]];

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(data[0]);
            Console.WriteLine(data[1]);
            Console.WriteLine(sum);
        }
    }
}
