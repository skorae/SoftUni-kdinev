using System;

namespace _19._Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            int picsTaken = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int goodPics = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());
            int days = 0;
            int hours = 0;
            long minutes = 0;
            long seconds = 0;

            int usefull = (int)Math.Ceiling(picsTaken * ((goodPics * 1.0) / 100));
            long timeInS = (picsTaken * filterTime) + (usefull * uploadTime);

            seconds = timeInS;

            while (seconds > 59)
            {
                seconds -= 60;
                minutes++;
                if (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }
                if (hours > 24)
                {
                    days++;
                    hours -= 24;
                }
            }
            Console.WriteLine($"{days:D1}:{hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
