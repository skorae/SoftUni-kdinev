using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        public Fitness()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            if (animal is Animal a)
            {
                a.Happiness -= 3;
                a.Energy += 10;
                a.ProcedureTime -= procedureTime;
                ProcedureHistory.Add(animal);
            }
        }
    }
}
