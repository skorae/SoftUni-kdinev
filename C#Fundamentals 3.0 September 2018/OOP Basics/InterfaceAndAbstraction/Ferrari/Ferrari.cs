using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string name)
        {
            this.Driver = name;
        }

        public string Model => "488-Spider";

        public string Driver { get; set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Brakes()}/{Gas()}/{this.Driver}";
        }
    }
}
