using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories;
using WildFarm.Objects.Animals;
using WildFarm.Objects.Animals.Mamal.Feline;
using WildFarm.Objects.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            List<Animal> animals = new List<Animal>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] foodInfo = Console.ReadLine().Split();
                string[] animalInfo = command.Split();

                Food food = foodFactory.GetFood(foodInfo);
                Animal animal = animalFactory.GetAnimal(animalInfo, food);

                animal.ProduseSound();
                animal.Eat(food);
                animals.Add(animal);


                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                if (animal is Feline feline)
                {
                    Console.WriteLine(feline);
                    continue;
                }
                Console.WriteLine(animal);
            }
        }
    }
}
