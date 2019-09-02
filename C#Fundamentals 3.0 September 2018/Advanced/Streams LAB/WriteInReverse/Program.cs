using System;
using System.IO;
using System.Linq;

namespace WriteInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//Program.cs";
            string file = "SomeFile.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string newPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), file);

                using (StreamWriter writer = new StreamWriter(newPath))
                {
                    string text = reader.ReadLine();

                    while (text != null)
                    {
                        writer.WriteLine(string.Join("",text.Reverse()));
                        text = reader.ReadLine();
                    }
                }
            }


        }
    }
}
