using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "..//..//..//..//files//text.txt";
            string wordsPath = "..//..//..//..//files//words.txt";

            var dictionary = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(wordsPath))
            {
                string words = reader.ReadLine();

                while (words != null)
                {
                    if (dictionary.ContainsKey(words) == false)
                    {
                        dictionary.Add(words, 0);
                    }
                    words = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter($"{path}..//..//result.txt"))
                {
                    while (text != null)
                    {
                        Regex regex = new Regex(@"[\w]+");

                        MatchCollection matches = regex.Matches(text.ToLower());
                        
                        foreach (var word in matches)
                        {
                            if (dictionary.ContainsKey(word.ToString()))
                            {
                                dictionary[word.ToString()]++;
                            }
                        }
                        text = reader.ReadLine();
                    }

                    foreach (var kvp in dictionary.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
