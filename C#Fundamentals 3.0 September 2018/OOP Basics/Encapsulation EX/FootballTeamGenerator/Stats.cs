using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;
        private double average;

        public Stats(double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public double Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }

        public double Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        
        public double Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }

        public double Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }

        public double Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }


        internal double GetAverage()
        {
            List<double> temp = new List<double> { this.Endurance, this.Sprint, this.Dribble, this.Passing, this.Shooting };

            return temp.Average();
        }
    }
}
