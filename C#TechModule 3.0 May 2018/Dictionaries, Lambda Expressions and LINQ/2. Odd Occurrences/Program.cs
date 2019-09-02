using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split().ToArray();

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var word in input)
            {
                if (!words.ContainsKey(word))
                {
                    words.Add(word, 1);
                }
                else
                {
                    words[word]++;
                }
            }

            List<string> oddCount = new List<string>();
            foreach (KeyValuePair<string, int> kvp in words)
            {
                if (kvp.Value % 2 != 0)
                {
                    oddCount.Add(kvp.Key);
                }
            }
            Console.WriteLine(string.Join(", ", oddCount));
        }
    }
}
