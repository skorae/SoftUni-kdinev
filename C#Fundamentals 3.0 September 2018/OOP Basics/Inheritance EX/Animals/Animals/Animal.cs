using System;
using System.Collections.Generic;
using System.Text;
using Animals;

namespace Animals.Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidException();
                }
                name = value;
            }
        }

        public virtual int? Age
        {
            get { return age; }
            set
            {
                if (value == null || value < 0)
                {
                    throw new InvalidException();
                }
                age = (int)value;
            }
        }

        public virtual string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidException();
                }
                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "pe4ata6 gre6no";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{this.GetType().Name}");
            builder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            builder.AppendLine(this.ProduceSound());

            return builder.ToString();
        }
    }
}
