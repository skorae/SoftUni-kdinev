using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private const int capacity = 10;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            Capacity = capacity;
            animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity { get; }

        public IReadOnlyDictionary<string, IAnimal> Animals { get; }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Keys.Count == Capacity)
            {
                throw new InvalidOperationException($"Not enough capacity");
            }
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            if (animals[animalName] is Animal currentAnimal)
            {
                currentAnimal.Owner = owner;
                currentAnimal.IsAdopt = true;
                animals.Remove(animalName);
            }
        }

        public IAnimal DoesExist(string animalName)
        {
            IAnimal animal;
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            else
            {
                animal = animals[animalName];
            }
            return animal;
        }
    }
}
