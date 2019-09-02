using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//text.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadLine();
                int count = 1;

                using (StreamWriter writer = new StreamWriter($"{path}..//..//output.txt"))
                {
                    while (text != null)
                    {
                        writer.WriteLine($"Line {count++}: {text}");

                        text = reader.ReadLine();
                    }
                }
            }
        }
    }
}
