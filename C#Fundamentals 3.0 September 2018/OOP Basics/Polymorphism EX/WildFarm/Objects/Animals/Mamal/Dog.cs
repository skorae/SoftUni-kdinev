using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Mamal
{
    public class Dog : Mamal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat == false)
            {
                Console.WriteLine($"Dog does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight = food.Quantity * 0.40;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduseSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
