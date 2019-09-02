using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }



    }
}
