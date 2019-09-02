using System;
using System.Linq;

namespace SquearWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = GetMatrix(size);

            int topIndex = 0;
            int bottomIndex = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                int tempSum = 0;
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    tempSum = matrix[row, col] + matrix[row, (col + 1)] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum < tempSum)
                    {
                        sum = tempSum;
                        topIndex = row;
                        bottomIndex = col;
                    }
                }
            }

            for (int row = topIndex; row < topIndex + 2; row++)
            {
                for (int col = bottomIndex; col < bottomIndex +2; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);
        }

        private static int[,] GetMatrix(int[] size)
        {
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            return matrix;
        }
    }
}
