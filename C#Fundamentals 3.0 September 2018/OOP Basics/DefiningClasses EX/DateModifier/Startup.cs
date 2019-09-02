using System;
using System.Linq;

namespace DateModifier
{
    class Startup
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            TimeSpan time = DateModifier.GetPassedDays(startDate, endDate);

            Console.WriteLine(time.TotalDays);
        }
    }
}
