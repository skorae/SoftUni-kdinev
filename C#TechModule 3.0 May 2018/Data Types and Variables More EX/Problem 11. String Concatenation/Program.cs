using System;
using System.Collections.Generic;

namespace Problem_11._String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimiter = char.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            List<string> text = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                if (type == "even" && i % 2 == 0)
                {
                    text.Add(word);
                }
                else if (i % 2 != 0 && type == "odd")
                {
                    text.Add(word);
                }
            }
            Console.WriteLine(string.Join($"{delimiter}", text));
        }
    }
}
