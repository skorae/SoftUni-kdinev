using System;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat == false)
            {
                Console.WriteLine($"Owl does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight += food.Quantity * 0.25;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduseSound() => System.Console.WriteLine("Hoot Hoot");
    }
}