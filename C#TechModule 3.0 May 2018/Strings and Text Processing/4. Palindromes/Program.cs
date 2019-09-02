using System;
using System.Linq;
using System.Text;

namespace _4._Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reversed = "";
            string palindroms = "";


            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }

            foreach (var word in reversed)
            {
                if (input.Contains(word))
                {
                    palindroms += word;
                }
            }
            palindroms.OrderBy(x => x);
            Console.WriteLine(palindroms);
        }
    }
}
