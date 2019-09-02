using System;
using System.Linq;

namespace _2x2SquearsInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = GetMatrix(n);

            int count = 0;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char temp = matrix[row, col];

                    if (temp == matrix[row - 1,col] && temp == matrix[row,col +1] && temp == matrix[row-1,col +1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }

        private static char[,] GetMatrix(int[] n)
        {
            char[,] matrix = new char[n[0], n[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }
    }
}
