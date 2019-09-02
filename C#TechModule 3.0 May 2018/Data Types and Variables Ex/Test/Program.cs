using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int minutes = 0;
            int hours = 0;
            int days = 0;
            while (seconds > 59)
            {
                seconds -= 60;
                minutes++;
                if (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }
                if (hours > 23)
                {
                    days++;
                    hours -= 24;
                }
            }
            Console.WriteLine($"{days:D1}:{hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
