using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Mamal.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                this.Weight += food.Quantity * 0.30;
                this.FoodEaten += food.Quantity;
                return;
            }
            Console.WriteLine($"Cat does not eat {food.GetType().Name}!");
        }

        public override void ProduseSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
