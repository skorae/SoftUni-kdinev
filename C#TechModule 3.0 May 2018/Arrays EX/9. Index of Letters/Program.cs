using System;

namespace _9._Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            foreach (char letter in word)
            {
                Console.WriteLine($"{letter} -> {letter - 'a'}");
            }


        }
    }
}