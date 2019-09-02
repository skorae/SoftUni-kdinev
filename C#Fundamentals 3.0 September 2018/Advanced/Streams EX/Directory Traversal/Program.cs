using System;
using System.Collections.Generic;
using System.IO;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, decimal>>();

            string[] files = Directory.GetFiles("..//..//..//", "*.*", SearchOption.TopDirectoryOnly);


            foreach (string file in files)
            {
                long lenght = File.Open(file, FileMode.Open).Length;

                decimal fileSize = Math.Round(decimal.Divide(lenght, 1024), 3);

                string key = Path.GetExtension(file);

                if (dictionary.ContainsKey(key) == false)
                {
                    dictionary.Add(key, new Dictionary<string, decimal>());
                    dictionary[key].Add(Path.GetFileName(file), fileSize);
                }
                else if (dictionary.ContainsKey(key))
                {
                    if (dictionary[key].ContainsKey(Path.GetFileName(file)) == false)
                    {
                        dictionary[key].Add(Path.GetFileName(file), fileSize);
                    }
                }
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//report.txt";
            using (StreamWriter writer = new StreamWriter(desktopPath))
            {
                foreach (var k in dictionary)
                {
                    writer.WriteLine($"{k.Key}");
                    foreach (var v in k.Value)
                    {
                        writer.WriteLine($"--{v.Key} - {v.Value}kb");
                    }
                }
            }
        }
    }
}
