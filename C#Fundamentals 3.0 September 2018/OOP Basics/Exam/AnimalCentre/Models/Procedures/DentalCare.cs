using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public  class DentalCare : Procedure
    {
        public DentalCare()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal is Animal currentAnimal)
            {
                currentAnimal.Happiness += 12;
                currentAnimal.Energy += 10;
                currentAnimal.ProcedureTime -= procedureTime;
                ProcedureHistory.Add(animal);
            }
        }
    }
}
