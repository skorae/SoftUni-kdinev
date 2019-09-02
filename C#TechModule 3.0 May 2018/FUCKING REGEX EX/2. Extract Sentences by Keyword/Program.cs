using System;

namespace _2._Extract_Sentences_by_Keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string[] input = Console.ReadLine().Split('.','!','?');

            foreach (var item in input)
            {
                if (item.Contains($" {n} ") || item.Contains($"{n} "))
                {
                    Console.WriteLine(item.Trim());
                }
            }
        }
    }
}
