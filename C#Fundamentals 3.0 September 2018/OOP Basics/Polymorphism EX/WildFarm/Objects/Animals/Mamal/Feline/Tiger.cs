using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals.Mamal.Feline
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat == false)
            {
                Console.WriteLine($"Tiger does not eat {food.GetType().Name}!");
                return;
            }
            this.Weight += food.Quantity * 1.0;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduseSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
