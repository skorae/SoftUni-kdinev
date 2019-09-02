using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * 0.35;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduseSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
