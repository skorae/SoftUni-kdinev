using System;
using System.Collections.Generic;
using System.Text;


   public class HardTyre : Tyre
    {
        private const string name = "Hard";

        public HardTyre(double hardness)
            : base(name, hardness)
        {
        }
    }
