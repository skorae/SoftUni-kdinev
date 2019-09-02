using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Objects
{
    public class Soldier : ISoldier
    {
        public Soldier(string firstName,string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
    }
}
