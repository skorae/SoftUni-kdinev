using System;
using System.Drawing;
using System.Linq;

namespace DistanceInLabyrinth
{
    class Program
    {
        private static string[][] labyrinth;
        private static int count;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            labyrinth = new string[size][];

            int startRow = 0;
            int startCol = 0;
            count = 0;

            for (int row = 0; row < size; row++)
            {
                labyrinth[row] = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray();

                if (labyrinth[row].Contains("*"))
                {
                    startRow = row;
                    startCol = Array.IndexOf(labyrinth[row], "*");
                }
            }

            FindAllPaths(startRow, startCol, count);

            FillUnreachable();
        }

        private static void FillUnreachable()
        {
            for (int row = 0; row < labyrinth.Length; row++)
            {
                if (labyrinth[row].Contains("0"))
                {
                    for (int col = 0; col < labyrinth[row].Length; col++)
                    {
                        if (labyrinth[row][col] == "0")
                        {
                            labyrinth[row][col] = "u";
                        }
                    }
                }

                Console.WriteLine(string.Join(" ", labyrinth[row]));
            }
        }

        private static void FindAllPaths(int row, int col, int count)
        {
            if ((row < 0 || row >= labyrinth.Length || col < 0 || col >= labyrinth[row].Length))
            {
                count -= 1;
                return;
            }

            if (labyrinth[row][col] != "0" && labyrinth[row][col] != "*")
            {
                count -= 1;
                return;
            }

            if (labyrinth[row][col] == "0")
            {
                labyrinth[row][col] = count.ToString();
            }

            FindAllPaths(row, col + 1, count + 1);
            FindAllPaths(row, col - 1, count + 1);
            FindAllPaths(row - 1, col, count + 1);
            FindAllPaths(row + 1, col, count + 1);
        }
    }
}
