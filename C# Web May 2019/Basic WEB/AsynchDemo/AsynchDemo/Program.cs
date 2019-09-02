namespace AsynchDemo
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = GenerateMatrix(dimentions);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arr = input.Split();

                if (arr.Length != 5)
                {
                    input = InvalidInput();
                    continue;
                }

                string command = arr[0];

                int row1 = int.Parse(arr[1]);
                int col1 = int.Parse(arr[2]);
                int row2 = int.Parse(arr[3]);
                int col2 = int.Parse(arr[4]);

                bool isValid = command == "swap" &&
                    row1 >= 0 && row1 < matrix.GetLength(0) &&
                    col1 >= 0 && col1 < matrix.GetLength(1) &&
                    row2 >= 0 && row2 < matrix.GetLength(0) &&
                    col2 >= 0 && col2 < matrix.GetLength(1);

                if (!isValid)
                {
                    input = InvalidInput();
                    continue;
                }

                string temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row,col]} ");
                    }
                    Console.WriteLine();
                }

                input = Console.ReadLine();
            }
        }

        private static string InvalidInput()
        {
            Console.WriteLine("Invalid input!");

            return Console.ReadLine();
        }

        private static string[,] GenerateMatrix(int[] dimentions)
        {
            string[,] matix = new string[dimentions[0], dimentions[1]];

            for (int row = 0; row < matix.GetLength(0); row++)
            {
                string[] arr = Console.ReadLine().Split();

                for (int col = 0; col < matix.GetLength(1); col++)
                {
                    matix[row, col] = arr[col];
                }
            }

            return matix;
        }
    }
}
