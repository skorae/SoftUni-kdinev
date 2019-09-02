using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_EX
{
    public class Family
    {
        private List<Person> members = new List<Person>();

        public Family()
        {
            this.members = new List<Person>();
        }

        public List<Person> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public void AddMember(Person member)
        {
            if (member == null)
            {
                throw new Exception();
            }
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.Members.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
