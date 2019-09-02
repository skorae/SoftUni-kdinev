using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory { get; set;}

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public string History()
        {
            StringBuilder builder = new StringBuilder();
            
            foreach (var a in this.ProcedureHistory)
            {
                builder.AppendLine(a.ToString());
            }
            return builder.ToString().TrimEnd();
        }
    }
}
