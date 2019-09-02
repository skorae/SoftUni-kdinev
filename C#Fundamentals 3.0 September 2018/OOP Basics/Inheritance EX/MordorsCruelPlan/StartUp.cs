using MordorsCruelPlan.Factory;
using MordorsCruelPlan.Moods;
using System;

namespace MordorsCruelPlan
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            FoodFactory foodFactory = new FoodFactory();
            MoodFactory moodFactory = new MoodFactory();

            int happines = foodFactory.GetHappines(arr);
            Mood mood = moodFactory.GetMood(happines);

            Console.WriteLine($"{mood.Happines}");
            Console.WriteLine($"{mood.Type}");
        }
    }
}
