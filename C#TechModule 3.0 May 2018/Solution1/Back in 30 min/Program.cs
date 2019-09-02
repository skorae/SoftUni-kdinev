using System;

namespace Back_in_30_min
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            minutes += 30;

            if (minutes >= 60)
            {
                hours++;
                minutes -= 60;
                if (hours > 23)
                {
                    hours = 0;
                }
            }

            Console.WriteLine($"{hours}:{minutes:D2}");


        }

    }
}
