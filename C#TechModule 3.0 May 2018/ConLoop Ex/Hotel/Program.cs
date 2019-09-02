using System;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double stuidoPrice = 0;
            double doublePrice = 0;
            double suitePrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    stuidoPrice = 50 * nights;
                    doublePrice = 65 * nights;
                    suitePrice = 75 * nights;
                    if (nights > 7 && month == "October")
                    {
                        stuidoPrice = 50 * (nights - 1);
                    }
                    if (nights > 7)
                    {
                        stuidoPrice -= stuidoPrice * 0.05;
                    }
                    break;
                case "June":
                case "September":
                    stuidoPrice = 60 * nights;
                    doublePrice = 72 * nights;
                    suitePrice = 82 * nights;
                    if (nights > 7 && month == "September")
                    {
                        stuidoPrice = 60 * (nights - 1);
                    }
                    if (nights > 14)
                    {
                        doublePrice -= doublePrice * 0.1;
                    }
                    break;
                case "July":
                case "August":
                case "December":
                    stuidoPrice = 68 * nights;
                    doublePrice = 77 * nights;
                    suitePrice = 89 * nights;
                    if (nights > 14)
                    {
                        suitePrice -= suitePrice * 0.15;
                    }
                    break;
            }
            Console.WriteLine($"Studio: {stuidoPrice:F2} lv.");
            Console.WriteLine($"Double: {doublePrice:F2} lv.");
            Console.WriteLine($"Suite: {suitePrice:F2} lv.");
        }
    }
}
