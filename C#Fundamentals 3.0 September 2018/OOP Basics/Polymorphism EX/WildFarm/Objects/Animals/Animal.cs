using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Objects.Animals.Contracts;
using WildFarm.Objects.Foods;

namespace WildFarm.Objects.Animals
{
    public abstract class Animal : IAnimal
    {
        private int foodEaten;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public string Name { get; set; }

        public double Weight { get; set; }

        public abstract void ProduseSound();

        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
