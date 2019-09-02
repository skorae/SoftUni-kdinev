using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static ICollection<int> istrue = new List<int>();
        static void Main(string[] args)
        {
            int count = 0;

            for (int i = 0; i <= 9; i++)
            {
                for (int y = 0; y <= 9; y++)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        for (int u = 0; u <= 9; u++)
                        {
                            count++;
                            Console.WriteLine($"{i}{y}{j}{u}");
                        }
                    }
                }
            }

            Console.WriteLine(count); ;
        }
    }
}
