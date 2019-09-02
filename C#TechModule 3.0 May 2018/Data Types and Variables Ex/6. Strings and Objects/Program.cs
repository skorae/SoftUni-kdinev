using System;

namespace _6._Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            string str3 = $"{str1} {str2}";

            Console.WriteLine(str3);
        }
    }
}
