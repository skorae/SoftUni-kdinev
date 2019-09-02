using System;

namespace GeneratingVectors
{
    class Program
    {
        private static int[] arr;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            arr = new int[n];

            Vector(0);
        }

        private static void Vector(int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                Vector(index + 1);
            }
        }
    }
}
