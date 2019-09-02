using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stats stats;
        private double skillLevel;
        
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
            this.SkillLevel = stats.GetAverage();
        }
               
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stats Stats
        {
            get { return this.stats; }
            private set { this.stats = value; }
        }

        public double SkillLevel
        {
            get { return this.skillLevel; }
            private set { this.skillLevel = value; }
        }
    }
}
