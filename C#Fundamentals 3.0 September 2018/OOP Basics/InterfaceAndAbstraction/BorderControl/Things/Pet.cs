using BorderControl.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Things
{
    public class Pet : Buyer, IPet
    {

        public Pet(string name, string birthday)
            : base()
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }
    }
}
