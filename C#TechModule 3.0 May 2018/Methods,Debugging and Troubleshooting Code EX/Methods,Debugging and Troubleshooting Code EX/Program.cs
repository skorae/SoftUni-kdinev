using System;

namespace Hello_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Print(name);

        }

        private static void Print(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
