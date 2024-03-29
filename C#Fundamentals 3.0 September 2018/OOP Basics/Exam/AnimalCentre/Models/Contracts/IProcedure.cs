﻿using AnimalCentre.Models.Animals;
using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        List<IAnimal> ProcedureHistory { get; set; }

        void DoService(IAnimal animal, int procedureTime);
    }
}
