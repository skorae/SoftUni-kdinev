using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods.Contracts;

namespace WildFarm.Objects.Foods
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
