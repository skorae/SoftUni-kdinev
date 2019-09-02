using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public Play()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            if (animal is Animal a)
            {
                a.Energy -= 6;
                a.Happiness += 12;
                a.ProcedureTime -= procedureTime;
                ProcedureHistory.Add(animal);
            }
        }
    }
}
