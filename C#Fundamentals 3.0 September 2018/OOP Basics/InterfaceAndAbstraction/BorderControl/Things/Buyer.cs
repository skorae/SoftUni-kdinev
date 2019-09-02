using BorderControl.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Things
{
    public abstract class Buyer : IBuyer
    {
        public Buyer()
        {
            this.Food = 0;
        }
        
        public int Food { get; set; }

        public virtual void BuyFood(string command)
        {
            throw new NotImplementedException();
        }
    }
}
