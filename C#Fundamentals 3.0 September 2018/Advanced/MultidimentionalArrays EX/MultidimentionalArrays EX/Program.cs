using System;
using System.Linq;

namespace MultidimentionalArrays_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            string[,] matrix = new string[n[0],n[1]];
            char a = 'a';

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 1)
                        {
                            matrix[row, col] += (char)(a + col);
                        }
                        else
                        {
                            matrix[row, col] += a;
                        }
                    }
                }
                a++;
            }            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write($"{matrix[i,y]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
