using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[] text = Console.ReadLine().ToCharArray();
            int[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<char> queue = new Queue<char>();
            char[,] matrix = GetMatrix(text, n);
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int rowImpact = commands[0];
            int colImpact = commands[1];
            int radius = commands[2];


            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    double distance = Math.Sqrt(Math.Pow(r - rowImpact, 2) + Math.Pow(c - colImpact, 2));
                    if (distance <= radius)
                    {
                        matrix[r, c] = ' ';
                    }
                }
            }

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
                {
                    if (matrix[r, c] == ' ')
                    {
                        continue;
                    }
                    queue.Enqueue(matrix[r, c]);
                }
                queue.TrimExcess();
                for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
                {
                    if (queue.Count == 0)
                    {
                        matrix[r, c] = ' ';
                        continue;
                    }
                    matrix[r, c] = queue.Dequeue();
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write($"{matrix[i, y]}");
                }
                Console.WriteLine();
            }
        }

        private static char[,] GetMatrix(char[] text, int[] n)
        {
            char[,] matrix = new char[n[0], n[1]];

            int count = 0;

            for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                {
                    if (count == text.Length)
                    {
                        count = 0;
                    }
                    matrix[r, c] = text[count];
                    count++;
                }
                r--;
                if (r < 0)
                {
                    break;
                }
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (count == text.Length)
                    {
                        count = 0;
                    }
                    matrix[r, c] = text[count];
                    count++;
                }
            }

            return matrix;
        }
    }
}
