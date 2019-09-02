using System;
using System.Linq;

namespace MinerProbe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            char[][] jaggedArray = new char[n][];
            int totalCoals = 0;

            for (int i = 0; i < n; i++)
            {
                char[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                jaggedArray[i] = arr;
                for (int y = 0; y < jaggedArray[i].Length; y++)
                {
                    if (jaggedArray[i][y] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }
            
            int row = 0;
            int col = 0;

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i].Contains('s'))
                {
                    row = i;
                    col = Array.IndexOf(jaggedArray[i], 's');
                }
            }
            
            
            foreach (var c in commands)
            {
                switch (c)
                {
                    case "up":
                        if (row - 1 < 0)
                        {
                            continue;
                        }
                        row--;
                        break;
                    case "down":
                        if (row + 1 >= jaggedArray.Length)
                        {
                            continue;
                        }
                        row++;
                        break;
                    case "left":
                        if (col - 1 < 0)
                        {
                            continue;
                        }
                        col--;
                        break;
                    case "right":
                        if (col + 1 >= jaggedArray[row].Length)
                        {
                            continue;
                        }
                        col++;
                        break;
                }

                if (jaggedArray[row][col] == 'c')
                {
                    totalCoals--;
                    jaggedArray[row][col] = '*';
                }
                if (jaggedArray[row][col] == 'e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
            }
            if (totalCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{totalCoals} coals left. ({row}, {col})");
            }
        }
    }
}
