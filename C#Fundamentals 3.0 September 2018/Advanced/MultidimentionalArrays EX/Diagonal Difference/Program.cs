using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = GetMatrix(n);
            int leftToRight = 0;
            int rightToLeft = 0;

            for (int i = 0; i < n; i++)
            {
                leftToRight += matrix[i, i];
                rightToLeft += matrix[n - 1 - i,0 + i];
            }
            Console.WriteLine($"{Math.Abs(leftToRight - rightToLeft)}");
        }

        private static int[,] GetMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }
    }
}
