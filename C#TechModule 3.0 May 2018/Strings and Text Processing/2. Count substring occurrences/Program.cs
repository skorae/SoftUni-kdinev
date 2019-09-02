using System;

namespace _2._Count_substring_occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string overlap = Console.ReadLine().ToLower();

            int counter = 0;
            int index = text.IndexOf(overlap);

            while (index != -1)
            {
                counter++;
                index = text.IndexOf(overlap, index + 1);
            }

            Console.WriteLine(counter);
        }
    }
}
