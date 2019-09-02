using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Objects.Animals.Mamal.Feline
{
    public abstract class Feline : Mamal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
