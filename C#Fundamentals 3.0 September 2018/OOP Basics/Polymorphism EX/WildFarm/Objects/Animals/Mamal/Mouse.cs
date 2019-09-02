using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Mamal
{
    public class Mouse : Mamal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += food.Quantity * 0.10;
                this.FoodEaten += food.Quantity;
                return;
            }
            Console.WriteLine($"Mouse does not eat {food.GetType().Name}!");
        }

        public override void ProduseSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
