using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Objects
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary, List<int> ids, List<Private> privates) 
            : base(firstName, lastName, id, salary)
        {
            this.Privates = GetPrivates(ids,privates);
        }

        public List<Private> Privates { get; set; }
        
        public List<Private> GetPrivates(List<int> ids, List<Private> privates)
        {
            List<Private> priv = new List<Private>();

            foreach (var i in ids)
            {
                priv.Add(privates.FirstOrDefault(x => x.Id == i));
            }

            return priv;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine("Privates:");
            if (this.Privates.Count != 0)
            {
                foreach (var p in this.Privates)
                {
                    builder.AppendLine($"  {p.ToString()}");
                }
            }
            return builder.ToString().Trim();
        }
    }
}
