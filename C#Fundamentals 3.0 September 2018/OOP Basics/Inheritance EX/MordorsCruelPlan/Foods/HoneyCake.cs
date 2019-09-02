using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Foods
{
    public class HoneyCake : Food
    {
        private const int happines = 5;

        public HoneyCake()
            : base(happines)
        {
        }
    }
}
