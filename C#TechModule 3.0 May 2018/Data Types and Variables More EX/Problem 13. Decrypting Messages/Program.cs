using System;

namespace Problem_13._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 0; i < n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                message += (char)(symbol + key);
            }
            Console.WriteLine(message);
        }
    }
}
