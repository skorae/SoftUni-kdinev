using MordorsCruelPlan.Moods;
using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Factory
{
    public class MoodFactory
    {
        public Mood GetMood(int happines)
        {
            string mood = "";

            if (happines < -5)
            {
                mood = "Angry";
            }
            else if (happines <= 0)
            {
                mood = "Sad";
            }
            else if (happines <= 15)
            {
                mood = "Happy";
            }
            else
            {
                mood = "JavaScript";
            }

            return new Mood(happines, mood);
        }
    }
}
