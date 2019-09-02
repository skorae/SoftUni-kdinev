using System;
using System.Collections.Generic;
using Animals.Animals;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (command != "Beast!")
            {
                string[] arr = Console.ReadLine().Split();

                try
                {
                    string name = arr[0];
                    int age = int.Parse(arr[1]);
                    string gender = arr[2];

                    Animal animal = AnimalCreate(command, name, age, gender);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", animals));
        }

        public static Animal AnimalCreate(string command, string name, int age, string gender)
        {
            command = command.ToLower();

            switch (command)
            {
                case "dog":
                    return new Dog(name, age, gender);
                case "frog":
                    return new Frog(name, age, gender);
                case "cat":
                    return new Cat(name, age, gender);
                case "tomcat":
                    return new Tomcat(name, age, gender);
                case "kitten":
                    return new Kitten(name, age, gender);
                default:
                    throw new InvalidException();
            }
        }
    }
}
