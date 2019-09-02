using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<List<int>> matrix = GetMatrix(n);

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] arr = command.Split().Select(int.Parse).ToArray();

                int row = arr[0];
                int col = arr[1];
                int radius = arr[2];

                for (int r = 0; r < matrix.Count; r++)
                {
                    for (int c = 0; c < matrix[r].Count; c++)
                    {
                        if (r == row && Math.Abs(c - col) <= radius ||
                            c == col && Math.Abs(r - row) <= radius)
                        {
                            matrix[r][c] = 0;
                        }
                    }
                }

                for (int r = 0; r < matrix.Count; r++)
                {
                    matrix[r].RemoveAll(x => x == 0);
                    if (matrix[r].Count == 0)
                    {
                        matrix.RemoveAt(r);
                        r--;
                    }
                }
                
                command = Console.ReadLine();
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }

        private static List<List<int>> GetMatrix(int[] n)
        {
            List<List<int>> matrix = new List<List<int>>();
            int count = 1;

            for (int r = 0; r < n[0]; r++)
            {
                matrix.Add(new List<int>());
                for (int c = 0; c < n[1]; c++)
                {
                    matrix[r].Add(count++);
                }
            }

            return matrix;
        }
    }
}
