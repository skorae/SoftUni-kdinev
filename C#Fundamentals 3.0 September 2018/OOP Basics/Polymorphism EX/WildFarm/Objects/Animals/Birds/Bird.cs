using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }


        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
