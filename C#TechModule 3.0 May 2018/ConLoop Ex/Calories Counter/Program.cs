using System;

namespace Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cal = 0;

            for (int i = 0; i < n; i++)
            {
                string add = Console.ReadLine().ToLower();

                switch (add)
                {
                    case "cheese":
                        cal += 500;
                        break;
                        case "tomato sauce":
                        cal += 150;
                        break;
                        case "salami":
                        cal += 600;
                        break;
                       case "pepper":
                        cal += 50;
                        break;                        
                }
            }
            Console.WriteLine($"Total calories: {cal}");
        }
    }
}
