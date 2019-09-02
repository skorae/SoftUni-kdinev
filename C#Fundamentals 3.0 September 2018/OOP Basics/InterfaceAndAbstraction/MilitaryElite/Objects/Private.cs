using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Objects
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
