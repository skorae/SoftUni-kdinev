using System;

namespace CatNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                int year = int.Parse(Console.ReadLine());

                int f = firstName[0];
                int s = lastName[0];

                Console.WriteLine(year.ToString() + f + s + i);

            }
        }
    }
}
