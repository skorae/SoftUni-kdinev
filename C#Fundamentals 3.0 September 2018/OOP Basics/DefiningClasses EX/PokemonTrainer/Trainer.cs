using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        private string name;
        private int badges;
        private HashSet<Pokemon> pokemons;


        public Trainer(string name)
        {
            this.Name = name;
            this.badges = 0;
            this.Pokemons = new HashSet<Pokemon>();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        public HashSet<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

    }
}
