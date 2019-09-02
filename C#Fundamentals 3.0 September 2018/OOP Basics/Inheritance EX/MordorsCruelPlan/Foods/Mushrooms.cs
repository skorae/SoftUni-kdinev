using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public class Mushrooms : Food
    {
        private const int happines = -10;

        public Mushrooms()
            : base(happines)
        {
        }
    }
}
