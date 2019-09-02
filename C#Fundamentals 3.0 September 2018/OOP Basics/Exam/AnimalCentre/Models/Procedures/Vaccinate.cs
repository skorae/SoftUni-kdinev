using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public Vaccinate()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            if (animal is Animal currentAnimal)
            {
                currentAnimal.Energy -= 8;
                currentAnimal.IsVaccinated = true;
                currentAnimal.ProcedureTime -= procedureTime;
                ProcedureHistory.Add(animal);
            }
        }
    }
}
