using System;

namespace Back_in_30_min_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine()) + 30;

            var allMinutes = hours * 60 + minutes;

            Console.WriteLine($"{allMinutes / 60 % 24}:{allMinutes % 60:D2}");
        }
    }
}
