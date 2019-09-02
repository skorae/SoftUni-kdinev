using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//text.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadLine();
                int count = 0;

                while (text!= null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(text);
                    }

                    count++;
                    text = reader.ReadLine();
                }
            }
        }
    }
}
