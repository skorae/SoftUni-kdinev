using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookshop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Author
        {
            get { return author; }
            set
            {
                if (value.Any(x => Char.IsDigit(x)))
                {
                    throw new ArgumentException("Author not valid!");
                }
                author = value;
            }
        }

        public virtual string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3 || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Any(x => Char.IsDigit(x)))
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public virtual decimal? Price
        {
            get { return price; }
            set
            {
                if (value < 1 || value == null)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = (decimal)value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Type: {this.GetType().Name}{Environment.NewLine}");
            builder.Append($"Title: {this.Title}{Environment.NewLine}");
            builder.Append($"Author: {this.Author}{Environment.NewLine}");
            builder.Append($"Price: {this.Price:f2}");

            string result = builder.ToString().TrimEnd();
            return result;
        }
    }
}
