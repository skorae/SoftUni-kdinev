using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Entity
{
    public class Pet
    {
        private string name;
        private int age;
        private string kind;

        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.age = age;
            this.kind = kind;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} {this.age} {this.kind}";
        }
    }
}
