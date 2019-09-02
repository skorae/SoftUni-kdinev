using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_EX
{
    class Over30
    {
        private List<Person> peopleOver30 = new List<Person>();

        public Over30()
        {
            peopleOver30 = new List<Person>();
        }

        public List<Person> PeopleOver30
        {
            get { return this.peopleOver30; }
            set { this.peopleOver30 = value; }
        }

        public void AddPeopleOver30(Person personOver30)
        {
            if (personOver30 == null)
            {
                throw new Exception();
            }
            this.peopleOver30.Add(personOver30);
        }
        
    }
}
