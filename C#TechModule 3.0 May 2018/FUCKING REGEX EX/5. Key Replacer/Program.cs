using System;
using System.Text.RegularExpressions;

namespace _5._Key_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            string pattern = @"([A-Za-z]+)[\||<|\/](.+)[\||<|\/]([A-Za-z]+)";
            Regex regex = new Regex(pattern);

            Match match = regex.Match(key);

            string start = match.Groups[1].Value;
            string end = match.Groups[3].Value;

            string patWord = $@"{start}(?!{end})(.*?){end}";

            MatchCollection matches = Regex.Matches(text, patWord);

            if (matches.Count > 0)
            {
                foreach (Match item in matches)
                {
                    Console.Write($"{item.Groups[1].Value}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty result");
            }
        }
    }
}
