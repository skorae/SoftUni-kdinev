using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\|<(?<picture>\w+)");

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int skipNumber = numbers[0];
            int takeNumber = numbers[1];

            string text = Console.ReadLine();

            MatchCollection matches = regex.Matches(text);
            string[] allResults = new string[matches.Count];
            int counter = 0;

            foreach (Match match in matches)
            {
                string currentMatch = match.Groups["picture"].Value;

                char[] resultChars = currentMatch.Skip(skipNumber).Take(takeNumber).ToArray();
                string currentResult = string.Join("", resultChars);
                allResults[counter++] = currentResult;
            }
            Console.WriteLine(string.Join(", ", allResults));
        }
    }
}
