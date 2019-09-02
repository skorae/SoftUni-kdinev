using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        private KeyValuePair<string, Company> company;
        private KeyValuePair<string, List<Pokemon>> pokemons;
        private KeyValuePair<string, List<Parents>> parents;
        private KeyValuePair<string, List<Children>> children;
        private KeyValuePair<string, Car> car;

        public Person()
        {
            this.Company = new KeyValuePair<string, Company>("Company:", null);
            this.Car = new KeyValuePair<string, Car>("Car:", null);
            this.Pokemons = new KeyValuePair<string, List<Pokemon>>("Pokemon:",new List<Pokemon>());
            this.Parents = new KeyValuePair<string, List<Parents>>("Parents:", new List<Parents>());
            this.Children = new KeyValuePair<string, List<Children>>("Children:", new List<Children>());
        }

        public KeyValuePair<string, Company> Company
        {
            get { return company; }
            set { company = value; }
        }

        public KeyValuePair<string, List<Pokemon>> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public KeyValuePair<string, List<Parents>> Parents
        {
            get { return parents; }
            set { parents = value; }
        }


        public KeyValuePair<string, List<Children>> Children
        {
            get { return children; }
            set { children = value; }
        }

        public KeyValuePair<string, Car> Car
        {
            get { return car; }
            set { car = value; }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{this.Company.Key}{Environment.NewLine}");
            if (this.Company.Value != null)
            {
                builder.Append($"{this.Company.Value.Name} {this.Company.Value.Department} {this.Company.Value.Salary:f2}{Environment.NewLine}");
            }

            builder.Append($"{this.Car.Key}{Environment.NewLine}");
            if (this.Car.Value != null)
            {
                builder.Append($"{this.Car.Value.Model} {this.Car.Value.Speed}{Environment.NewLine}");
            }

            builder.Append($"{this.Pokemons.Key}{Environment.NewLine}");
            if (this.Pokemons.Value.Count != 0)
            {
                foreach (var p in this.Pokemons.Value)
                {
                    builder.Append($"{p.Name} {p.Type}{Environment.NewLine}");
                }
            }

            builder.Append($"{this.Parents.Key}{Environment.NewLine}");
            if (this.Parents.Value.Count != 0)
            {
                foreach (var p in this.Parents.Value)
                {
                    builder.Append($"{p.Name} {p.Birthday}{Environment.NewLine}");
                }
            }

            builder.Append($"{this.Children.Key}{Environment.NewLine}");
            if (this.Children.Value.Count != 0)
            {
                foreach (var p in this.Children.Value)
                {
                    builder.Append($"{p.Name} {p.Birthday}{Environment.NewLine}");
                }
            }

            return builder.ToString();
        }

        public static void Contains(string personName, Dictionary<string, Person> people)
        {
            if (people.ContainsKey(personName) == false)
            {
                Person person = new Person();
                people.Add(personName, person);
            }
        }
    }
}
