using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Moods
{
    public class Mood
    {
        private int happines;
        private string type;

        public Mood(int happines, string type)
        {
            this.Happines = happines;
            this.Type = type;
        }

        public int Happines
        {
            get { return happines; }
            set { happines = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}