using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubic_sCube
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = GetMatrix(n);
            int[,] resultMatrix = GetMatrix(n);

            int toDo = int.Parse(Console.ReadLine());

            for (int i = 0; i < toDo; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = command[1];
                int rowOrCol = int.Parse(command[0]);
                int moves = int.Parse(command[2]);
                Queue<int> queue = new Queue<int>();

                if (moves % matrix.GetLength(1) == 0 || moves == 0 || moves % matrix.GetLength(0) == 0)
                {
                    continue;
                }

                switch (direction)
                {
                    case "down":
                        for (int m = 0; m <moves % matrix.GetLength(0); m++)
                        {
                            queue.Enqueue(matrix[matrix.GetLength(0) - 1, rowOrCol]);
                            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
                            {
                                queue.Enqueue(matrix[r, rowOrCol]);
                            }

                            for (int r = 0; r < matrix.GetLength(0); r++)
                            {
                                matrix[r, rowOrCol] = queue.Dequeue();
                            }
                        }
                        break;
                    case "up":
                        for (int m = 0; m < moves % matrix.GetLength(0); m++)
                        {
                            for (int r = 1; r < matrix.GetLength(0); r++)
                            {
                                queue.Enqueue(matrix[r, rowOrCol]);
                            }
                            queue.Enqueue(matrix[0, rowOrCol]);

                            for (int r = 0; r < matrix.GetLength(0); r++)
                            {
                                matrix[r, rowOrCol] = queue.Dequeue();
                            }
                        }
                        break;
                    case "right":
                        for (int m = 0; m < moves % matrix.GetLength(1); m++)
                        {
                            queue.Enqueue(matrix[rowOrCol, matrix.GetLength(1) - 1]);
                            for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                            {
                                queue.Enqueue(matrix[rowOrCol, c]);
                            }

                            for (int c = 0; c < matrix.GetLength(0); c++)
                            {
                                matrix[rowOrCol, c] = queue.Dequeue();
                            }
                        }
                        break;
                    case "left":
                        for (int m = 0; m < moves % matrix.GetLength(1); m++)
                        {
                            for (int c = 1; c < matrix.GetLength(1); c++)
                            {
                                queue.Enqueue(matrix[rowOrCol, c]);
                            }
                            queue.Enqueue(matrix[rowOrCol, 0]);

                            for (int c = 0; c < matrix.GetLength(0); c++)
                            {
                                matrix[rowOrCol, c] = queue.Dequeue();
                            }
                        }
                        break;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (resultMatrix[row, col] == matrix[row, col])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int element = resultMatrix[row, col];
                        int[] positions = GetPosition(element, matrix,row,col);
                        int temp = matrix[row, col];
                        matrix[row, col] = matrix[positions[0], positions[1]];
                        matrix[positions[0], positions[1]] = temp;

                        Console.WriteLine($"Swap ({row}, {col}) with ({positions[0]}, {positions[1]})");
                    }
                }
            }
        }

        private static int[] GetPosition(int element, int[,] matrix,int row,int col)
        {
            int[] position = new int[2];

            for (int r = row; r < matrix.GetLength(0); r++)
            {
                if (r != row)
                {
                    col = 0;
                }
                for (int c = col; c < matrix.GetLength(1); c++)
                {
                    if (element == matrix[r, c])
                    {
                        position[0] = r;
                        position[1] = c;
                        return position;
                    }
                }
            }

            return position;
        }

        private static int[,] GetMatrix(int[] n)
        {
            int[,] matrix = new int[n[0], n[1]];
            int count = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }

            return matrix;
        }
    }
}
