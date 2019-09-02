using System;

namespace RecursiveDrawing
{
    class Program
    {
        private static char topChar = '*';
        private static char bottomChar = '#';

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Draw(n);
        }

        private static void Draw(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string(topChar, n));

            Draw(n - 1);

            Console.WriteLine(new string(bottomChar, n));
        }
    }
}
