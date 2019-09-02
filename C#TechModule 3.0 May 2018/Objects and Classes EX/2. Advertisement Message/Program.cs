using System;

namespace _2._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] phrase = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] city = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rPhrase = new Random();
            Random rEvents = new Random();
            Random rAuthors = new Random();
            Random rCity = new Random();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrase[rPhrase.Next(phrase.Length)]}. {events[rEvents.Next(events.Length)]}. " +
                    $"{authors[rAuthors.Next(authors.Length)]} - {city[rCity.Next(city.Length)]}");
            }
        }
    }
}


