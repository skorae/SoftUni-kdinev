using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            List<Field> fields = new List<Field>();

            char[,] arr = GenerateMatrix(rows, cols);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (char.IsDigit(arr[i, y]))
                    {
                        Field field = new Field(arr[i, y], i, y, arr);
                        fields.Add(field);
                    }
                }
            }

            Console.WriteLine($"Total areas found: {fields.Count}");

            foreach (var field in fields.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"Area #{field.Value} at ({field.RowIndex}, {field.ColumnIndex}), size: {field.Size}");
            }
        }

        private static char[,] GenerateMatrix(int rows, int cols)
        {
            char[,] temp = new char[rows, cols];

            for (int row = 0; row < temp.GetLength(0); row++)
            {
                string input = Console.ReadLine().Replace(' ', '-');
                char[] arr = input.ToCharArray();

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
        public Field(char value, int row, int col, char[,] arr)
        {
            this.Value = int.Parse(value.ToString());
            this.RowIndex = row;
            this.ColumnIndex = col;
            this.Size = 0;

            FindSize(arr, row, col);
        }
        public int Value { get; private set; }

        public int RowIndex { get; private set; }

        public int ColumnIndex { get; private set; }

        public int Size { get; private set; }

        private void FindSize(char[,] arr, int row, int col)
        {
            if (row < 0 ||
                row >= arr.GetLength(0) ||
                col < 0 ||
                col >= arr.GetLength(1))
            {
                return;
            }
            else
            {
                if (arr[row, col] == '*' || arr[row, col] == 'x')
                {
                    return;
                }

                arr[row, col] = 'x';
                this.Size += 1;

                FindSize(arr, row - 1, col);
                FindSize(arr, row, col + 1);
                FindSize(arr, row + 1, col);
                FindSize(arr, row, col - 1);
            }
        }
    }
}