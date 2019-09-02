using System;

namespace Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string pachage = Console.ReadLine();

            string hallType = "";
            double hallPrice = 0;
            double pricePerPerson = 0;


            if (group <= 50)
            {
                hallType = "Small Hall";
                hallPrice = 2500;
            }
            else if (group <= 100)
            {
                hallType = "Terrace";
                hallPrice = 5000;
            }
            else if (group <= 120)
            {
                hallType = "Great Hall";
                hallPrice = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            switch (pachage)
            {
                case "Normal":
                    pricePerPerson = ((hallPrice + 500) * 0.95) / group;
                   
                    break;
                case "Gold":
                    pricePerPerson = ((hallPrice + 750) * 0.9) / group;
                    break;
                case "Platinum":
                    pricePerPerson = ((hallPrice + 1000) * 0.85) / group;
                    break;
            }
            Console.WriteLine($"We can offer you the {hallType}\nThe price per person is {pricePerPerson:f2}$");
        }
    }
}
