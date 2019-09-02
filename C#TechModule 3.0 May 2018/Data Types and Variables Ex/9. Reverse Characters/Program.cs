using System;

namespace _9._Reverse_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            string word = "" + third + second + first;

            Console.WriteLine(word);
        }
    }
}
