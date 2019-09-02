using AnimalCentre.Models;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Animals.Factory;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using AnimalCentre.Models.Procedures.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private IAnimal animal;
        private Dictionary<string, Procedure> procedures;
        private Dictionary<string, List<IAnimal>> ownedAnimals;
        private AnimalFactory animalfactory;
        private ProcedureFactory procedureFactory;
        private string key;

        public AnimalCentre()
        {
            hotel = new Hotel();
            procedures = new Dictionary<string, Procedure>();
            ownedAnimals = new Dictionary<string, List<IAnimal>>();
            this.animalfactory = new AnimalFactory();
            procedureFactory = new ProcedureFactory();
            key = "";
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            animal = animalfactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            animal = hotel.DoesExist(name);
            key = "Chip";
            CheckProcedureKey("Chip");
            procedures[key].DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            animal = hotel.DoesExist(name);
            key = "Vaccinate";
            CheckProcedureKey("Vaccinate");
            procedures[key].DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            animal = hotel.DoesExist(name);
            key = "Fitness";
            CheckProcedureKey("Fitness");
            procedures[key].DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            animal = hotel.DoesExist(name);
            key = "Play";
            CheckProcedureKey("Play");
            procedures[key].DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            animal = hotel.DoesExist(name);
            key = "DentalCare";
            CheckProcedureKey("DentalCare");
            procedures[key].DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            animal = hotel.DoesExist(name);
            key = "NailTrim";
            CheckProcedureKey("NailTrim");
            procedures[key].DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            string message = "";

            animal = hotel.DoesExist(animalName);
            hotel.Adopt(animalName, owner);
            AddownedAnimal(animal);
            if (animal.IsChipped)
            {
                message = $"{owner} adopted animal with chip";
            }
            else
            {
                message = $"{owner} adopted animal without chip";
            }

            return message;
        }

        public string History(string type)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{type}");

            builder.AppendLine(this.procedures[type].History());

            return builder.ToString().TrimEnd();
        }

        private void CheckProcedureKey(string v)
        {
            if (!procedures.ContainsKey(v))
            {
                procedures.Add(v, procedureFactory.GetProcedure(v));
            }
        }

        private void AddownedAnimal(IAnimal animal)
        {
            if (!ownedAnimals.ContainsKey(animal.Owner))
            {
                ownedAnimals.Add(animal.Owner, new List<IAnimal>());
                ownedAnimals[animal.Owner].Add(animal);
            }
            else
            {
                ownedAnimals[animal.Owner].Add(animal);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var owner in ownedAnimals.OrderBy(x => x.Key))
            {
                builder.AppendLine($"--Owner: {owner.Key}");
                builder.AppendLine($"    - Adopted animals: {string.Join(" ", owner.Value.Select(x => x.Name))}");
            }

            return builder.ToString().Trim();
        }
    }
}
