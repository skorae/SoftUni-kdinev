using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (char i = 'a'; i < 'a' + n; i++)
            {
                for (char y = 'a'; y < 'a' + n; y++)
                {
                    for (char j = 'a'; j < 'a' + n; j++)
                    {
                        Console.WriteLine($"{i}{y}{j}", i.ToString(), y.ToString(), j.ToString());

                    }
                }
            }
        }
    }
}

