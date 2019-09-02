using System;
using System.IO;

namespace Streams_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "..//..//..//Program.cs";

            int count = 1;

            using (StreamReader stream = new StreamReader(pattern))
            {
                string text = stream.ReadLine();

                while (text != null)
                {
                    Console.WriteLine($"Line {count}: {text}");

                    count++;
                    text = stream.ReadLine();
                }
            }
        }
    }
}
