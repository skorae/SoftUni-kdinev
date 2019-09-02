using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name,string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }

        public void GetName()
        {
            Console.WriteLine($"{this.Name}");
        }
    }
}
