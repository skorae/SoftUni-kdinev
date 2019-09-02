using System;

namespace Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            string gender = Console.ReadLine();
            double weight = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string activity = Console.ReadLine();

            double caloriesNeeded = 0;
            double bnm = 0;

            if (gender.Equals("m"))
            {
                bnm = 66 + (13.7 * weight) + (5 * (height * 100)) - (6.8 * age);
            }
            else
            {
                bnm = 655 + (9.6 * weight) + (1.8 * (height * 100)) - (4.7 * age);
            }

            if (activity == "sedentary")
            {
                caloriesNeeded = bnm * 1.2;
            }
            else if (activity == "lightly active")
            {
                caloriesNeeded = bnm * 1.375;
            }
            else if (activity == "moderately active")
            {
                caloriesNeeded = bnm * 1.55;
            }
            else
            {
                caloriesNeeded = bnm * 1.725;
            }

            Console.WriteLine($"To maintain your current weight you will need {Math.Ceiling(caloriesNeeded)} calories per day.");
        }
    }
}
