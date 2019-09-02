using System;
using System.Linq;

namespace JaggedArrayModifications
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = GetJagged(n);

            string[] command = Console.ReadLine().Split(" ");

            while (command[0].ToLower() != "end")
            {
                string comm = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || col < 0 || row > jaggedArray.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine().Split(" ");
                    continue;
                }
                
                switch (comm)
                {
                    case "Add":
                        jaggedArray[row][col] += value;
                        break;
                    case "Subtract":
                        jaggedArray[row][col] -= value;
                        break;
                }

                command = Console.ReadLine().Split(" ");
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[row]));
            }
        }

        private static int[][] GetJagged(int n)
        {
            int[][] jaggedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedArray[i] = data;
            }

            return jaggedArray;
        }
    }
}
