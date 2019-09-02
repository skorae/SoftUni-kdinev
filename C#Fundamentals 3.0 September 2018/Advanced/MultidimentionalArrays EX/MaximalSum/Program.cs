using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = GetMatrix(n);
            int sum = int.MinValue;
            int[,] result = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                int temp = 0;

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    temp = 0;
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int y = col; y < col + 3; y++)
                        {
                            temp += matrix[i, y];
                        }
                    }
                    if (sum < temp)
                    {
                        sum = temp;
                        for (int resRow = 0; resRow < result.GetLength(0); resRow++)
                        {
                            for (int resCol = 0; resCol < result.GetLength(1); resCol++)
                            {
                                result[resRow, resCol] = matrix[row + resRow, col + resCol];
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    Console.Write($"{result[i, y]} ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] GetMatrix(int[] n)
        {
            int[,] matrix = new int[n[0], n[1]];

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
