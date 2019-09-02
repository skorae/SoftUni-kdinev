using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Objects
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, int id, int codeNumber)
            : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{this.FirstName} {this.LastName} Id:{this.Id}");
            builder.AppendLine($"Code Number: {this.CodeNumber}");

            return builder.ToString().Trim();
        }
    }
}
