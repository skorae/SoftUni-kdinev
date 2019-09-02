using BorderControl.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Things
{
    public class Rebel : Buyer, IRebel, IBuyer
    {
        public Rebel(string name,string age,string group)
            :base()
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Group { get; set; }

        public override void BuyFood(string command)
        {
            if (this.Name == command)
            {
                this.Food += 5;
            }
        }
    }
}