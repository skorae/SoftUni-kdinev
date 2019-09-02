using System;
using System.Text.RegularExpressions;

namespace Regex_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //careers@codexio.bg
            string names = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            Regex regex = new Regex(pattern);
            var name = Regex.Matches(names, pattern);

            foreach (Match item in name)
            {
                Console.Write(item.Value + " ");
            }
            
        }
    }
}

