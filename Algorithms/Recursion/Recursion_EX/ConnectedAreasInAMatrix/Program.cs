using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInAMatrix
{
    class Program
    {
        static char[,] arr;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            List<Field> fields = new List<Field>();

            arr = GenerateMatrix(rows, cols);

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] != '*' && arr[row, col] != 'x')
                    {
                        Field field = new Field(row, col);
                        field.Size = FindSize(row, col);
                        fields.Add(field);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {fields.Count}");
            int count = 1;
            foreach (var field in fields.OrderByDescending(x => x.Size))
            {
                Console.WriteLine($"Area #{count++} at ({field.RowIndex}, {field.ColumnIndex}), size: {field.Size}");
            }
        }

        private static int FindSize(int row, int col)
        {
            if (row < 0 ||
                row == arr.GetLength(0) ||
                col < 0 ||
                col == arr.GetLength(1))
            {
                return 0;
            }
            else
            {
                if (arr[row, col] == '*' || arr[row, col] == 'x')
                {
                    return 0;
                }

                arr[row, col] = 'x';

                return 1 +
                FindSize(row - 1, col) +
                FindSize(row + 1, col) +
                FindSize(row, col - 1) +
                FindSize(row, col + 1);
            }
        }

        private static char[,] GenerateMatrix(int rows, int cols)
        {
            char[,] temp = new char[rows, cols];

            for (int row = 0; row < temp.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                for (int col = 0; col < temp.GetLength(1); col++)
                {
                    temp[row, col] = arr[col];
                }
            }

            return temp;
        }
    }

    class Field
    {
        public Field(int row, int col)
        {
            this.RowIndex = row;
            this.ColumnIndex = col;
            this.Size = 0;
        }

        public int RowIndex { get; private set; }

        public int ColumnIndex { get; private set; }

        public int Size { get; set; }
    }
}