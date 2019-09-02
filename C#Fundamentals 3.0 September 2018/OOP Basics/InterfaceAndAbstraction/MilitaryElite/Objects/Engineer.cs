using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Objects
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, int id, decimal salary, string specializationType, List<KeyValuePair<string, int>> skills)
            : base(firstName, lastName, id, salary, specializationType)
        {
            this.Repairs = skills;
        }

        public List<KeyValuePair<string, int>> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("Repairs:");
            if (this.Repairs.Count != 0)
            {
                foreach (var r in this.Repairs)
                {
                    builder.AppendLine($"  Part Name: {r.Key} Hours Worked: {r.Value}");
                }
            }
            return builder.ToString().Trim();
        }
    }
}
