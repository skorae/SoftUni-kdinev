using System;

namespace dasdd
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            
            double ppp = 0;

            switch (month)
            {
                case "march":
                case "april":
                case "may":
                    if (timeOfDay.Equals("day"))
                    {
                        ppp = 10.50;
                        if (people >= 4)
                        {
                            ppp *= 0.9;
                        }
                        if (hours >= 5)
                        {
                            ppp *= 0.5;
                        }
                    }
                    else
                    {
                        ppp = 8.4;
                        if (people >= 4)
                        {
                            ppp *= 0.9;
                        }
                        if (hours >= 5)
                        {
                            ppp *= 0.5;
                        }
                    }
                    break;
                case "june":
                case "july":
                case "august":
                    if (timeOfDay.Equals("day"))
                    {
                        ppp = 12.60;
                        if (people >= 4)
                        {
                            ppp *= 0.9;
                        }
                        if (hours >= 5)
                        {
                            ppp *= 0.5;
                        }
                    }
                    else
                    {
                        ppp = 10.20;
                        if (people >= 4)
                        {
                            ppp *= 0.9;
                        }
                        if (hours >= 5)
                        {
                            ppp *= 0.5;
                        }
                    }
                    break;
            }

            double total = (ppp * hours) * people;

            Console.WriteLine($"Price per person for one hour: {ppp:f2}");
            Console.WriteLine($"Total cost of the visit: {total:f2}");
        }
    }
}
