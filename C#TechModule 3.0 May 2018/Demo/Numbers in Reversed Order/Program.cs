using System;

namespace Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            Console.WriteLine(Reverse(n));
        }

        private static string Reverse(string n)
        {
            string x = "";

            for (int i = n.Length - 1; i >= 0; i--)
            {
                x += n[i];
            }

            return x;
        }
    }
}
