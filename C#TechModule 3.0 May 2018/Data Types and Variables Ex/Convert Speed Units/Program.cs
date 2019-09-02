using System;

namespace Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            float distanceM = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float timeinS = (hours * 3600) + (minutes * 60) + seconds;
            float timeinM = (hours * 60) + minutes + (seconds / 60);
            float timeinH = hours + (minutes / 60) + (seconds / 3600);
            float distanceKM = distanceM / 1000;
            float distanceMI = distanceM / 1609;

            float MS = distanceM / timeinS;
            float KH = distanceKM / timeinH;
            float MPH = distanceMI / timeinH;

            Console.WriteLine(MS);
            Console.WriteLine(KH);
            Console.WriteLine(MPH);
        }
    }
}
