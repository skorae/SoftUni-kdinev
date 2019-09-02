using System;
using System.Text.RegularExpressions;

namespace FUCKING_REGEX_EX
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string patern = @"\b(?(?<= )(?<user>[A-Za-z0-9]+[\.\-]*[\w\d]+)| )@(?<host>[A-Za-z]+\-?[A-Za-z]+\.[A-Za-z]+(\.?[A-Za-z]+))\b";

            Regex regex = new Regex(patern);

            MatchCollection matches = Regex.Matches(text, patern);

            foreach (Match item in matches)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}
