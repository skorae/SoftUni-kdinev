using System;

namespace _13._Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int num;
            
            if (input == "a" || input == "e" || input == "o" || input == "u"
                || input == "i")
            {
                Console.WriteLine("vowel");
            }
            else if (Int32.TryParse(input, out num))
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
