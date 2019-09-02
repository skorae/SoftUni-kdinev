using System;
using System.Text.RegularExpressions;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string namePat = @"%([A-Z][a-z]+)%";
            string prodPat = @"<([\w]+)>";
            string countPat = @"\|(\d+)\|";
            string pricePAt = @"([\d]+\.?[\d]+)\$";

            double total = 0;

            while (input != "end of shift")
            {
                double sum = 0;

                string name = "";
                string product = "";
                int count = 0;
                double price = 0;

                Match nameMatch = Regex.Match(input, namePat);
                Match productMatch = Regex.Match(input, prodPat);
                Match countmatch = Regex.Match(input, countPat);
                Match priceMatch = Regex.Match(input, pricePAt);

                if (nameMatch.Success)
                {
                    name = nameMatch.Groups[1].ToString();
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (productMatch.Success)
                {
                    product = productMatch.Groups[1].ToString();
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (countmatch.Success)
                {
                    count = int.Parse(countmatch.Groups[1].ToString());
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (priceMatch.Success)
                {
                    price = double.Parse(priceMatch.Groups[1].ToString());
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                sum = price * count ;
                total += sum;
                Console.WriteLine($"{name}: {product} - {sum:f2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
