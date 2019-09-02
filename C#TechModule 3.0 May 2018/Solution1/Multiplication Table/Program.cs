using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 1;

            while (count <=10)
            {
                Console.WriteLine($"{num} X {count} = {num * count}");
                count++;
            }
        }
    }
}
