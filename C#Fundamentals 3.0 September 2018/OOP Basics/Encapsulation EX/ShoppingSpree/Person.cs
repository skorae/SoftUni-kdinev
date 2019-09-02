using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value == "   ")
                {
                    throw new ArgumentException("Name cannot be empty");//Name cannot be empty
                }
                this.name = value;
            }
        }


        public decimal Money
        {
            get { return this.money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");//Money cannot be negative
                }
                this.money = value;
            }
        }

        public List<Product> Products
        {
            get { return this.products; }
        }

        internal static void AddPeople(string[] arrNames, Dictionary<string, Person> people)
        {
            foreach (var n in arrNames)
            {
                string[] temp = n.Split("=",StringSplitOptions.RemoveEmptyEntries);

                string name = temp[0];
                decimal money = decimal.Parse(temp[1]);
                Person person = new Person(name, money);

                if (people.ContainsKey(name) == false)
                {
                    people.Add(person.Name, person);
                }
                else
                {
                    people[name].Money += money;
                }
            }
        }
    }
}
