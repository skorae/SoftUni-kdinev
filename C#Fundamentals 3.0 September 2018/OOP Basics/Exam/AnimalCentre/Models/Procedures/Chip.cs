using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{ animal.Name } is already chipped");
            }
            if (animal is Animal currentAnimal)
            {
                currentAnimal.Happiness -= 5;
                currentAnimal.ProcedureTime -= procedureTime;
                currentAnimal.IsChipped = true;
                ProcedureHistory.Add(animal);
            }
        }
    }
}
