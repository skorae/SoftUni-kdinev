using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Objects
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string specializationType)
            : base(firstName, lastName, id, salary)
        {
            this.SpecializationType = specializationType;
        }

        public string SpecializationType { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {this.SpecializationType}");

            return builder.ToString().Trim();
        }
    }
}
