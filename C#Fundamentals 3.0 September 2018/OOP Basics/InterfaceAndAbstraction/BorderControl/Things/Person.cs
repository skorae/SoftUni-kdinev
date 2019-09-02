using BorderControl.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Things
{
    public class Person : Buyer, IPerson, IBuyer
    {
        public Person(string name, string age, string id, string birthday)
            : base()
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Id { get; set; }

        public string Birthday { get; set; }

        public override void BuyFood(string command)
        {
            if (this.Name == command)
            {
                this.Food += 10;
            }
        }
    }
}
