using System;

namespace Exam_Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            long days = int.Parse(Console.ReadLine());
            long runners = int.Parse(Console.ReadLine());
            long averageLaps = int.Parse(Console.ReadLine());
            long lenghtLap = int.Parse(Console.ReadLine());
            long trackCapsity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            long maxCapacity = trackCapsity * days;

            if (runners > maxCapacity)
            {
                runners -= (runners - maxCapacity);
            }
            else if (maxCapacity == 0)
            {
                Console.WriteLine($"Money raised: {0:f2}");
            }

            double total = ((((runners * lenghtLap) * averageLaps) / 1000) * 1.0) * moneyPerKm;

            Console.WriteLine($"Money raised: {total:f2}");
        }
    }
}
