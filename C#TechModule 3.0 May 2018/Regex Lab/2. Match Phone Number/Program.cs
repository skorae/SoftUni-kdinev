using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string pattern = @"(^| )\+359{1}(-| )2{1}(\2)\d{3}(\3)\d{4}\b";
        string input = Console.ReadLine();

        MatchCollection matches = Regex.Matches(input, pattern);

        string[] phones = matches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

        Console.WriteLine(string.Join(", ", phones));
    }
}