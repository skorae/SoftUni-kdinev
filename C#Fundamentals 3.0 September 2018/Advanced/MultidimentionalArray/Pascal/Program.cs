using System;

namespace Pascal
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[n][];

            for (long i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[1 + i];
            }

            for (long i = 0; i < jaggedArray.Length; i++)
            {
                for (long y = 0; y < jaggedArray[i].Length; y++)
                {
                    if (i > 1 && y > 0 && y < jaggedArray[i].Length - 1)
                    {
                        jaggedArray[i][y] = jaggedArray[i - 1][y] + jaggedArray[i - 1][y - 1];
                    }
                    else
                    {
                        jaggedArray[i][y] = 1;
                    }

                }
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}
