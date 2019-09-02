using AnimalCentre.Models.Contracts;

using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals.Factory
{
   public class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Animal animal;

            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                default:
                    return null;
            }

            return animal;
        }
    }
}
