using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Pokemon
    {
        private string name;
        private string element;
        private double health;

        public Pokemon(string name, string element, double health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        public double Health
        {
            get { return health; }
            set { health = value; }
        }

    }
}
