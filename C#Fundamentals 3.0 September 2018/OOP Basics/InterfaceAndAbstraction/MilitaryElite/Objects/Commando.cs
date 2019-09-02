using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Objects
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, int id, decimal salary, string specializationType,List<KeyValuePair<string,string>> missions)
            : base(firstName, lastName, id, salary, specializationType)
        {
            this.Missions = missions;
        }

        public List<KeyValuePair<string, string>> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("Missions:");
            if (this.Missions.Count != 0)
            {
                foreach (var m in this.Missions)
                {
                    builder.AppendLine($"  Code Name: {m.Key} State: {m.Value}");
                }
            }
            
            return builder.ToString().Trim();
        }
    }
}
