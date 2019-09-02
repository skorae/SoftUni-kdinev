using System;

namespace Problem_3._Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupsize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            string hallType = "";
            double price = 0;
           
            if (groupsize <= 50)
            {
                hallType = "Small Hall";
                price = 2500;             
            }
            else if (groupsize <= 100)
            {
                hallType = "Terrace";
                price = 5000;
            }
            else if (groupsize <=120)
            {
                hallType = "Great Hall";
                price = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            switch (package)
            {
                case "Normal":
                    price += 500;
                    price = price * 0.95;
                    price = price / groupsize;
                    break;
                case "Gold":
                    price += 750;
                    price = price * 0.90;
                    price = price / groupsize;
                    break;
                case "Platinum":
                    price += 1000;
                    price = price * 0.85;
                    price = price / groupsize;
                    break;               
            }
            Console.WriteLine($"We can offer you the {hallType}");
            Console.WriteLine($"The price per person is {price:F2}$");
        }
    }
}
