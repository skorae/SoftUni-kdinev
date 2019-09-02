using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public abstract class Food
    {
        public Food(int happines)
        {
            this.Happines = happines;
        }

        public int Happines { get;}
    }
}
