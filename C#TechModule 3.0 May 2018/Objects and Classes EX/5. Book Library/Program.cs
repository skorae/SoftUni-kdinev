using System;
using System.Collections.Generic;
using System.Globalization;

namespace _5._Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string title = tokens[0];
                string author = tokens[1];
                string publisher = tokens[2];
                DateTime releaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string isbn = tokens[4];
                decimal price = decimal.Parse(tokens[5]);

                Books books = new Books(title, author, publisher, releaseDate, isbn, price);
            }

            var authots = new Dictionary<string, decimal>();

            foreach (Books book in books)
            {
                string authorName = book.Author;
                decimal price = book.Price;

                if (authors.con)
                {

                }
            }
        }
    }
    class Books
    {
        public Books(string title, string author, string publisher, DateTime releaseDate, string iSBN, decimal price)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            ISBN = iSBN;
            Price = price;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }
}
